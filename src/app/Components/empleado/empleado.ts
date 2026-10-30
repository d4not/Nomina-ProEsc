import { Component } from '@angular/core';
import{FormsModule} from '@angular/forms';
import { Serviciosempleado } from '../../Services/serviciosempleado';
@Component({
  selector: 'app-empleado',
  imports: [FormsModule],
  templateUrl: './empleado.html',
})
export class Empleado {
  idEmpleado:any;
  nombre : string ="";
  apellidos :string="";
  direccion:string="";
  rfc: string="";
  cp: any;

  Entidad: any;
 
  constructor(private SerEmpleado: Serviciosempleado)
  {

  }

  Consultar()
  {
    this.SerEmpleado.Consultar(this.idEmpleado).subscribe(
      (data: any)=>{
      this.Entidad=data;
      this.idEmpleado=this.Entidad.idEmpleado;
      this.nombre=this.Entidad.nombre;
      this.apellidos=this.Entidad.apellidos;
      this.direccion=this.Entidad.direccion;
      this.rfc=this.Entidad.rfc;
      this.cp=this.Entidad.cp;
      },
      (error: any)=>{
        console.error(error);
      },
      ()=>{

      }

    )
  }
}
