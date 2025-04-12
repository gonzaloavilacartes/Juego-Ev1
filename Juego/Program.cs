// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");


using System;

class Juego
{
    public static void Main()
    {
        // Crear personajes iniciales
        Barbaro barbaro = new Barbaro("Barbaro", 100, 15, 9);
        Sacerdote sacerdote = new Sacerdote("Sacerdote", 100, 10);

        // Primer duelo
        Console.WriteLine("\n--- DUELO 1: Bárbaro vs Sacerdote ---");
        Personaje? ganador = Batalla(barbaro, sacerdote);

        if (ganador != null)
        {
            Console.WriteLine($"\n¡{ganador.GetNombre()} ganó el primer duelo!");
            ganador.SetVida(100); // Vida completa
            Console.WriteLine($"{ganador.GetNombre()} se ha curado completamente para el duelo final.\n");

            // Crear EnderDragon
            Console.WriteLine("Creando al jefe final: EnderDragon...");
            EnderDragon jefe = new EnderDragon("EnderDragon", 120, 20);

            // Crear equipo para jefe
            Equipo equipoJefe = new Equipo(5, 3);
            jefe.Equipar(equipoJefe);

            // Duelo final
            Console.WriteLine("\n--- DUELO FINAL: Ganador vs EnderDragon ---");
            Personaje? campeon = Batalla(ganador, jefe);
            ganador.SetVida(100); // full de vida

            if (campeon != null)
                Console.WriteLine($"\n{campeon.GetNombre()} es el campeón definitivo!");
            else
                Console.WriteLine("\n¡Ambos han caído en combate!");
        }
    }

    public static Personaje? Batalla(Personaje p1, Personaje p2, int maxRondas = int.MaxValue)
    {
        int ronda = 1;
        while (p1.GetVida() > 0 && p2.GetVida() > 0)
        {
            Console.WriteLine($"\nRonda {ronda}");
            p1.Atacar(p2);
            p2.Atacar(p1);
            ronda++;
        }

        if (p1.GetVida() <= 0 && p2.GetVida() <= 0)
            return null; // Ambos caen en combate
        else if (p1.GetVida() > 0)
            return p1;
        else
            return p2;
    }
}

class Personaje
{
    protected string nombre;
    protected int vida;
    protected int ataque;
    protected Equipo? equipo;

    public Personaje(string nombre, int vida, int ataque)
    {
        this.nombre = nombre;
        this.vida = vida;
        this.ataque = ataque;
        this.equipo = null;
    }

    public string GetNombre() => nombre;

    public int GetVida() => vida;

    public virtual int GetAtaque()
    {
        int modAtaque = equipo != null ? equipo.getModificadorAtaque() : 0;
        return ataque + modAtaque;
    }

    public virtual int GetArmadura()
    {
        return equipo != null ? equipo.getModificadorArmadura() : 0;
    }

    public virtual void Atacar(Personaje objetivo)
    {
        Console.WriteLine($"{nombre} ataca a {objetivo.GetNombre()}");
        objetivo.RecibirDanio(GetAtaque());
    }

    public virtual void RecibirDanio(int danio)
    {
        int danioTotal = danio - GetArmadura();
        danioTotal = danioTotal < 1 ? 1 : danioTotal;
        vida -= danioTotal;
        if (vida < 0) vida = 0;

        Console.WriteLine($"{nombre} recibe {danioTotal} puntos de daño.{(vida == 0 ? " Ha muerto :(" : "")}");
    }

    public void Equipar(Equipo equipo)
    {
        this.equipo = equipo;
    }

    public void SetVida(int nuevaVida)
    {
        this.vida = nuevaVida;
    }
}

class Barbaro : Personaje
{
    private int furia;

    public Barbaro(string nombre, int vida, int ataque, int furia) : base(nombre, vida, ataque)
    {
        this.furia = furia;
    }

    public override void Atacar(Personaje objetivo)
    {
        if (furia >= 3)
        {
            int danio = (int)Math.Round(GetAtaque() * 1.15);
            furia -= 3;
            Console.WriteLine($"{nombre} ataca furioso a {objetivo.GetNombre()}");
            objetivo.RecibirDanio(danio);
        }
        else
        {
            int danio = (int)Math.Round(GetAtaque() * 0.5);
            Console.WriteLine($"{nombre} está cansado y ataca a {objetivo.GetNombre()}");
            objetivo.RecibirDanio(danio);
        }
    }
}

class Sacerdote : Personaje
{
    private static Random rng = new Random();

    public Sacerdote(string nombre, int vida, int ataque) : base(nombre, vida, ataque) { }

    public override void RecibirDanio(int danio)
    {
        if (rng.Next(4) == 0) // 25% chance
        {
            danio = (int)Math.Round(danio / 2.0);
            Console.WriteLine($"Las plegarias de {nombre} han sido escuchadas.");
        }
        base.RecibirDanio(danio);
    }
}

class EnderDragon : Personaje
{
    private static Random rng = new Random();

    public EnderDragon(string nombre, int vida, int ataque) : base(nombre, vida, ataque + 5) { }

    public override void RecibirDanio(int danio)
    {
        if (rng.Next(4) == 0) // 25% chance de esquivar
        {
            Console.WriteLine($"{nombre} esquiva el ataque!");
            return;
        }
        base.RecibirDanio(danio);
    }
}

class Equipo
{
    protected int modificadorAtaque;
    protected int modificadorArmadura;

    public Equipo(int modAtaque, int modArmadura)
    {
        modificadorAtaque = modAtaque;
        modificadorArmadura = modArmadura;
    }

    public int getModificadorAtaque() => modificadorAtaque;
    public int getModificadorArmadura() => modificadorArmadura;
}

class Arma : Equipo
{
    public Arma(int ataque) : base(ataque, 0) { }
}

class Armadura : Equipo
{
    public Armadura(int armadura) : base(0, armadura) { }
}
