using System.ComponentModel.DataAnnotations;

namespace NominaApi.Models;

// Tabla Categorias: cada propiedad es una columna
public class Categoria
{
    [Key]                                   // llave primaria
    public int IdCategoria { get; set; }
    public string? Descripcion { get; set; }
    public double? Sueldo { get; set; }
    public int? IdNivel { get; set; }
}
