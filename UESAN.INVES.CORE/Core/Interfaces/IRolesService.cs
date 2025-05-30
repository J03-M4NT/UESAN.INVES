using UESAN.INVES.CORE.Core.DTOs;

namespace UESAN.INVES.CORE.Core.Interfaces
{
    public interface IRolesService
    {
        Task<RolesDTO> CreateRoleAsync(RolesCreateDTO dto);
        Task<bool> DeleteRoleAsync(int id);
        Task<IEnumerable<RolesDTO>> GetAllRolesAsync();
        Task<RolesDTO?> GetRoleByIdAsync(int id);
        Task<IEnumerable<RolesDTO>> GetRolesByUserIdAsync(int userId);
        Task<RolesDTO?> UpdateRoleAsync(RolesUpdateDTO dto);
    }
}