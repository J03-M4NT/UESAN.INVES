using UESAN.INVES.CORE.Core.Entities;

namespace UESAN.INVES.CORE.Core.Interfaces
{
    public interface IUsuariosRepository
    {
        Task<Usuarios> CreateUsuarioAsync(Usuarios usuario);
        Task<bool> DeleteUsuarioAsync(int id);
        IEnumerable<Usuarios> GetAllUsuarios();
        Task<List<Usuarios>> GetAllUsuariosAsync();
        Task<Usuarios?> GetUsuarioByEmailAsync(string email);
        Task<Usuarios?> GetUsuarioByIdAsync(int id);
        Task<Usuarios?> GetUsuarioByUsernameAsync(string username);
        Task<List<Usuarios>> GetUsuariosByRoleIdAsync(int roleId);
        Task<Usuarios> UpdateUsuarioAsync(Usuarios usuario);
    }
}