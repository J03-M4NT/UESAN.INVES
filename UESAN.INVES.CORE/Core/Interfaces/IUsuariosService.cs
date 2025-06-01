using UESAN.INVES.CORE.Core.DTOs;

namespace UESAN.INVES.CORE.Core.Interfaces
{
    public interface IUsuariosService
    {
        Task<int> CreateUsuarioAsync(UsuariosCreateDTO dto);
        Task<bool> DeleteUsuarioAsync(int id);
        Task<IEnumerable<UsuariosDTO>> GetAllUsuariosAsync();
        Task<UsuariosDTO?> GetUsuarioByIdAsync(int id);
        Task<SignInResponseDTO> SignInAsync(SignInDTO signInDto);
        Task<bool> UpdateUsuarioAsync(UsuariosUpdateDTO dto);
    }
}