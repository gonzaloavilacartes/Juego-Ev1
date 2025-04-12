# Juego-Ev1
# Juego de Combate: Bárbaro, Sacerdote y EnderDragon

Este proyecto es un juego de combate por turnos desarrollado en C#. Los jugadores controlan personajes con habilidades únicas y pueden enfrentarse en duelos épicos, incluyendo un enfrentamiento final contra el jefe **EnderDragon**.

## Descripción

El juego permite simular combates entre personajes con diferentes habilidades y estadísticas. Los personajes pueden equiparse con armas y armaduras para mejorar su desempeño en batalla. El objetivo es derrotar a los oponentes y convertirse en el campeón definitivo.

### Personajes

- **Bárbaro**: Un guerrero con la habilidad de realizar ataques furiosos si acumula suficiente furia.
- **Sacerdote**: Un personaje con la capacidad de reducir el daño recibido gracias a sus plegarias.
- **EnderDragon**: El jefe final, con alta resistencia y la habilidad de esquivar ataques.

### Mecánicas principales

1. **Ataque**: Los personajes atacan a sus oponentes, infligiendo daño basado en su ataque y la armadura del objetivo.
2. **Esquivar**: Algunos personajes tienen una probabilidad de esquivar ataques.
3. **Equipamiento**: Los personajes pueden equiparse con armas y armaduras que modifican sus estadísticas.
4. **Batalla**: Los personajes luchan en rondas hasta que uno de ellos gane o ambos caigan en combate.

## Flujo del Juego

1. **Primer duelo**: Un Bárbaro y un Sacerdote se enfrentan.
2. **Curación**: El ganador del primer duelo recupera toda su vida.
3. **Duelo final**: El ganador del primer duelo se enfrenta al jefe final, **EnderDragon**.

## Requisitos

- .NET 6.0 SDK o superior.

## Cómo ejecutar el proyecto

1. Clona este repositorio o descarga los archivos.
2. Abre una terminal en la carpeta raíz del proyecto.
3. Ejecuta el siguiente comando para compilar y ejecutar el programa:

   ```bash
   dotnet run
