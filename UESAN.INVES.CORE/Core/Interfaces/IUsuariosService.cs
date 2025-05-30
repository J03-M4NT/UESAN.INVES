using UESAN.INVES.CORE.Core.DTOs;

namespace UESAN.INVES.CORE.Core.Interfaces
{
    public interface IUsuariosService
    {
        Task<UsuariosDTO> CreateUsuarioAsync(UsuariosCreateDTO dto);
        Task<bool> DeleteUsuarioAsync(int id);
        Task<IEnumerable<UsuariosDTO>> GetAllUsuariosAsync();
        Task<UsuariosDTO?> GetUsuarioByEmailAsync(string email);
        Task<UsuariosDTO?> GetUsuarioByIdAsync(int id);
        Task<UsuariosDTO?> GetUsuarioByUsernameAsync(string username);
        Task<IEnumerable<UsuariosDTO>> GetUsuariosByRoleIdAsync(int roleId);
        Task<UsuariosDTO?> UpdateUsuarioAsync(UsuariosUpdateDTO dto);
    }
}