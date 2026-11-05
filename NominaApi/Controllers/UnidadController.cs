using Microsoft.AspNetCore.Mvc;
using NominaApi.Data;
using NominaApi.Models;

namespace NominaApi.Controllers;

// Responde en http://localhost:5000/Api/Unidad
[ApiController]
[Route("Api/[controller]")]
public class UnidadController : ControllerBase
{
    private readonly NominaContext BD;

    // ASP.NET nos da la conexión a la base de datos (igual que Angular da el HttpClient)
    public UnidadController(NominaContext bd)
    {
        BD = bd;
    }

    // CONSULTAR  →  GET /Api/Unidad?id=1
    [HttpGet]
    public IActionResult Consultar(int id)
    {
        var unidad = BD.Unidades.Find(id);
        if (unidad == null)
            return NotFound(new { mensaje = "No existe el registro " + id });
        return Ok(unidad);
    }

    // LISTAR  →  GET /Api/Unidad/Todos
    [HttpGet("Todos")]
    public IActionResult Todos()
    {
        return Ok(BD.Unidades.ToList());
    }

    // GRABAR  →  POST /Api/Unidad   (los datos van en el body)
    [HttpPost]
    public IActionResult Grabar([FromBody] Unidad unidad)
    {
        if (unidad.IdUnidad != 0 && BD.Unidades.Find(unidad.IdUnidad) != null)
            return Conflict(new { mensaje = "Ya existe el registro " + unidad.IdUnidad });

        BD.Unidades.Add(unidad);
        BD.SaveChanges();
        return Ok(unidad);
    }

    // MODIFICAR  →  PUT /Api/Unidad   (los datos van en el body)
    [HttpPut]
    public IActionResult Modificar([FromBody] Unidad unidad)
    {
        var existe = BD.Unidades.Find(unidad.IdUnidad);
        if (existe == null)
            return NotFound(new { mensaje = "No existe el registro " + unidad.IdUnidad });

        BD.Entry(existe).CurrentValues.SetValues(unidad);
        BD.SaveChanges();
        return Ok(existe);
    }

    // ELIMINAR  →  DELETE /Api/Unidad?id=1
    [HttpDelete]
    public IActionResult Eliminar(int id)
    {
        var unidad = BD.Unidades.Find(id);
        if (unidad == null)
            return NotFound(new { mensaje = "No existe el registro " + id });

        BD.Unidades.Remove(unidad);
        BD.SaveChanges();
        return Ok(new { mensaje = "Eliminado" });
    }
}
