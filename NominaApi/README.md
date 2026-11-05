# NominaApi

API en ASP.NET Core (.NET 10) con base de datos SQLite para el proyecto Nómina.

## Prender
```
cd NominaApi
dotnet run
```
- API: http://localhost:5000/Api/Empleado?id=1
- Página de pruebas (Swagger): http://localhost:5000/swagger

La primera vez crea `nomina.db` con datos de ejemplo. Para empezar de cero, apaga la API y borra `nomina.db`.

Requisito: **.NET 10 SDK** (https://dotnet.microsoft.com/download).
