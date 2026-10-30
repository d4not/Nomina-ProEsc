# ✅ Tareas pendientes

Volver a [[00 Inicio]]

## Empleado
- [ ] Poner `(click)` en Grabar, Eliminar y Modificar (`empleado.html`)
- [ ] Crear `Grabar()`, `Modificar()`, `Eliminar()` en `serviciosempleado.ts`
- [ ] Crear `Grabar()`, `Modificar()`, `Eliminar()` en `empleado.ts`
- [ ] Borrar `empleado.spec.ts`

## Categoría
- [x] Poner `(click)` en los 4 botones
- [ ] Crear los 3 métodos en `Servicioscategoria.ts`
- [ ] Crear los 3 métodos en `categoria.ts`
- [ ] Decidir si el campo es `Nombre` (notas) o `descripcion` (código)
- [ ] Borrar `categoria.spec.ts`

> ⚠️ Mientras no existan los métodos en `categoria.ts`, `ng serve` marca error *"Property 'Grabar' does not exist"*. Es normal.

## Departamento
- [ ] Poner `(click)` en Grabar, Eliminar y Modificar
- [ ] Crear los 3 métodos en `Serviciosdepartamento.ts`
- [ ] Crear los 3 métodos en `departamento.ts`
- [ ] Borrar `departamento.spec.ts`

## Puesto → ver [[Puesto desde cero]]
- [x] Hacer la card en `puesto.html`
- [ ] Corregir `[(ngModel)]`: usar `idPuesto`, `descripcion`, `idDepartamento` (tiene los de Departamento copiados)
- [ ] Poner `(click)` en Grabar, Eliminar y Modificar
- [ ] Llenar `serviciospuesto.ts` (está vacío)
- [ ] Llenar `puesto.ts` (está vacío)
- [ ] Borrar `puesto.spec.ts`

## Todos los servicios
- [ ] Cambiar el puerto de `Ruta` (`http://localhost:4200/Api/`) por el de la API — 4200 es el de Angular
- [ ] Preguntar al profe si la API usa POST / PUT / DELETE
