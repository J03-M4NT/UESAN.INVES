using UESAN.INVES.CORE.Core.Entities;

namespace UESAN.INVES.CORE.Core.Interfaces
{
    public interface INotificacionesRepository
    {
        Task<Notificaciones> CreateNotificacionAsync(Notificaciones notificacion);
        Task<bool> DeleteNotificacionAsync(int id);
        IEnumerable<Notificaciones> GetAllNotificaciones();
        Task<List<Notificaciones>> GetAllNotificacionesAsync();
        Task<Notificaciones?> GetNotificacionByIdAsync(int id);
        Task<Notificaciones> UpdateNotificacionAsync(Notificaciones notificacion);
    }
}