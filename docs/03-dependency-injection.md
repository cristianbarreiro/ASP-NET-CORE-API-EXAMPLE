# 03 — Dependency Injection y Services

## Objetivos
- Comprender inversión de dependencias e interfaces.
- Diferenciar Transient, Scoped y Singleton.
- Entender por qué `DbContext` normalmente es Scoped.

## Explora
Sigue el registro `AddScoped<ITaskRepository, TaskRepository>()` en `Program.cs`, y luego la inyección por constructor en `TasksController` y `TaskService`.

## Ejercicios
1. Explica el grafo de dependencias desde HTTP hasta SQLite.
2. Cambia temporalmente el repositorio por una implementación en memoria.
3. ¿Qué problema puede aparecer al inyectar un servicio Scoped en uno Singleton?

## Criterio de finalización
Puedes registrar servicios y explicar su ciclo de vida.
