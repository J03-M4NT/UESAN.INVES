using UESAN.INVES.CORE.Core.Entities;

namespace UESAN.INVES.CORE.Core.Interfaces
{
    public interface IAsignacionesRepository
    {
        Task<Asignaciones> CreateAsignacionAsync(Asignaciones asignacion);
        Task<bool> DeleteAsignacionAsync(int id);
        IEnumerable<Asignaciones> GetAllAsignaciones();
        Task<List<Asignaciones>> GetAllAsignacionesAsync();
        Task<Asignaciones?> GetAsignacionByIdAsync(int id);
        Task<Asignaciones?> UpdateAsignacionAsync(Asignaciones asignacion);
    }
}