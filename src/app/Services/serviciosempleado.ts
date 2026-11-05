import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class Serviciosempleado {

  Ruta = "http://localhost:5000/Api/";

  constructor(private HTTP : HttpClient)
  {

  }

  // Consultar: trae UN registro por su id (GET)
  Consultar(idEmpleado : any)
  {
    let Controller = "Empleado";
    let Params = new HttpParams().set("id", idEmpleado);
    let Headers = new HttpHeaders().set("Accept", "Application/json");

    return this.HTTP.get(
      this.Ruta + Controller,
      {
        headers: Headers,
        params: Params,
        responseType: 'json'
      }
    );
  }

  // Grabar: crea un registro NUEVO (POST). Los datos van en Entidad
  Grabar(Entidad : any)
  {
    let Controller = "Empleado";
    let Headers = new HttpHeaders().set("Accept", "Application/json");

    return this.HTTP.post(
      this.Ruta + Controller,
      Entidad,
      {
        headers: Headers,
        responseType: 'json'
      }
    );
  }

  // Modificar: actualiza un registro que YA existe (PUT)
  Modificar(Entidad : any)
  {
    let Controller = "Empleado";
    let Headers = new HttpHeaders().set("Accept", "Application/json");

    return this.HTTP.put(
      this.Ruta + Controller,
      Entidad,
      {
        headers: Headers,
        responseType: 'json'
      }
    );
  }

  // Eliminar: borra un registro por su id (DELETE)
  Eliminar(idEmpleado : any)
  {
    let Controller = "Empleado";
    let Params = new HttpParams().set("id", idEmpleado);
    let Headers = new HttpHeaders().set("Accept", "Application/json");

    return this.HTTP.delete(
      this.Ruta + Controller,
      {
        headers: Headers,
        params: Params,
        responseType: 'json'
      }
    );
  }
}
