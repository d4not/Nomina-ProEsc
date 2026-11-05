# 🅰️ Angular y ng

Volver a [[00 Inicio]]

## Angular
- Es un **framework** (hecho por Google): herramientas + reglas ya hechas para construir **páginas web que funcionan como aplicaciones**.
- Ya resuelve: guardar lo que escribes en variables (`ngModel`), cambiar de pantalla sin recargar (rutas), pedir datos al servidor (`HttpClient`).
- Se programa en **TypeScript** (`.ts`) = JavaScript con **tipos de datos** (`nombre: string`, `idEmpleado: any`).
- Tu proyecto usa **Angular 21**.

> 🧠 Angular es como un kit de LEGO con instrucciones: piezas que ya encajan entre sí.

## ng (Angular CLI)
`ng` es el "control remoto" de Angular en la terminal. Hace el trabajo repetitivo.

| Comando | Qué hace |
|---|---|
| `ng serve` | Compila y abre la app en `http://localhost:4200`; se actualiza al guardar |
| `ng g c nombre` | **g**enera un **c**omponente (`.ts`, `.html`, `.css`, `.spec.ts`) |
| `ng g s nombre` | **g**enera un **s**ervicio |
| `ng build` | Compila la app para publicarla (carpeta `dist/`) |

El `.spec.ts` es para pruebas automáticas; en clase no se usa → se borra.

Ver también: [[Comandos]] · [[Componente]] · [[Servicio]]
