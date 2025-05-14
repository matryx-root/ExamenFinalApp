using ExamenFinalApp.Data;
using ExamenFinalApp.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExamenFinalApp.Controllers;

/// Controlador API para operaciones CRUD de libros.
/// Endpoints: POST /api/libros, GET /api/libros, etc.

[Route("api/[controller]")]
[ApiController]
public class LibroController : ControllerBase
{
    private readonly AppDbContext _context;

    public LibroController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<Libro>>> Get()
    {
        return await _context.Libros.ToListAsync();
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Libro libro)
    {
        _context.Libros.Add(libro);
        await _context.SaveChangesAsync();
        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] Libro libro)
    {
        if (id != libro.Id)
            return BadRequest();

        _context.Entry(libro).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var libro = await _context.Libros.FindAsync(id);
        if (libro is null)
            return NotFound();

        _context.Libros.Remove(libro);
        await _context.SaveChangesAsync();
        return Ok();
    }
}
