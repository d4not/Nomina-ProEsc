import { Component } from '@angular/core';
import{FormsModule} from '@angular/forms';
import { Servicioscategoria } from '../../Services/Servicioscategoria'
@Component({
  selector: 'app-categoria',
  imports: [FormsModule],
  templateUrl: './categoria.html',
})
export class Categoria {
idCategoria : any;
descripcion: string="";
sueldo : any;
idNivel : any;

 Entidad: any;
 
  constructor(private SerCategoria: Servicioscategoria)  
  {

  }

  Consultar()
  {
    this.SerCategoria.Consultar(this.idCategoria).subscribe(
      (data: any)=>{
        this.Entidad=data;
        this.idCategoria=this.Entidad.idCategoria;
        this.descripcion=this.Entidad.descripcion;
        this.sueldo=this.Entidad.sueldo;
        this.idNivel=this.Entidad.idNivel;
      },
      (error: any)=>{

      },
      ()=>{

      }

    )
  }
}
