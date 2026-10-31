# ASP.NET Core Web API Learning — TaskFlow

Repositorio práctico para aprender a construir APIs REST con **C# y ASP.NET Core (.NET 10)** mediante un proyecto incremental: TaskFlow, una API de gestión de tareas.

> El objetivo es aprender haciendo. Cada fase agrega conceptos sobre una base funcional, evitando introducir demasiada arquitectura desde el primer día.

## Requisitos

- .NET 10 SDK
- Visual Studio 2022 actualizado / Visual Studio Code / Rider
- Git
- (Opcional) Docker

## Ejecutar

```bash
dotnet restore
dotnet run --project src/TaskFlow.API
```

La API usa SQLite para que puedas comenzar sin instalar PostgreSQL. La base se crea automáticamente al iniciar.

Consulta la documentación OpenAPI desde la aplicación en desarrollo.

## Primeros endpoints

| Método | Ruta | Descripción |
|---|---|---|
| GET | `/api/tasks` | Listar tareas |
| GET | `/api/tasks/{id}` | Obtener una tarea |
| POST | `/api/tasks` | Crear una tarea |
| PUT | `/api/tasks/{id}` | Actualizar una tarea |
| DELETE | `/api/tasks/{id}` | Eliminar una tarea |

Ejemplo de `POST /api/tasks`:

```json
{
  "title": "Aprender ASP.NET Core",
  "description": "Crear mi primera API REST",
  "isCompleted": false
}
```

## Estructura

```text
src/
  TaskFlow.API/             HTTP, controllers, configuración
  TaskFlow.Application/     DTOs, contratos y casos de uso
  TaskFlow.Domain/          Entidades y reglas del dominio
  TaskFlow.Infrastructure/  EF Core y persistencia
tests/
  TaskFlow.UnitTests/
  TaskFlow.IntegrationTests/
docs/                       Guías y ejercicios por fase
```

## Ruta de aprendizaje

1. **Fundamentos:** HTTP, REST, JSON, códigos de estado y ciclo de una petición.
2. **Controllers y routing:** atributos, parámetros, verbos HTTP y model binding.
3. **DTOs y validación:** separar contratos HTTP de entidades y validar entradas.
4. **Dependency Injection:** interfaces, ciclo de vida y registro de servicios.
5. **EF Core:** DbContext, entidades, migraciones y consultas.
6. **Arquitectura:** Domain, Application, Infrastructure y API.
7. **Middleware:** pipeline HTTP, excepciones y logging.
8. **Seguridad:** autenticación JWT, autorización y roles.
9. **Consultas:** paginación, filtros, búsqueda y ordenamiento.
10. **Calidad:** pruebas unitarias e integración.
11. **Operación:** configuración, health checks, logs y seguridad.
12. **Entrega:** Docker, PostgreSQL y despliegue.

Cada guía de `docs/` contiene objetivos, explicación, práctica y criterios de finalización.

## Comandos útiles

```bash
dotnet build
dotnet test
dotnet ef migrations add InitialCreate --project src/TaskFlow.Infrastructure --startup-project src/TaskFlow.API
dotnet ef database update --project src/TaskFlow.Infrastructure --startup-project src/TaskFlow.API
```

Si no tienes EF CLI: `dotnet tool install --global dotnet-ef`.

## Convenciones

- Controllers delgados: HTTP entra y sale por la capa API.
- DTOs para entrada y salida.
- La lógica de aplicación no depende de ASP.NET Core.
- La infraestructura implementa contratos definidos por Application.
- No se exponen entidades de EF directamente como contratos públicos.
- Los cambios se incorporan por fases; no adelantes JWT, CQRS o microservicios antes de dominar los fundamentos.

## Estado inicial

El starter incluye CRUD de tareas, EF Core con SQLite, DTOs, validación por Data Annotations, inyección de dependencias y una prueba unitaria básica. Las siguientes fases están documentadas como ejercicios para implementar.
