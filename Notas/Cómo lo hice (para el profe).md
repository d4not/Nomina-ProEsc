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

## 5. Diseño → [[Diseño CSS]]

## 6. Limpieza
- Se borraron `departamento.spec.ts` y `puesto.spec.ts`.

## 7. Cómo se probó
- `ng build` → compila sin errores.
- Se abrió en el navegador con una API de prueba y se revisó que cada botón hiciera su petición:
  `GET /Api/Puesto?id=7` · `POST /Api/Puesto` · `PUT /Api/Puesto` · `DELETE /Api/Puesto?id=7`
