using DPA.Practica0122102067.CORE.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DPA.Practica0122102067.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstudiantesController : ControllerBase
    {
        private readonly IEstudianteRepository _estudianteRepository;
        public EstudiantesController(IEstudianteRepository estudianteRepository)
        {
            _estudianteRepository = estudianteRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var estudiantes = await _estudianteRepository.GetAllAsync();
            return Ok(estudiantes);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var estudiante = await _estudianteRepository.GetByIdAsync(id);
            if (estudiante == null)
                return NotFound();
            return Ok(estudiante);
        }
        [HttpPost]
        public async Task<IActionResult> CreateEstudiante([FromBody] CORE.Core.Entities.Estudiante estudiante)
        {
            var createdEstudiante = await _estudianteRepository.AddAsync(estudiante);
            return CreatedAtAction(nameof(GetById), new { id = createdEstudiante.Id }, createdEstudiante);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEstudiante(int id, [FromBody] CORE.Core.Entities.Estudiante estudiante)
        {
            var updated = await _estudianteRepository.UpdateAsync(id, estudiante);
            if (!updated)
                return NotFound();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEstudiante(int id)
        {
            var deleted = await _estudianteRepository.DeleteAsync(id);
            if (!deleted)
                return NotFound();
            return NoContent();
        }
    }
}
