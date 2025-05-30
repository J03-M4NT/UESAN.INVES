using UESAN.INVES.CORE.Core.DTOs;

namespace UESAN.INVES.CORE.Core.Interfaces
{
    public interface INotificacionesService
    {
        Task<NotificacionesDTO> CreateNotificacionAsync(NotificacionesCreateDTO notificacionCreateDto);
        Task<bool> DeleteNotificacionAsync(int id);
        Task<IEnumerable<NotificacionesDTO>> GetAllNotificacionesAsync();
        Task<NotificacionesDTO?> GetNotificacionByIdAsync(int id);
        Task<NotificacionesDTO?> UpdateNotificacionAsync(NotificacionesUpdateDTO notificacionUpdateDto);
    }
}