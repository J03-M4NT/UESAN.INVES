using UESAN.INVES.CORE.Core.DTOs;

namespace UESAN.INVES.CORE.Core.Interfaces
{
    public interface IPublicacionesGuardadasService
    {
        Task<PublicacionesGuardadasDTO?> CreateAsync(PublicacionesGuardadasCreateDTO dto);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<PublicacionesGuardadasDTO>> GetAllAsync();
        Task<PublicacionesGuardadasDTO?> GetByIdAsync(int id);
        Task<IEnumerable<PublicacionesGuardadasDTO>> GetByUserIdAsync(int userId);
        Task<bool> IsGuardadaAsync(int publicacionId, int userId);
        Task<bool> UpdateAsync(PublicacionesGuardadasUpdateDTO dto);
    }
}