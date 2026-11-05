import { Component, ChangeDetectorRef } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Servicioscategoria } from '../../Services/Servicioscategoria';

@Component({
  selector: 'app-categoria',
  imports: [FormsModule],
  templateUrl: './categoria.html',
  styleUrl: './categoria.css',
})
export class Categoria {
  idCategoria : any;
  descripcion : string = "";
  sueldo : any;
  idNivel : any;

  Entidad : any;

  // Pantalla: sirve para avisarle a Angular que vuelva a dibujar las cajas
  constructor(private SerCategoria : Servicioscategoria, private Pantalla : ChangeDetectorRef)
  {

  }

  // Trae el registro del id escrito y lo pone en las cajas
  Consultar()
  {
    this.SerCategoria.Consultar(this.idCategoria).subscribe(
      (data: any) => {
        this.Entidad = data;
        this.idCategoria = this.Entidad.idCategoria;
        this.descripcion = this.Entidad.descripcion;
        this.sueldo = this.Entidad.sueldo;
        this.idNivel = this.Entidad.idNivel;
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
      idCategoria: this.idCategoria,
      descripcion: this.descripcion,
      sueldo: this.sueldo,
      idNivel: this.idNivel
    };

    this.SerCategoria.Grabar(this.Entidad).subscribe(
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
      idCategoria: this.idCategoria,
      descripcion: this.descripcion,
      sueldo: this.sueldo,
      idNivel: this.idNivel
    };

    this.SerCategoria.Modificar(this.Entidad).subscribe(
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
    this.SerCategoria.Eliminar(this.idCategoria).subscribe(
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
    this.idCategoria = null;
    this.descripcion = "";
    this.sueldo = null;
    this.idNivel = null;
    this.Pantalla.markForCheck();
  }
}
