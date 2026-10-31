# 05 — Authentication y Authorization

## Objetivos
- Diferenciar autenticación de autorización.
- Comprender claims, roles, policies y JWT.
- Proteger endpoints.

## Laboratorio pendiente
1. Agrega registro e inicio de sesión.
2. Almacena contraseñas con un algoritmo de hashing adecuado; nunca texto plano.
3. Emite JWT con expiración y claims mínimos.
4. Configura `AddAuthentication` y `AddAuthorization`.
5. Protege operaciones de escritura.
6. Prueba 401, 403 y 200 con un cliente HTTP.

## Seguridad
No guardes secretos en Git. Usa User Secrets en desarrollo y un gestor de secretos en producción. JWT requiere validar firma, issuer, audience y expiración.
