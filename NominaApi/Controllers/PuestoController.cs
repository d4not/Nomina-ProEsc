using Microsoft.AspNetCore.Mvc;
using NominaApi.Data;
using NominaApi.Models;

namespace NominaApi.Controllers;

// Responde en http://localhost:5000/Api/Puesto
[ApiController]
[Route("Api/[controller]")]
public class PuestoController : ControllerBase
{
    private readonly NominaContext BD;

    // ASP.NET nos da la conexión a la base de datos (igual que Angular da el HttpClient)
    public PuestoController(NominaContext bd)
    {
        BD = bd;
    }

    // CONSULTAR  →  GET /Api/Puesto?id=1
    [HttpGet]
    public IActionResult Consultar(int id)
    {
        var puesto = BD.Puestos.Find(id);
        if (puesto == null)
            return NotFound(new { mensaje = "No existe el registro " + id });
        return Ok(puesto);
    }

    // LISTAR  →  GET /Api/Puesto/Todos
    [HttpGet("Todos")]
    public IActionResult Todos()
    {
        return Ok(BD.Puestos.ToList());
    }

    // GRABAR  →  POST /Api/Puesto   (los datos van en el body)
    [HttpPost]
    public IActionResult Grabar([FromBody] Puesto puesto)
    {
        if (puesto.IdPuesto != 0 && BD.Puestos.Find(puesto.IdPuesto) != null)
            return Conflict(new { mensaje = "Ya existe el registro " + puesto.IdPuesto });

        BD.Puestos.Add(puesto);
        BD.SaveChanges();
        return Ok(puesto);
    }

    // MODIFICAR  →  PUT /Api/Puesto   (los datos van en el body)
    [HttpPut]
    public IActionResult Modificar([FromBody] Puesto puesto)
    {
        var existe = BD.Puestos.Find(puesto.IdPuesto);
        if (existe == null)
            return NotFound(new { mensaje = "No existe el registro " + puesto.IdPuesto });

        BD.Entry(existe).CurrentValues.SetValues(puesto);
        BD.SaveChanges();
        return Ok(existe);
    }

    // ELIMINAR  →  DELETE /Api/Puesto?id=1
    [HttpDelete]
    public IActionResult Eliminar(int id)
    {
        var puesto = BD.Puestos.Find(id);
        if (puesto == null)
            return NotFound(new { mensaje = "No existe el registro " + id });

        BD.Puestos.Remove(puesto);
        BD.SaveChanges();
        return Ok(new { mensaje = "Eliminado" });
    }
}
