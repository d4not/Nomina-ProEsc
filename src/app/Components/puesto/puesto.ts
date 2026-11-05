import { Component, ChangeDetectorRef } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Serviciospuesto } from '../../Services/serviciospuesto';

@Component({
  selector: 'app-puesto',
  imports: [FormsModule],
  templateUrl: './puesto.html',
  styleUrl: './puesto.css',
})
export class Puesto {
  idPuesto : any;
  descripcion : string = "";
  idDepartamento : any;

  Entidad : any;

  // Pantalla: sirve para avisarle a Angular que vuelva a dibujar las cajas
  constructor(private SerPuesto : Serviciospuesto, private Pantalla : ChangeDetectorRef)
  {

  }

  // Trae el registro del id escrito y lo pone en las cajas
  Consultar()
  {
    this.SerPuesto.Consultar(this.idPuesto).subscribe(
      (data: any) => {
        this.Entidad = data;
        this.idPuesto = this.Entidad.idPuesto;
        this.descripcion = this.Entidad.descripcion;
        this.idDepartamento = this.Entidad.idDepartamento;
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
      idPuesto: this.idPuesto,
      descripcion: this.descripcion,
      idDepartamento: this.idDepartamento
    };

    this.SerPuesto.Grabar(this.Entidad).subscribe(
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
      idPuesto: this.idPuesto,
      descripcion: this.descripcion,
      idDepartamento: this.idDepartamento
    };

    this.SerPuesto.Modificar(this.Entidad).subscribe(
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
    this.SerPuesto.Eliminar(this.idPuesto).subscribe(
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
    this.idPuesto = null;
    this.descripcion = "";
    this.idDepartamento = null;
    this.Pantalla.markForCheck();
  }
}
