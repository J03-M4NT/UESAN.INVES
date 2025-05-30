using UESAN.INVES.CORE.Core.DTOs;

namespace UESAN.INVES.CORE.Core.Interfaces
{
    public interface IAsignacionesService
    {
        Task<AsignacionesDTO> CreateAsignacionAsync(AsignacionesCreateDTO asignacionCreateDto);
        Task<bool> DeleteAsignacionAsync(int id);
        Task<IEnumerable<AsignacionesDTO>> GetAllAsignacionesAsync();
        Task<AsignacionesDTO?> GetAsignacionByIdAsync(int id);
        Task<AsignacionesDTO?> UpdateAsignacionAsync(AsignacionesUpdateDTO asignacionUpdateDto);
    }
}