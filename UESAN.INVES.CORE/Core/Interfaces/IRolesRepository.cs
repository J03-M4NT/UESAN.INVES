using UESAN.INVES.CORE.Core.Entities;

namespace UESAN.INVES.CORE.Core.Interfaces
{
    public interface IRolesRepository
    {
        Task<Roles> CreateRoleAsync(Roles role);
        Task<bool> DeleteRoleAsync(int id);
        IEnumerable<Roles> GetAllRoles();
        Task<List<Roles>> GetAllRolesAsync();
        Task<Roles?> GetRoleByIdAsync(int id);
        Task<List<Roles>> GetRolesByUserIdAsync(int userId);
        Task<Roles> UpdateRoleAsync(Roles role);
    }
}