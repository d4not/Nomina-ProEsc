# 🧩 Componente

Volver a [[00 Inicio]]

Un **componente** es **una pieza de la pantalla** con su diseño y su comportamiento. En el proyecto, **cada catálogo es un componente**: Empleado, Categoría, Departamento, Puesto, Nivel, Unidad.

| Archivo | Qué tiene |
|---|---|
| `empleado.html` | **Lo que se ve**: card, inputs, botones |
| `empleado.ts` | **El cerebro**: variables y métodos |
| `.css` | **Estilos** propios (vacíos; se usa Bootstrap) |

```ts
@Component({
  selector: 'app-empleado',        // nombre de la etiqueta
  imports: [FormsModule],          // FormsModule = para que funcione ngModel
  templateUrl: './empleado.html',  // su html
})
export class Empleado {
  // variables y métodos
}
```

- `@Component({...})` es un **decorador**: le dice a Angular "esta clase es un componente".
- En el html: `[(ngModel)]="nombre"` conecta la caja con la variable; `(click)="Grabar()"` llama al método.

> 🧠 Si la app es una casa, cada componente es un cuarto.

Ver también: [[Servicio]] · [[Qué es un método]]
