# 🗂️ Organización del repo

Volver a [[00 Inicio]]

```
Nomina/
├── Notas/              ← estos apuntes (Obsidian)
├── node_modules/       ← librerías descargadas. NO se toca, NO se sube
├── public/             ← íconos (favicon)
├── package.json        ← librerías del proyecto y comandos (npm start)
├── angular.json        ← configuración de Angular (aquí se carga Bootstrap)
├── tsconfig*.json      ← configuración de TypeScript
├── .gitignore          ← lo que git NO sube (node_modules, dist)
└── src/                ← ⭐ AQUÍ SE TRABAJA
    ├── index.html      ← la única página real; Angular mete todo dentro de <app-root>
    ├── main.ts         ← arranque: inicia App con appConfig
    ├── styles.css      ← DISEÑO GLOBAL (ver [[Diseño CSS]])
    └── app/
        ├── app.ts / app.html   ← componente principal: menú + <router-outlet>
        ├── app.routes.ts       ← rutas: /Empleado → Empleado, etc.
        ├── app.config.ts       ← router + provideHttpClient()
        ├── Components/         ← un folder por catálogo
        └── Services/           ← un servicio por catálogo
```

## Qué pasa al abrir la app
1. El navegador abre `index.html` → tiene `<app-root>`
2. `main.ts` arranca el componente `App` con `app.config.ts`
3. `app.html` pinta el **menú** y el `<router-outlet>` (hueco para la pantalla actual)
4. Click en "Empleados" (`routerLink="/Empleado"`) → `app.routes.ts` dice qué componente va en el hueco
5. Click en un botón → componente → servicio → API ([[Cómo funciona]])
