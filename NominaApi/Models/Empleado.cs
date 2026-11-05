using System.ComponentModel.DataAnnotations;

namespace NominaApi.Models;

// Tabla Empleados: cada propiedad es una columna
public class Empleado
{
    [Key]                                   // llave primaria
    public int IdEmpleado { get; set; }
    public string? Nombre { get; set; }
    public string? Apellidos { get; set; }
    public string? Direccion { get; set; }
    public string? Rfc { get; set; }
    public string? Cp { get; set; }
}
