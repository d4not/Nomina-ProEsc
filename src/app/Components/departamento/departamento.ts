import { Component, ChangeDetectorRef } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Serviciosdepartamento } from '../../Services/Serviciosdepartamento';

@Component({
  selector: 'app-departamento',
  imports: [FormsModule],
  templateUrl: './departamento.html',
  styleUrl: './departamento.css',
})
export class Departamento {
  idDepartamento : any;
  descripcion : string = "";
  idUnidad : any;

  Entidad : any;

  // Pantalla: sirve para avisarle a Angular que vuelva a dibujar las cajas
  constructor(private SerDepartamento : Serviciosdepartamento, private Pantalla : ChangeDetectorRef)
  {

  }

  // Trae el registro del id escrito y lo pone en las cajas
  Consultar()
  {
    this.SerDepartamento.Consultar(this.idDepartamento).subscribe(
      (data: any) => {
        this.Entidad = data;
        this.idDepartamento = this.Entidad.idDepartamento;
        this.descripcion = this.Entidad.descripcion;
        this.idUnidad = this.Entidad.idUnidad;
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
      idDepartamento: this.idDepartamento,
      descripcion: this.descripcion,
      idUnidad: this.idUnidad
    };

    this.SerDepartamento.Grabar(this.Entidad).subscribe(
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
      idDepartamento: this.idDepartamento,
      descripcion: this.descripcion,
      idUnidad: this.idUnidad
    };

    this.SerDepartamento.Modificar(this.Entidad).subscribe(
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
    this.SerDepartamento.Eliminar(this.idDepartamento).subscribe(
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
    this.idDepartamento = null;
    this.descripcion = "";
    this.idUnidad = null;
    this.Pantalla.markForCheck();
  }
}
