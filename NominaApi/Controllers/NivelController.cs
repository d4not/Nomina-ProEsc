using Microsoft.AspNetCore.Mvc;
using NominaApi.Data;
using NominaApi.Models;

namespace NominaApi.Controllers;

// Responde en http://localhost:5000/Api/Nivel
[ApiController]
[Route("Api/[controller]")]
public class NivelController : ControllerBase
{
    private readonly NominaContext BD;

    // ASP.NET nos da la conexión a la base de datos (igual que Angular da el HttpClient)
    public NivelController(NominaContext bd)
    {
        BD = bd;
    }

    // CONSULTAR  →  GET /Api/Nivel?id=1
    [HttpGet]
    public IActionResult Consultar(int id)
    {
        var nivel = BD.Niveles.Find(id);
        if (nivel == null)
            return NotFound(new { mensaje = "No existe el registro " + id });
        return Ok(nivel);
    }

    // LISTAR  →  GET /Api/Nivel/Todos
    [HttpGet("Todos")]
    public IActionResult Todos()
    {
        return Ok(BD.Niveles.ToList());
    }

    // GRABAR  →  POST /Api/Nivel   (los datos van en el body)
    [HttpPost]
    public IActionResult Grabar([FromBody] Nivel nivel)
    {
        if (nivel.IdNivel != 0 && BD.Niveles.Find(nivel.IdNivel) != null)
            return Conflict(new { mensaje = "Ya existe el registro " + nivel.IdNivel });

        BD.Niveles.Add(nivel);
        BD.SaveChanges();
        return Ok(nivel);
    }

    // MODIFICAR  →  PUT /Api/Nivel   (los datos van en el body)
    [HttpPut]
    public IActionResult Modificar([FromBody] Nivel nivel)
    {
        var existe = BD.Niveles.Find(nivel.IdNivel);
        if (existe == null)
            return NotFound(new { mensaje = "No existe el registro " + nivel.IdNivel });

        BD.Entry(existe).CurrentValues.SetValues(nivel);
        BD.SaveChanges();
        return Ok(existe);
    }

    // ELIMINAR  →  DELETE /Api/Nivel?id=1
    [HttpDelete]
    public IActionResult Eliminar(int id)
    {
        var nivel = BD.Niveles.Find(id);
        if (nivel == null)
            return NotFound(new { mensaje = "No existe el registro " + id });

        BD.Niveles.Remove(nivel);
        BD.SaveChanges();
        return Ok(new { mensaje = "Eliminado" });
    }
}
