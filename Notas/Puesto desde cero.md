# 🧱 Puesto desde cero

Volver a [[00 Inicio]] · Plantilla: **Departamento** (es el más parecido)

Campos: `idPuesto`, `descripcion`, `idDepartamento` *(confirmar con la tabla)*

## 1. `serviciospuesto.ts` (está vacío)
Copiar la estructura de `Serviciosdepartamento.ts`:
- [ ] `import` de `HttpClient, HttpHeaders, HttpParams`
- [ ] `Ruta = "http://localhost:XXXX/Api/";`
- [ ] `constructor(private HTTP : HttpClient) { }`
- [ ] Métodos con `Controller = "Puesto"` e `idPuesto`

## 2. `puesto.ts` (está vacío)
Copiar la estructura de `departamento.ts`:
- [ ] `import { FormsModule } from '@angular/forms';` y `imports: [FormsModule]`
- [ ] `import { Serviciospuesto } from '../../Services/serviciospuesto';`
- [ ] Variables: `idPuesto`, `descripcion`, `idDepartamento`, `Entidad`
- [ ] `constructor(private SerPuesto: Serviciospuesto) { }`
- [ ] Los 4 métodos

## 3. `puesto.html`
- [ ] Cambiar `[(ngModel)]="idDepartamento"` (Id puesto) → `idPuesto`
- [ ] Cambiar `[(ngModel)]="idUnidad"` (Id departamento) → `idDepartamento`
- [ ] `(click)` en Grabar, Eliminar, Modificar
