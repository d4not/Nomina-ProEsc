import { Injectable } from '@angular/core';
import {HttpClient,HttpHeaders,HttpParams} from '@angular/common/http';
@Injectable({
  providedIn: 'root',
})
export class Serviciosempleado {
  Ruta="http://localhost:4200/Api/";

  constructor( private HTTP : HttpClient)
  {

  }

  Consultar(idEmpleado : any)
  {
    let Controller = "Empleado" 

    let Params= new HttpParams().set("id",idEmpleado);

    let Headers = new HttpHeaders().set("Accept","Application/json");


   return this.HTTP.get(
      this.Ruta + Controller,
      {
        headers: Headers,
        params: Params,
        responseType: 'json'
      }
    );
  }
}
