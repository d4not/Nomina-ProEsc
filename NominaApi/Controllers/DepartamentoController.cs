using Microsoft.AspNetCore.Mvc;
using NominaApi.Data;
using NominaApi.Models;

namespace NominaApi.Controllers;

// Responde en http://localhost:5000/Api/Departamento
[ApiController]
[Route("Api/[controller]")]
public class DepartamentoController : ControllerBase
{
    private readonly NominaContext BD;

    // ASP.NET nos da la conexión a la base de datos (igual que Angular da el HttpClient)
    public DepartamentoController(NominaContext bd)
    {
        BD = bd;
    }

    // CONSULTAR  →  GET /Api/Departamento?id=1
    [HttpGet]
    public IActionResult Consultar(int id)
    {
        var departamento = BD.Departamentos.Find(id);
        if (departamento == null)
            return NotFound(new { mensaje = "No existe el registro " + id });
        return Ok(departamento);
    }

    // LISTAR  →  GET /Api/Departamento/Todos
    [HttpGet("Todos")]
    public IActionResult Todos()
    {
        return Ok(BD.Departamentos.ToList());
    }

    // GRABAR  →  POST /Api/Departamento   (los datos van en el body)
    [HttpPost]
    public IActionResult Grabar([FromBody] Departamento departamento)
    {
        if (departamento.IdDepartamento != 0 && BD.Departamentos.Find(departamento.IdDepartamento) != null)
            return Conflict(new { mensaje = "Ya existe el registro " + departamento.IdDepartamento });

        BD.Departamentos.Add(departamento);
        BD.SaveChanges();
        return Ok(departamento);
    }

    // MODIFICAR  →  PUT /Api/Departamento   (los datos van en el body)
    [HttpPut]
    public IActionResult Modificar([FromBody] Departamento departamento)
    {
        var existe = BD.Departamentos.Find(departamento.IdDepartamento);
        if (existe == null)
            return NotFound(new { mensaje = "No existe el registro " + departamento.IdDepartamento });

        BD.Entry(existe).CurrentValues.SetValues(departamento);
        BD.SaveChanges();
        return Ok(existe);
    }

    // ELIMINAR  →  DELETE /Api/Departamento?id=1
    [HttpDelete]
    public IActionResult Eliminar(int id)
    {
        var departamento = BD.Departamentos.Find(id);
        if (departamento == null)
            return NotFound(new { mensaje = "No existe el registro " + id });

        BD.Departamentos.Remove(departamento);
        BD.SaveChanges();
        return Ok(new { mensaje = "Eliminado" });
    }
}
