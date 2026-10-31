# 01 — Fundamentos de Web API

## Objetivos
- Entender cliente-servidor y el ciclo request/response.
- Diferenciar recursos, rutas, métodos HTTP y códigos de estado.
- Reconocer JSON como formato de intercambio.

## Conceptos
Una API REST expone recursos mediante URLs. El método HTTP expresa la operación: GET consulta, POST crea, PUT reemplaza/actualiza, PATCH modifica parcialmente y DELETE elimina.

Códigos frecuentes:
- `200 OK`: consulta o acción exitosa.
- `201 Created`: recurso creado; suele incluir `Location`.
- `204 No Content`: operación exitosa sin cuerpo.
- `400 Bad Request`: entrada inválida.
- `401 Unauthorized`: falta autenticación válida.
- `403 Forbidden`: identidad autenticada sin permiso.
- `404 Not Found`: recurso inexistente.
- `500 Internal Server Error`: error no controlado.

## Práctica
1. Ejecuta TaskFlow y realiza un GET a `/api/tasks`.
2. Crea una tarea con POST.
3. Observa el código 201 y la cabecera Location.
4. Consulta la tarea creada.
5. Intenta consultar un GUID inexistente y observa el 404.

## Para investigar
- ¿Qué diferencia hay entre PUT y PATCH?
- ¿Por qué un POST no debería responder siempre 200?
- ¿Qué significa que HTTP sea stateless?

## Criterio de finalización
Puedes explicar una petición HTTP completa y justificar el código de estado de cada endpoint.
