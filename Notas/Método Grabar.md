# 💾 Método Grabar (ejemplo en Categoría)

Volver a [[00 Inicio]] · Antes lee [[Qué es un método]]

Se hacen **2 métodos**: uno en el servicio y otro en el componente.

## Parte 1 — Servicio (`Servicioscategoria.ts`)
Abajo de `Consultar(...)`, **después de su `}` pero antes de la última `}` del archivo**:

```ts
  Grabar(Entidad : any)
  {
    const Controller = "Categoria";
    const Headers = new HttpHeaders().set("Accept","Application/json");

    return this.HTTP.post(
      this.Ruta + Controller,
      Entidad,
      {
        headers : Headers,
        responseType: 'json'
      }
    );
  }
```

Diferencias con Consultar:
- Recibe `Entidad` (todos los datos), no solo el id
- `.post` en vez de `.get`
- Sin `Params` → los datos van en `Entidad` como 2º parámetro

## Parte 2 — Componente (`categoria.ts`)
Abajo de `Consultar()`, antes de la última `}`:

```ts
  Grabar()
  {
    // 1. Junto lo que hay en pantalla en un solo objeto
    this.Entidad = {
      idCategoria: this.idCategoria,
      descripcion: this.descripcion,
      sueldo: this.sueldo,
      idNivel: this.idNivel
    };

    // 2. Se lo mando al servicio
    this.SerCategoria.Grabar(this.Entidad).subscribe(
      (data: any)=>{
        alert("Se grabó correctamente");
      },
      (error: any)=>{
        console.error(error);
      }
    );
  }
```

## La idea
- **Consultar**: API → variables (recibe y muestra)
- **Grabar**: variables → API (junta y manda)

## Para Empleado / Departamento cambia
- el servicio: `SerEmpleado`, `SerDepartamento`
- el `Controller`: `"Empleado"`, `"Departamento"`
- las variables dentro de `this.Entidad = { ... }`

Siguiente: [[Modificar y Eliminar]]
