# 🏠 Proyecto Nómina — Inicio

Apuntes del proyecto en Angular. Empieza por aquí.

## Notas
- [[Tareas pendientes]] — lo que falta hacer (con casillas para palomear)
- [[Cómo funciona]] — html → componente → servicio → API
- [[Qué es un método]] — explicado con `Consultar()`
- [[Método Grabar]] — ejemplo paso a paso
- [[Modificar y Eliminar]]
- [[Puesto desde cero]]
- [[Errores comunes]]
- [[Comandos]]
- [[Mis notas de clase]] — lo que anoté en clase, en limpio

## Estructura del proyecto
```
src/app/
├── app.config.ts      ← aquí va provideHttpClient()
├── app.routes.ts      ← las rutas (/Empleado, /Categoria, ...)
├── app.html           ← el menú (navbar)
├── Components/
│   ├── empleado/      (empleado.ts + empleado.html)
│   ├── categoria/
│   ├── departamento/
│   ├── puesto/
│   ├── nivel/
│   └── unidad/
└── Services/
    ├── serviciosempleado.ts
    ├── Servicioscategoria.ts
    ├── Serviciosdepartamento.ts
    └── serviciospuesto.ts ...
```
