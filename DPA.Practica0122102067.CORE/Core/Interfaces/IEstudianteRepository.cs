using DPA.Practica0122102067.CORE.Core.Entities;

namespace DPA.Practica0122102067.CORE.Core.Interfaces
{
    public interface IEstudianteRepository
    {
        Task<IEnumerable<Estudiante>> GetAllAsync();

        // Obtener un estudiante por ID
        Task<Estudiante?> GetByIdAsync(int id);

        // Agregar un nuevo estudiante
        Task<Estudiante> AddAsync(Estudiante estudiante);

        // Actualizar un estudiante existente
        Task<bool> UpdateAsync(int id, Estudiante estudiante);

        // Eliminar un estudiante por ID
        Task<bool> DeleteAsync(int id);
    }
}