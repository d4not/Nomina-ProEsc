# 🗄️ API y base de datos

Volver a [[00 Inicio]] · Ver también [[Cómo funciona]]

## Qué es
- **API** (`NominaApi/`): programa en **C# con ASP.NET Core** que recibe las peticiones de Angular y lee/escribe la base de datos.
- **Base de datos**: **SQLite**, un solo archivo `NominaApi/nomina.db`. No hay que instalar un servidor de base de datos.
- Angular (puerto **4200**) → API (puerto **5000**) → `nomina.db`

```
[ Angular :4200 ]  --HTTP-->  [ API :5000 ]  --EF Core-->  [ nomina.db ]
  servicio .ts                 Controller                     tablas
```

## Cómo prenderlo (2 terminales)
1. Instalar una vez el **.NET 10 SDK**: https://dotnet.microsoft.com/download
2. Terminal 1 → la API:
   ```
   cd NominaApi
   dotnet run
   ```
   Se abre **http://localhost:5000/swagger** (página para probar la API sin Angular).
3. Terminal 2 → Angular:
   ```
   npm start
   ```
   Abrir **http://localhost:4200**
4. Probar: en Empleados escribe id `1` → **Consultar** → sale *Ana López Ruiz*.

Apagar: `Ctrl + C` en cada terminal.
Empezar de cero la base: apagar la API y borrar `NominaApi/nomina.db` (se vuelve a crear con datos de ejemplo).

## Carpetas de la API
```
NominaApi/
├── Program.cs              ← arranque: controllers, SQLite, CORS, Swagger
├── appsettings.json        ← "cadena de conexión": Data Source=nomina.db
├── Properties/launchSettings.json ← el puerto 5000
├── Models/                 ← una clase por tabla (Empleado.cs, Categoria.cs, ...)
├── Data/
│   ├── NominaContext.cs    ← el puente C# ↔ base de datos (cada DbSet = una tabla)
│   └── DatosEjemplo.cs     ← crea la base la primera vez y mete datos de prueba
├── Controllers/            ← un controller por catálogo (EmpleadoController.cs, ...)
└── Utilidades/NumeroFlexible.cs ← convierte el texto de las cajas ("7") a número
```

## Rutas (lo que llama cada botón)
| Botón | Angular (servicio) | API |
|---|---|---|
| Consultar | `this.HTTP.get(Ruta + "Empleado", {params: id})` | `GET /Api/Empleado?id=1` |
| Grabar | `this.HTTP.post(Ruta + "Empleado", Entidad)` | `POST /Api/Empleado` |
| Modificar | `this.HTTP.put(Ruta + "Empleado", Entidad)` | `PUT /Api/Empleado` |
| Eliminar | `this.HTTP.delete(Ruta + "Empleado", {params: id})` | `DELETE /Api/Empleado?id=1` |
| *(extra)* | — | `GET /Api/Empleado/Todos` (lista todo) |

Igual para `Categoria`, `Departamento`, `Puesto`, `Nivel`, `Unidad`.
En Angular la `Ruta` de los servicios es `http://localhost:5000/Api/`.

## Tablas
| Tabla | Columnas |
|---|---|
| Empleado | idEmpleado, nombre, apellidos, direccion, rfc, cp |
| Categoria | idCategoria, descripcion, sueldo, idNivel |
| Departamento | idDepartamento, descripcion, idUnidad |
| Puesto | idPuesto, descripcion, idDepartamento |
| Nivel | idNivel, descripcion |
| Unidad | idUnidad, descripcion |

Datos de ejemplo: ids **1, 2 y 3** en cada tabla.

## Un controller explicado (EmpleadoController.cs)
```csharp
[ApiController]
[Route("Api/[controller]")]          // [controller] = "Empleado" → /Api/Empleado
public class EmpleadoController : ControllerBase
{
    private readonly NominaContext BD;
    public EmpleadoController(NominaContext bd) { BD = bd; }   // inyección, igual que en Angular

    [HttpGet]                         // GET /Api/Empleado?id=1
    public IActionResult Consultar(int id)
    {
        var empleado = BD.Empleados.Find(id);        // busca por llave primaria
        if (empleado == null) return NotFound();     // 404 → Angular: "No se pudo consultar"
        return Ok(empleado);                         // 200 + JSON → Angular llena las cajas
    }
    // [HttpPost] Grabar  → BD.Empleados.Add(...)  + BD.SaveChanges()
    // [HttpPut] Modificar → cambia los valores     + BD.SaveChanges()
    // [HttpDelete] Eliminar → BD.Empleados.Remove(...) + BD.SaveChanges()
}
```

## Conceptos
- **Controller**: clase que responde a una ruta. Cada método con `[HttpGet]`, `[HttpPost]`... es una operación.
- **Model**: clase con las columnas de una tabla.
- **Entity Framework Core (EF Core)**: librería que traduce C# a SQL. `Find`, `Add`, `Remove`, `SaveChanges` en vez de escribir `SELECT`, `INSERT`, `DELETE`.
- **CORS**: permiso para que una página en el puerto 4200 pueda llamar a la API en el 5000. Sin él, el navegador bloquea la petición.
- **JSON**: el formato de los datos: `{"idEmpleado":1,"nombre":"Ana"}`. C# usa `IdEmpleado` y lo manda como `idEmpleado`.
- **Códigos de respuesta**: 200 OK · 404 no existe · 409 ya existe (Grabar con un id repetido).
- **Swagger**: página automática para probar la API desde el navegador.
