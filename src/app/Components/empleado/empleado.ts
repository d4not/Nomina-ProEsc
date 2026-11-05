import { Component, ChangeDetectorRef } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Serviciosempleado } from '../../Services/serviciosempleado';

@Component({
  selector: 'app-empleado',
  imports: [FormsModule],
  templateUrl: './empleado.html',
  styleUrl: './empleado.css',
})
export class Empleado {
  idEmpleado : any;
  nombre : string = "";
  apellidos : string = "";
  direccion : string = "";
  rfc : string = "";
  cp : any;

  Entidad : any;

  // Pantalla: sirve para avisarle a Angular que vuelva a dibujar las cajas
  constructor(private SerEmpleado : Serviciosempleado, private Pantalla : ChangeDetectorRef)
  {

  }

  // Trae el registro del id escrito y lo pone en las cajas
  Consultar()
  {
    this.SerEmpleado.Consultar(this.idEmpleado).subscribe(
      (data: any) => {
        this.Entidad = data;
        this.idEmpleado = this.Entidad.idEmpleado;
        this.nombre = this.Entidad.nombre;
        this.apellidos = this.Entidad.apellidos;
        this.direccion = this.Entidad.direccion;
        this.rfc = this.Entidad.rfc;
        this.cp = this.Entidad.cp;
        this.Pantalla.markForCheck();   // muestra los datos en las cajas
      },
      (error: any) => {
        console.error(error);
        alert("No se pudo consultar");
      }
    );
  }

  // Junta lo que hay en las cajas y lo manda como registro NUEVO
  Grabar()
  {
    this.Entidad = {
      idEmpleado: this.idEmpleado,
      nombre: this.nombre,
      apellidos: this.apellidos,
      direccion: this.direccion,
      rfc: this.rfc,
      cp: this.cp
    };

    this.SerEmpleado.Grabar(this.Entidad).subscribe(
      (data: any) => {
        alert("Se grabó correctamente");
      },
      (error: any) => {
        console.error(error);
        alert("No se pudo grabar");
      }
    );
  }

  // Igual que Grabar, pero actualiza un registro que ya existe
  Modificar()
  {
    this.Entidad = {
      idEmpleado: this.idEmpleado,
      nombre: this.nombre,
      apellidos: this.apellidos,
      direccion: this.direccion,
      rfc: this.rfc,
      cp: this.cp
    };

    this.SerEmpleado.Modificar(this.Entidad).subscribe(
      (data: any) => {
        alert("Se modificó correctamente");
      },
      (error: any) => {
        console.error(error);
        alert("No se pudo modificar");
      }
    );
  }

  // Borra el registro del id escrito y limpia las cajas
  Eliminar()
  {
    this.SerEmpleado.Eliminar(this.idEmpleado).subscribe(
      (data: any) => {
        alert("Se eliminó correctamente");
        this.Limpiar();
      },
      (error: any) => {
        console.error(error);
        alert("No se pudo eliminar");
      }
    );
  }

  // Deja todas las cajas vacías
  Limpiar()
  {
    this.idEmpleado = null;
    this.nombre = "";
    this.apellidos = "";
    this.direccion = "";
    this.rfc = "";
    this.cp = null;
    this.Pantalla.markForCheck();
  }
}
