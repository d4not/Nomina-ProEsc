# 🐞 Errores comunes

Volver a [[00 Inicio]]

| Error / síntoma | Causa | Solución |
|---|---|---|
| `Property 'Grabar' does not exist` | El html llama a un método que no existe en el `.ts` | Crear el método en el componente |
| El método marca error rojo | Lo escribiste **fuera** de la clase (después de la última `}`) | Moverlo adentro |
| No pasa nada al dar click | Nombre distinto (`grabar` vs `Grabar`) | Mismo nombre exacto, mayúsculas incluidas |
| `Cannot find name 'idCategoria'` | Falta `this.` | `this.idCategoria` |
| `Can't bind to 'ngModel'` | Falta `FormsModule` | `imports: [FormsModule]` en el componente |
| `NullInjectorError: HttpClient` | Falta `provideHttpClient()` | Agregarlo en `app.config.ts` |
| No llega nada de la API | `Ruta` con puerto 4200 / API apagada | Poner el puerto de la API y encenderla |
| La petición no se hace | Falta `.subscribe(...)` | Siempre suscribirse |

💡 Para ver errores en el navegador: **F12 → Console**.
