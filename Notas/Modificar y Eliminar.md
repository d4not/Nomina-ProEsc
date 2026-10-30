# ✏️🗑️ Modificar y Eliminar

Volver a [[00 Inicio]] · Basado en [[Método Grabar]]

## Modificar
Igual que [[Método Grabar]]:
- Copia los 2 métodos y renómbralos `Modificar`
- En el servicio usa **`.put`** en lugar de `.post`
- Cambia el mensaje: `alert("Se modificó")`

## Eliminar
Se parece a **Consultar** (solo necesita el id):
- Servicio: copia `Consultar(...)`, renómbralo `Eliminar` y usa **`.delete`** en vez de `.get`
- Componente: `this.SerCategoria.Eliminar(this.idCategoria).subscribe(...)` con `alert("Eliminado")`
- Opcional: después de eliminar, limpiar las cajas (`this.descripcion = "";` etc.)

> Confirmar con el profe que la API usa POST / PUT / DELETE.
