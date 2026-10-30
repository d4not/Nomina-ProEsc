import { Injectable } from '@angular/core';
import {
  HttpClient,
  HttpHeaders,
  HttpParams
} from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class Servicioscategoria {

   Ruta="http://localhost:4200/Api/";

  constructor( private HTTP : HttpClient)
  {

  }

  Consultar(idCategoria : any)
  {
    const Controller = "Categoria";

    const Params= new HttpParams().set("id",idCategoria);

    const Headers = new HttpHeaders().set("Accept","Application/json");


   return this.HTTP.get(
      this.Ruta + Controller,
      {
        headers : Headers,
        params: Params,
        responseType: 'json'
      }
    );

  }
}
