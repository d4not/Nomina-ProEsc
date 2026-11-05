using System.ComponentModel.DataAnnotations;

namespace NominaApi.Models;

// Tabla Departamentos: cada propiedad es una columna
public class Departamento
{
    [Key]                                   // llave primaria
    public int IdDepartamento { get; set; }
    public string? Descripcion { get; set; }
    public int? IdUnidad { get; set; }
}
