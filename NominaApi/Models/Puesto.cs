using System.ComponentModel.DataAnnotations;

namespace NominaApi.Models;

// Tabla Puestos: cada propiedad es una columna
public class Puesto
{
    [Key]                                   // llave primaria
    public int IdPuesto { get; set; }
    public string? Descripcion { get; set; }
    public int? IdDepartamento { get; set; }
}
