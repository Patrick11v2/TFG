# TFG
Trabajo de fin de grado

El proyecto GestLeague es una aplicación de escritorio dedicada a la gestión y creación de ligas de fútbol en un ámbito amateur. La aplicación puede crear, editar y elimimar ligas, equipos, y jugadores. Además crear partidos y mostrar clasificaciones de las ligas con sus rankings de goleadores y amonestados.

GUÍA DE FUNCIONAMIENTO

La aplicación comienza en la vista de Ligas, donde lo primero que haremos sera crear una liga.

VISTA LIGA

Para crear la liga le damos un nombre, una temporada y un numero de equipos. *No se puede crear ligas con el mismo nombre. *No se puede crear ligas con mas de 20 equipos. *No se puede crear ligas con menos de 3 equipos. *No se puede eliminar una liga si esta contiene equipos. *No se puede editar el numero de equipos por debajo de los equipos asociados a la liga.

VISTA CLUBES

En la vista clubes se nos muestra una lista de los equipos creados.

Para crear un equipo le damos un nombre y la liga a la que va a pertenecer.

*No se puede crear equipos con el mismo nombre. *Si la liga ha alcanzado su máximo de equipos, no se podra crear nuevos. *Si la liga ha alcanzado su máximo de equipos, no se podra cambiar de liga a los equipos existentes.

VISTA JUGADORES

En la vista jugadores seleccionaremos una liga, y posteriormente un club. Una vez hecho esto se nos mostrará una lista de los jugadores del club.

Para crear un jugador le damos nombre, apellidos, número, posición y equipo al que pertenecerá.

*No se puede crear jugadores de un mismo club con el mismo número. *No se puede crear jugadores con un numero mayor a 99." *No se podrá eliminar jugadores que hayan marcado gol o recibido tarjeta.

VISTA CLASIFICACIÓN

En la vista clasificacción seleccionaremos una liga y se nos cargaran 3 listas con la clasificación de la liga, la clasificación de los goleadores y la clasificación de los amonestados.

VISTA RESULTADOS

En la vista resultados seleccionaremus una liga y una jornada para que cargue una lista con los partidos de esa liga y esa jornada. En esta vista también se crean los partidos, seleccionando el equipo local y el equipo visitante. Después seleccionaremos los goleadores y el numero de goles que han marcado y los amonestados y el numero de tarjetas que han recibido. Una vez seleccionado todos los campos del partido, liga, jornada, equipo local, equipo visitante, goleadores de ambos equipos (si los hay) y amonestados de ambos equipos (si los hay) creamos un partido que no se podrá ni editar ni eliminar.

*Un equipo no puede jugar mas de dos veces una misma jornada. *No se puede añadir un goleador si ya se ha añadido antes. *No se puede añadir un amonestado si ya se ha añadido antes. *Hay un maximo de partidos por jornada, dependiendo del numero de equipos de la liga *No se puede crear un partido si ya se ha cumplido el maximo de partidos por jornada.

La mayoria de registros que se crean exceptuando ligas, tienen incidencia directa en otros registros. Ej: Si se crea un jugador, el numero de jugadores en el equipo que pertenece se actualiza. Ej: Si se crea un partido con goleadores y amonestados, los jugadores que han marcado gol y han sido amonestados se actualizan para establecer los nuevos goles y tarjetas.

Aplicación desarrollada con Visual Studio 2022 y con la base de datos SQL Server.
