using DPA.Practica0122102067.CORE.Core.Entities;
using DPA.Practica0122102067.CORE.Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DPA.Practica0122102067.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarrerasController : ControllerBase
    {
        private readonly UniversidadDbContext _context;

        public CarrerasController(UniversidadDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var carreras = await _context.Carreras.ToListAsync();
            return Ok(carreras);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var carrera = await _context.Carreras.FindAsync(id);
            if (carrera == null)
                return NotFound();

            return Ok(carrera);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCarrera([FromBody] Carrera carrera)
        {
            _context.Carreras.Add(carrera);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = carrera.Id }, carrera);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCarrera(int id, [FromBody] Carrera carrera)
        {
            var existingCarrera = await _context.Carreras.FindAsync(id);
            if (existingCarrera == null)
                return NotFound();

            existingCarrera.Nombre = carrera.Nombre;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarrera(int id)
        {
            var carrera = await _context.Carreras.FindAsync(id);
            if (carrera == null)
                return NotFound();

            _context.Carreras.Remove(carrera);
            await _context.SaveChangesAsync();
            return NoContent();
        }



    }

}
