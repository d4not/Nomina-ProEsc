# ⚙️ Cómo funciona

Volver a [[00 Inicio]]

Cuando aprietas un botón pasan 4 cosas en cadena:

```
[ .html ]  →  [ componente .ts ]  →  [ servicio .ts ]  →  [ API / base de datos ]
  botón        método Grabar()        método Grabar()       guarda el registro
 (click)       junta los datos        hace la petición
```

## Las 3 piezas
- **`.html`** → lo que se ve: inputs y botones.
  - `[(ngModel)]="descripcion"` conecta un input con una variable del `.ts`. Lo que escribes se guarda solo en esa variable (y al revés).
  - `(click)="Grabar()"` → al dar click ejecuta el método `Grabar()` del `.ts`.
- **componente `.ts`** (ej. `categoria.ts`) → guarda las variables y los métodos que llaman los botones.
- **servicio `.ts`** (ej. `Servicioscategoria.ts`) → el único que habla con la API (usa `HttpClient`).

## Para que funcione necesitas
- `provideHttpClient()` en `app.config.ts` ✅ (ya está)
- `imports: [FormsModule]` en el componente → sin esto `[(ngModel)]` no funciona
- El servicio en el constructor del componente:
  `constructor(private SerCategoria: Servicioscategoria) { }`

## Verbos HTTP
| Botón | Verbo | Significa |
|---|---|---|
| Consultar | `get` | traer |
| Grabar | `post` | crear nuevo |
| Modificar | `put` | actualizar existente |
| Eliminar | `delete` | borrar |

Siguiente: [[Qué es un método]]
