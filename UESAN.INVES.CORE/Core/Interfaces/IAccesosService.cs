using UESAN.INVES.CORE.Core.DTOs;

namespace UESAN.INVES.CORE.Core.Interfaces
{
    internal interface IAccesosService
    {
        Task<AccesosDTO> CreateAccesoAsync(AccesosCreateDTO accesoCreateDto);
        Task<bool> DeleteAccesoAsync(int id);
        Task<AccesosDTO?> GetAccesoByIdAsync(int id);
        Task<IEnumerable<AccesosFechaDTO>> GetAccesosByFechaAsync(DateTime fecha);
        Task<IEnumerable<AccesosUsuarioDTO>> GetAccesosByUsuarioAsync(int usuarioId);
        Task<IEnumerable<AccesosDTO>> GetAllAccesosAsync();
        Task<bool> UpdateAccesoAsync(int id, AccesosDTO accesoDto);
    }
}