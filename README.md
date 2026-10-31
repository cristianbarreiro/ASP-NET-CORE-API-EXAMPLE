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

La aplicación se ejecutará en:
- HTTP: `http://localhost:5080`
- HTTPS: `https://localhost:7080`

La API usa SQLite para comenzar sin dependencias externas (`taskflow.db` se crea automáticamente al iniciar).

### Documentación y pruebas interactivas

En entorno de desarrollo puedes explorar y probar los endpoints interactivamente con **Scalar UI**:
- **Interfaz Interactiva (Scalar):** [http://localhost:5080/](http://localhost:5080/) (redirige a `/scalar/v1`)
- **Especificación OpenAPI (JSON):** [http://localhost:5080/openapi/v1.json](http://localhost:5080/openapi/v1.json)

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
TaskFlow.sln                Solución vinculando todos los proyectos
src/
  TaskFlow.API/             HTTP, controllers, OpenAPI / Scalar UI y configuración
  TaskFlow.Application/     DTOs, contratos y casos de uso
  TaskFlow.Domain/          Entidades y reglas del dominio
  TaskFlow.Infrastructure/  EF Core y persistencia SQLite
tests/
  TaskFlow.UnitTests/       Pruebas unitarias con xUnit
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
# Compilar toda la solución
dotnet build

# Ejecutar pruebas unitarias
dotnet test

# Iniciar la API en desarrollo
dotnet run --project src/TaskFlow.API

# Migraciones EF Core
dotnet ef migrations add InitialCreate --project src/TaskFlow.Infrastructure --startup-project src/TaskFlow.API
dotnet ef database update --project src/TaskFlow.Infrastructure --startup-project src/TaskFlow.API
```

> **Nota:** Si no tienes instalada la herramienta CLI de EF Core: `dotnet tool install --global dotnet-ef`.

## Convenciones

- Controllers delgados: HTTP entra y sale por la capa API.
- DTOs para entrada y salida.
- La lógica de aplicación no depende de ASP.NET Core.
- La infraestructura implementa contratos definidos por Application.
- No se exponen entidades de EF directamente como contratos públicos.
- Los cambios se incorporan por fases; no adelantes JWT, CQRS o microservicios antes de dominar los fundamentos.

## Estado inicial

El proyecto incluye:
- Solución [TaskFlow.sln](TaskFlow.sln) configurada y enlazada.
- CRUD de tareas (`/api/tasks`).
- EF Core con SQLite y auto-creación de esquema.
- DTOs y validación por Data Annotations.
- Inyección de dependencias (`ITaskRepository`, `TaskService`).
- Documentación OpenAPI integrada con **Scalar UI** en la raíz.
- Pruebas unitarias iniciales con **xUnit** en verde.
