# 🧩 Qué es un método

Volver a [[00 Inicio]] · Ver también [[Cómo funciona]]

Un **método** es un bloque de código con nombre que se ejecuta cuando lo llamas.
`(click)="Grabar()"` = *"cuando den click, ejecuta el método llamado Grabar"*. Por eso debe existir en el `.ts` con **el mismo nombre exacto**.

Forma general:
```ts
NombreDelMetodo()
{
  // lo que hace va aquí adentro
}
```

Los métodos van **dentro de la clase**, o sea dentro de las llaves de `export class Categoria { ... }`.

## Ejemplo: Consultar() de categoria.ts, explicado
```ts
Consultar()                                      // ← nombre del método
{
  this.SerCategoria.Consultar(this.idCategoria)  // ← llama al SERVICIO y le pasa el id escrito
    .subscribe(                                  // ← "espera la respuesta de la API y luego..."
      (data: any)=>{                             // ← ...si salió bien, la respuesta llega en "data"
        this.Entidad=data;
        this.descripcion=this.Entidad.descripcion; // ← pasa cada dato a su variable → se ve en pantalla
      },
      (error: any)=>{                            // ← ...si salió mal, entra aquí
        console.error(error);
      }
    )
}
```

## Palabras clave
- **`this.`** → "de esta clase". Para variables (`this.idCategoria`) y para el servicio (`this.SerCategoria`).
- **`.subscribe(...)`** → la API tarda en contestar; subscribe espera la respuesta. **Sin subscribe la petición ni se manda.**
- **parámetro** → lo que va entre paréntesis: `Consultar(idCategoria : any)` recibe un id.
- **`return`** → en el servicio, regresa la petición al componente para que haga `.subscribe`.

Siguiente: [[Método Grabar]]
