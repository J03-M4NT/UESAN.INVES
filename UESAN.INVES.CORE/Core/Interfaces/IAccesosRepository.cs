using UESAN.INVES.CORE.Core.Entities;

namespace UESAN.INVES.CORE.Core.Interfaces
{
    public interface IAccesosRepository
    {
        Task<Accesos> CreateAccesoAsync(Accesos acceso);
        Task<bool> DeleteAccesosAsync(int id);
        Task<Accesos?> GetAccesoByIdAsync(int id);
        IEnumerable<Accesos> GetAllAccesos();
        Task<List<Accesos>> GetAllAccesosAsync();
        Task<bool> UpdateAccesoAsync(Accesos acceso);
    }
}