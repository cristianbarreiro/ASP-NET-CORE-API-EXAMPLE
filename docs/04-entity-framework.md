# 04 — Entity Framework Core

## Objetivos
- Comprender DbContext, DbSet y tracking.
- Diferenciar `AsNoTracking` de consultas con tracking.
- Aprender migraciones y relaciones.

## Explora
Revisa `TaskFlowDbContext` y `TaskRepository`. La configuración inicial usa SQLite y `EnsureCreated` para simplificar el primer arranque.

## Ejercicios
1. Sustituye `EnsureCreated` por migraciones.
2. Agrega una entidad Category y una relación uno-a-muchos.
3. Crea una migración y comprueba el esquema.
4. Investiga cuándo conviene usar `AsNoTracking`.

## Criterio de finalización
Puedes modelar entidades y evolucionar el esquema con migraciones.
