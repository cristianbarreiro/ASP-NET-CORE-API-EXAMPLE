# 02 — Routing y Controllers

## Objetivos
- Entender `[ApiController]`, `[Route]` y atributos HTTP.
- Practicar route parameters, query strings y body binding.
- Mantener controllers delgados.

## Explora
Abre `src/TaskFlow.API/Controllers/TasksController.cs`. Identifica cómo cada método HTTP se asocia con una acción y cómo `CreatedAtAction` construye una respuesta 201.

## Ejercicios
1. Agrega `GET /api/tasks/completed` para listar tareas completadas.
2. Agrega `GET /api/tasks?search=...` para filtrar por título.
3. Devuelve 400 si un parámetro de paginación es menor que 1.
4. Explica cuándo usar `[FromRoute]`, `[FromQuery]` y `[FromBody]`.

## Criterio de finalización
Puedes diseñar rutas consistentes y seleccionar el binding apropiado.
