# 📝 Mis notas de clase (en limpio)

Volver a [[00 Inicio]]

## Crear el componente
- `ng g c categorias` / `ng g c empleado` (dentro de `src/app/Components`)
- Borrar el `.spec`
- Copiar formatos de Bootstrap → **cards**, **form control**, **buttons**
- Correr: `ng serve`

## Empleado
Campos (form control de Bootstrap):
- id empleado
- nombre
- dirección
- RFC
- 4 botones: **Consultar, Grabar, Modificar, Eliminar**

En `empleado.ts`: variables con tipo de dato (`idEmpleado : any;` ...)
En el constructor: `private SerEmpleado : Serviciosempleado` (+ su `import`)
Botones: `(click)="Consultar()"`

## Servicio
- `ng g s ServiciosCategoria` → borrar el spec
- `constructor(private HTTP : HttpClient)`
- En `app.config.ts` → `provideHttpClient()`

```ts
Consultar(idEmpleado : any)
{
  let Controller = "Empleado";
  let Params = new HttpParams().set("id", idEmpleado);
  return this.HTTP.get(this.Ruta + Controller, { params: Params });
}
```

## Categoría
- `idCategoria : any;`
- `Nombre : any;` *(en el código quedó como `descripcion`, revisar)*
- `Entidad : any;`
- En el html: `[(ngModel)]="Nombre"`

Ver también: [[Cómo funciona]] · [[Tareas pendientes]]
