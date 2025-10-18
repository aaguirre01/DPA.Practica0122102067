using DPA.Practica0122102067.CORE.Core.Interfaces;
using DPA.Practica0122102067.CORE.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA.Practica0122102067.CORE.Infrastructure.Repositories
{
    public class EstudianteRepository : IEstudianteRepository
    {
        private readonly UniversidadDbContext _context;
        public EstudianteRepository(UniversidadDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Core.Entities.Estudiante>> GetAllAsync()
        {
            return await Task.FromResult(_context.Estudiante.ToList());
        }
        public async Task<Core.Entities.Estudiante?> GetByIdAsync(int id)
        {
            var estudiante = _context.Estudiante.Find(id);
            return await Task.FromResult(estudiante);
        }
        public async Task AddAsync(Core.Entities.Estudiante estudiante)
        {
            _context.Estudiante.Add(estudiante);
            await _context.SaveChangesAsync();
        }
        public async Task CreateAsync(Core.Entities.Estudiante estudiante)
        {
            _context.Estudiante.Add(estudiante);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Core.Entities.Estudiante estudiante)
        {
            var existingEstudiante = _context.Estudiante.Find(estudiante.Id);
            if (existingEstudiante != null)
            {
                existingEstudiante.Nombres = estudiante.Nombres;
                existingEstudiante.Paterno = estudiante.Paterno;
                existingEstudiante.Materno = estudiante.Materno;
                existingEstudiante.Correo = estudiante.Correo;
                existingEstudiante.CarreraId = estudiante.CarreraId;
                await _context.SaveChangesAsync();
            }
        }
        public async Task DeleteAsync(int id)
        {
            var estudiante = _context.Estudiante.Find(id);
            if (estudiante != null)
            {
                _context.Estudiante.Remove(estudiante);
                await _context.SaveChangesAsync();
            }
        }



    }
}
