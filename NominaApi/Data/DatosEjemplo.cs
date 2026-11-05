using NominaApi.Models;

namespace NominaApi.Data;

// Crea la base de datos la primera vez y le pone algunos registros para probar
public static class DatosEjemplo
{
    public static void Cargar(NominaContext bd)
    {
        bd.Database.EnsureCreated();          // crea nomina.db y las tablas si no existen

        if (bd.Empleados.Any()) return;       // si ya hay datos, no hace nada

        bd.Niveles.AddRange(
            new Nivel { IdNivel = 1, Descripcion = "Operativo" },
            new Nivel { IdNivel = 2, Descripcion = "Mando medio" },
            new Nivel { IdNivel = 3, Descripcion = "Directivo" });

        bd.Unidades.AddRange(
            new Unidad { IdUnidad = 1, Descripcion = "Oficinas centrales" },
            new Unidad { IdUnidad = 2, Descripcion = "Planta" });

        bd.Categorias.AddRange(
            new Categoria { IdCategoria = 1, Descripcion = "Auxiliar", Sueldo = 9500, IdNivel = 1 },
            new Categoria { IdCategoria = 2, Descripcion = "Supervisor", Sueldo = 18000, IdNivel = 2 },
            new Categoria { IdCategoria = 3, Descripcion = "Gerente", Sueldo = 35000, IdNivel = 3 });

        bd.Departamentos.AddRange(
            new Departamento { IdDepartamento = 1, Descripcion = "Recursos Humanos", IdUnidad = 1 },
            new Departamento { IdDepartamento = 2, Descripcion = "Contabilidad", IdUnidad = 1 },
            new Departamento { IdDepartamento = 3, Descripcion = "Producción", IdUnidad = 2 });

        bd.Puestos.AddRange(
            new Puesto { IdPuesto = 1, Descripcion = "Reclutador", IdDepartamento = 1 },
            new Puesto { IdPuesto = 2, Descripcion = "Contador", IdDepartamento = 2 },
            new Puesto { IdPuesto = 3, Descripcion = "Operador", IdDepartamento = 3 });

        bd.Empleados.AddRange(
            new Empleado { IdEmpleado = 1, Nombre = "Ana", Apellidos = "López Ruiz", Direccion = "Av. Juárez 120", Rfc = "LORA900101AB1", Cp = "82000" },
            new Empleado { IdEmpleado = 2, Nombre = "Carlos", Apellidos = "Méndez Soto", Direccion = "Calle Ángel Flores 45", Rfc = "MESC880512CD2", Cp = "82100" },
            new Empleado { IdEmpleado = 3, Nombre = "María", Apellidos = "García Peña", Direccion = "Blvd. Del Mar 300", Rfc = "GAPM950823EF3", Cp = "82110" });

        bd.SaveChanges();
    }
}
