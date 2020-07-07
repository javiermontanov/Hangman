# El juego del ahorcado usando WebAssembly con Blazor, ASP.NET Core 3.1, SQL Server y Docker

:: REQUERIMIENTOS ::
•	La aplicación debe permitir registrar un jugador y autenticarlo para permitirle jugar. La aplicación debe permitir a varios jugadores jugar al mismo tiempo.
•	Las palabras utilizadas para el juego deben estar organizadas en categorías. En cada categoría puede haber varias palabras, cada una con su respectivo nivel de dificultad (del 1 al 1000).
•	El jugador elige una categoría para jugar y comienza con una palabra del nivel más fácil disponible (1), cada vez que el usuario adivina una palabra pasa al siguiente nivel (o sea, la siguiente palabra jugada en la misma categoría debe ser un poco más difícil que la anterior (nivel 2)).
•	Se debe guardar estadísticas por usuario y categoría para saber cuántas veces ganó, cuántas perdió y cuantas abandonó una partida. 
•	Las estadísticas para el usuario y general (todos los usuarios) para la categoría, se deben mostrar cuando el usuario elige la categoría que desea jugar.
•	La aplicación debe estar implementada en WebAssembly usando Blazor y ASP.NET Core 3.1 como backend. Otras tecnologías de apoyo como la base de datos, o frameworks son de libre elección.
•	Todos los servicios implementados deben correr sobre Docker usando docker-compose.

:: USO ::
Ejecutar el comando "docker-compose up" desde linea de comados


Cualquier duda o comentario a: javiermontanov@gmail.com