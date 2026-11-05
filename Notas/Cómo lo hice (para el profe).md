# 🧑‍🏫 Cómo lo hice (para explicar al profe)

Volver a [[00 Inicio]]

## 1. Servicios (`Services/`)
A cada servicio (Empleado, Categoría, Departamento, Puesto) le agregué, junto a `Consultar`:
- `Grabar(Entidad)` → `this.HTTP.post(Ruta + Controller, Entidad)` — crea
- `Modificar(Entidad)` → `this.HTTP.put(Ruta + Controller, Entidad)` — actualiza
- `Eliminar(id)` → `this.HTTP.delete(Ruta + Controller, { params })` — borra

`serviciospuesto.ts` estaba vacío: le puse `HttpClient` en el constructor, la `Ruta` y los 4 métodos.

## 2. Componentes (`.ts`)
En cada componente:
- `Grabar()` y `Modificar()`: juntan las variables en `this.Entidad = {...}` y llaman al servicio con `.subscribe(...)`. Si sale bien → `alert`; si no → `console.error` + `alert`.
- `Eliminar()`: manda solo el id y luego `Limpiar()` deja las cajas vacías.
- `puesto.ts` estaba vacío: se le puso `FormsModule`, variables, constructor con el servicio y los métodos.

## 3. HTML
- `(click)="Grabar()"`, `(click)="Modificar()"`, `(click)="Eliminar()"` en los botones.
- En Puesto se corrigieron los `[(ngModel)]` (tenían los de Departamento).
- Cada input tiene su propio `id` (todos se llamaban `exampleFormControlInput1`).

## 4. Problema que se arregló: Consultar no mostraba datos
Angular 21 es **zoneless**: ya no redibuja la pantalla solo cuando llega la respuesta de la API. Las variables sí cambiaban, pero las cajas no.
Solución: pedir `ChangeDetectorRef` en el constructor y avisar:
```ts
constructor(private SerPuesto : Serviciospuesto, private Pantalla : ChangeDetectorRef) { }
...
this.Pantalla.markForCheck();   // "Angular, vuelve a dibujar"
```

## 5. Diseño
Se mantuvo el diseño original con Bootstrap (card, form-control, botones de colores). Cambios: el `id` de cada input, el menú en azul marino (`#1f2a44`) y los títulos sin franja de fondo, solo con el texto de color: Empleado verde azulado `#0f766e`, Categoría ámbar `#b45309`, Departamento morado `#7c3aed`, Puesto rosa `#be185d` (en el `style` de cada `<h5>`).

## 6. Limpieza
- Se borraron `departamento.spec.ts` y `puesto.spec.ts`.

## 7. Cómo se probó
- `ng build` → compila sin errores.
- Se abrió en el navegador con una API de prueba y se revisó que cada botón hiciera su petición:
  `GET /Api/Puesto?id=7` · `POST /Api/Puesto` · `PUT /Api/Puesto` · `DELETE /Api/Puesto?id=7`

## 8. API y base de datos → [[API y base de datos]]
1. Se creó el proyecto con `dotnet new webapi --use-controllers -n NominaApi`.
2. Se agregaron los paquetes `Microsoft.EntityFrameworkCore.Sqlite` (base de datos) y `Swashbuckle.AspNetCore` (Swagger).
3. **Models**: una clase por tabla con `[Key]` en el id.
4. **NominaContext**: un `DbSet` por tabla; la base es el archivo `nomina.db`.
5. **Controllers**: uno por catálogo con `[Route("Api/[controller]")]` y los métodos Consultar (GET), Grabar (POST), Modificar (PUT) y Eliminar (DELETE), con los mismos nombres y rutas que ya usaba Angular.
6. **Program.cs**: registra los controllers, SQLite, **CORS** para `localhost:4200` y Swagger. Al arrancar crea la base con datos de ejemplo.
7. En Angular solo cambió la `Ruta` de los servicios a `http://localhost:5000/Api/`.
8. Se probó todo junto: en los 4 catálogos Consultar trae el id 1, Grabar crea el id 50, Modificar lo cambia y Eliminar lo borra.

