import { Routes } from '@angular/router';
import { Empleado } from './Components/empleado/empleado';
import { Categoria } from './Components/categoria/categoria';
import { Departamento } from './Components/departamento/departamento';
import { Puesto } from './Components/puesto/puesto';
import { Nivel } from './Components/nivel/nivel';
import { Unidad } from './Components/unidad/unidad';

export const routes: Routes = [
  { path: 'Empleado', component: Empleado },
  { path: 'Categoria', component: Categoria },
  { path: 'Departamento', component: Departamento },
  { path: 'Puesto', component: Puesto },
  { path: 'Nivel', component: Nivel },
  { path: 'Unidad', component: Unidad },
];