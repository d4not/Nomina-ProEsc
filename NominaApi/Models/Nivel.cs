using System.ComponentModel.DataAnnotations;

namespace NominaApi.Models;

// Tabla Niveles: cada propiedad es una columna
public class Nivel
{
    [Key]                                   // llave primaria
    public int IdNivel { get; set; }
    public string? Descripcion { get; set; }
}
