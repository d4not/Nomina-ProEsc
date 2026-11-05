using System.ComponentModel.DataAnnotations;

namespace NominaApi.Models;

// Tabla Unidades: cada propiedad es una columna
public class Unidad
{
    [Key]                                   // llave primaria
    public int IdUnidad { get; set; }
    public string? Descripcion { get; set; }
}
