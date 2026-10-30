import { Injectable } from '@angular/core';
import {HttpClient,HttpHeaders,HttpParams} from '@angular/common/http';
@Injectable({
  providedIn: 'root',
})
export class Serviciosdepartamento {

    Ruta="http://localhost:4200/Api/";

  constructor( private HTTP : HttpClient)
  {

  }

  Consultar(idDepartamento : any)
  {
    const Controller = "Departamento";

    const Params= new HttpParams().set("id",idDepartamento);

    const Headers = new HttpHeaders().set("Accept","Application/json");

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
