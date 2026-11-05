using Microsoft.AspNetCore.Mvc;
using NominaApi.Data;
using NominaApi.Models;

namespace NominaApi.Controllers;

// Responde en http://localhost:5000/Api/Empleado
[ApiController]
[Route("Api/[controller]")]
public class EmpleadoController : ControllerBase
{
    private readonly NominaContext BD;

    // ASP.NET nos da la conexión a la base de datos (igual que Angular da el HttpClient)
    public EmpleadoController(NominaContext bd)
    {
        BD = bd;
    }

    // CONSULTAR  →  GET /Api/Empleado?id=1
    [HttpGet]
    public IActionResult Consultar(int id)
    {
        var empleado = BD.Empleados.Find(id);
        if (empleado == null)
            return NotFound(new { mensaje = "No existe el registro " + id });
        return Ok(empleado);
    }

    // LISTAR  →  GET /Api/Empleado/Todos
    [HttpGet("Todos")]
    public IActionResult Todos()
    {
        return Ok(BD.Empleados.ToList());
    }

    // GRABAR  →  POST /Api/Empleado   (los datos van en el body)
    [HttpPost]
    public IActionResult Grabar([FromBody] Empleado empleado)
    {
        if (empleado.IdEmpleado != 0 && BD.Empleados.Find(empleado.IdEmpleado) != null)
            return Conflict(new { mensaje = "Ya existe el registro " + empleado.IdEmpleado });

        BD.Empleados.Add(empleado);
        BD.SaveChanges();
        return Ok(empleado);
    }

    // MODIFICAR  →  PUT /Api/Empleado   (los datos van en el body)
    [HttpPut]
    public IActionResult Modificar([FromBody] Empleado empleado)
    {
        var existe = BD.Empleados.Find(empleado.IdEmpleado);
        if (existe == null)
            return NotFound(new { mensaje = "No existe el registro " + empleado.IdEmpleado });

        BD.Entry(existe).CurrentValues.SetValues(empleado);
        BD.SaveChanges();
        return Ok(existe);
    }

    // ELIMINAR  →  DELETE /Api/Empleado?id=1
    [HttpDelete]
    public IActionResult Eliminar(int id)
    {
        var empleado = BD.Empleados.Find(id);
        if (empleado == null)
            return NotFound(new { mensaje = "No existe el registro " + id });

        BD.Empleados.Remove(empleado);
        BD.SaveChanges();
        return Ok(new { mensaje = "Eliminado" });
    }
}
