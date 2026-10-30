import { Component } from '@angular/core';
import{FormsModule} from '@angular/forms';
import { Serviciosdepartamento } from '../../Services/Serviciosdepartamento'
@Component({
  selector: 'app-departamento',
  imports: [FormsModule],
  templateUrl: './departamento.html',
})
export class Departamento {
  idDepartamento : any;
  descripcion:string="";
  idUnidad:any;

   Entidad: any;
 
  constructor(private SerDepartamento: Serviciosdepartamento)
  {

  }

  Consultar()
  {
    this.SerDepartamento.Consultar(this.idDepartamento).subscribe(
      (data: any)=>{
        this.Entidad=data;
        this.idDepartamento=this.Entidad.idDepartamento;
        this.descripcion=this.Entidad.descripcion;
        this.idUnidad=this.Entidad.idUnidad;
      },
      (error: any)=>{

      },
      ()=>{

      }

    )
  }
}
