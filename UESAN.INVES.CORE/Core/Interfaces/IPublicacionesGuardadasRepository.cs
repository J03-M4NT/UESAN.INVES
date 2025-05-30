using UESAN.INVES.CORE.Core.Entities;

namespace UESAN.INVES.CORE.Core.Interfaces
{
    public interface IPublicacionesGuardadasRepository
    {
        Task<PublicacionesGuardadas?> CreateAsync(PublicacionesGuardadas nueva);
        Task<bool> DeletePublicacionGuardadaAsync(int id);
        IEnumerable<PublicacionesGuardadas> GetAllPublicacionesGuardadas();
        Task<List<PublicacionesGuardadas>> GetAllPublicacionesGuardadasAsync();
        Task<List<PublicacionesGuardadas>> GetPublicacionesGuardadasByUserIdAsync(int userId);
        Task<PublicacionesGuardadas?> GetPublicacionGuardadaByIdAsync(int id);
        Task<bool> IsPublicacionGuardadaByUserAsync(int publicacionId, int userId);
        Task<bool> UpdateAsync(PublicacionesGuardadas actualizada);
    }
}