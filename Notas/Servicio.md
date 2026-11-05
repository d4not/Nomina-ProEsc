# 🛎️ Servicio

Volver a [[00 Inicio]]

Un **servicio** es una clase que hace trabajo que **no es de pantalla**. Aquí: **hablar con la API** (el servidor con la base de datos).

¿Por qué separado? **Orden**: el componente se encarga de la pantalla, el servicio de los datos. Y se puede usar desde varios componentes.

```ts
@Injectable({ providedIn: 'root' })        // "es un servicio, disponible en toda la app"
export class Serviciosempleado {
  Ruta = "http://localhost:4200/Api/";      // dirección de la API
  constructor(private HTTP: HttpClient) { } // HttpClient = herramienta para peticiones
  Consultar(idEmpleado: any) { ... }        // get
  Grabar(Entidad: any) { ... }              // post
  Modificar(Entidad: any) { ... }           // put
  Eliminar(idEmpleado: any) { ... }         // delete
}
```

## ¿Cómo entra al componente? → inyección de dependencias
```ts
constructor(private SerEmpleado: Serviciosempleado) { }
```
= "Angular, dame un Serviciosempleado y guárdalo en `SerEmpleado`". Luego: `this.SerEmpleado.Consultar(...)`.
Para que Angular pueda dar `HttpClient` se necesita `provideHttpClient()` en `app.config.ts`.

> 🧠 El componente es el **mesero**; el servicio es el **cocinero** que va a la despensa (API).

Ver también: [[Componente]] · [[Cómo funciona]]
