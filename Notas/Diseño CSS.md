# 🎨 Diseño CSS

Volver a [[00 Inicio]]

## Dónde está cada cosa
- **`src/styles.css`** → diseño de TODA la app (se carga después de Bootstrap, así que lo personaliza)
- **`Components/x/x.css`** → solo el color de cada catálogo:
  ```css
  :host { --acento: #6d28d9; }
  ```
  `:host` = "este componente". `--acento` es una **variable CSS** que `styles.css` usa para el borde, el ícono, el botón Consultar y el foco de las cajas.

| Catálogo | Color |
|---|---|
| Empleado | morado `#6d28d9` |
| Categoría | azul `#1d4ed8` |
| Departamento | rojo `#be123c` |
| Puesto | verde `#047857` |

## Secciones de styles.css
1. **Variables** (`:root`) → colores y medidas reutilizables
2. **Base** → fondo color papel con puntitos, letra *Plus Jakarta Sans*
3. **Menú** → barra oscura, línea dorada, la pantalla activa se marca en dorado (`routerLinkActive="activo"`)
4. **Página** → centra la tarjeta (máx. 720px)
5. **Tarjeta** (`.catalogo`) → borde superior de color, sombra, encabezado con iniciales
6. **Campos** → dos columnas con `display: grid`; el id ocupa toda la fila y usa letra tipo máquina
7. **Botones** → Consultar (color del catálogo), Grabar (oscuro), Modificar (blanco), Eliminar (rojo, a la derecha)
8. **Celular** (`@media`) → todo en una columna

## En el html
Se siguen usando las clases de Bootstrap (`card`, `card-header`, `form-control`, `btn`) y se agregan las propias (`catalogo`, `campo`, `boton--grabar`...). Se quitaron los `style="..."` que estaban escritos directo en el html.
