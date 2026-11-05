using Microsoft.AspNetCore.Mvc;
using NominaApi.Data;
using NominaApi.Models;

namespace NominaApi.Controllers;

// Responde en http://localhost:5000/Api/Categoria
[ApiController]
[Route("Api/[controller]")]
public class CategoriaController : ControllerBase
{
    private readonly NominaContext BD;

    // ASP.NET nos da la conexión a la base de datos (igual que Angular da el HttpClient)
    public CategoriaController(NominaContext bd)
    {
        BD = bd;
    }

    // CONSULTAR  →  GET /Api/Categoria?id=1
    [HttpGet]
    public IActionResult Consultar(int id)
    {
        var categoria = BD.Categorias.Find(id);
        if (categoria == null)
            return NotFound(new { mensaje = "No existe el registro " + id });
        return Ok(categoria);
    }

    // LISTAR  →  GET /Api/Categoria/Todos
    [HttpGet("Todos")]
    public IActionResult Todos()
    {
        return Ok(BD.Categorias.ToList());
    }

    // GRABAR  →  POST /Api/Categoria   (los datos van en el body)
    [HttpPost]
    public IActionResult Grabar([FromBody] Categoria categoria)
    {
        if (categoria.IdCategoria != 0 && BD.Categorias.Find(categoria.IdCategoria) != null)
            return Conflict(new { mensaje = "Ya existe el registro " + categoria.IdCategoria });

        BD.Categorias.Add(categoria);
        BD.SaveChanges();
        return Ok(categoria);
    }

    // MODIFICAR  →  PUT /Api/Categoria   (los datos van en el body)
    [HttpPut]
    public IActionResult Modificar([FromBody] Categoria categoria)
    {
        var existe = BD.Categorias.Find(categoria.IdCategoria);
        if (existe == null)
            return NotFound(new { mensaje = "No existe el registro " + categoria.IdCategoria });

        BD.Entry(existe).CurrentValues.SetValues(categoria);
        BD.SaveChanges();
        return Ok(existe);
    }

    // ELIMINAR  →  DELETE /Api/Categoria?id=1
    [HttpDelete]
    public IActionResult Eliminar(int id)
    {
        var categoria = BD.Categorias.Find(id);
        if (categoria == null)
            return NotFound(new { mensaje = "No existe el registro " + id });

        BD.Categorias.Remove(categoria);
        BD.SaveChanges();
        return Ok(new { mensaje = "Eliminado" });
    }
}
