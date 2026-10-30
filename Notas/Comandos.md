# ⌨️ Comandos

Volver a [[00 Inicio]]

| Comando | Para qué |
|---|---|
| `ng serve` (o `npm start`) | Correr el proyecto → abrir `http://localhost:4200` |
| `ng g c Components/nombre` | Crear componente (ej. `ng g c Components/puesto`) |
| `ng g s Services/ServiciosNombre` | Crear servicio |
| `Ctrl + C` en la terminal | Detener `ng serve` |

- Después de crear componente o servicio → **borrar el `.spec.ts`** (no lo usamos).
- Al crear un componente nuevo, agregar su ruta en `app.routes.ts` y su link en `app.html` (`routerLink="/Nombre"`).
- Formatos (cards, inputs, botones): copiarlos de la página de Bootstrap.
