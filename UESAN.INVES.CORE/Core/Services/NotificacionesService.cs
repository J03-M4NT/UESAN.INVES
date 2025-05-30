using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UESAN.INVES.CORE.Core.DTOs;
using UESAN.INVES.CORE.Core.Entities;
using UESAN.INVES.CORE.Core.Interfaces;

namespace UESAN.INVES.CORE.Core.Services
{
    public class NotificacionesService : INotificacionesService
    {
        private readonly INotificacionesRepository _notificacionesRepository;

        public NotificacionesService(INotificacionesRepository notificacionesRepository)
        {
            _notificacionesRepository = notificacionesRepository;
        }
        public async Task<IEnumerable<NotificacionesDTO>> GetAllNotificacionesAsync()
        {
            var notificaciones = await _notificacionesRepository.GetAllNotificacionesAsync(); // Faltaba esta línea

            return notificaciones.Select(n => new NotificacionesDTO
            {
                NotificacionId = n.NotificacionId,
                UsuarioId = n.UsuarioId,
                Mensaje = n.Mensaje,
                FechaEnvio = n.FechaEnvio,
                Leido = n.Leido
            });
        }
        public async Task<NotificacionesDTO?> GetNotificacionByIdAsync(int id)
        {
            var notificacion = await _notificacionesRepository.GetNotificacionByIdAsync(id);
            if (notificacion == null) return null;
            return new NotificacionesDTO
            {
                NotificacionId = notificacion.NotificacionId,
                UsuarioId = notificacion.UsuarioId,
                Mensaje = notificacion.Mensaje,
                FechaEnvio = notificacion.FechaEnvio,
                Leido = notificacion.Leido
            };
        }

        public async Task<NotificacionesDTO> CreateNotificacionAsync(NotificacionesCreateDTO notificacionCreateDto)
        {
            var notificacion = new Notificaciones
            {
                UsuarioId = notificacionCreateDto.UsuarioId,
                Mensaje = notificacionCreateDto.Mensaje,
                FechaEnvio = notificacionCreateDto.FechaEnvio ?? DateTime.Now,
                Leido = false
            };

            var createdNotificacion = await _notificacionesRepository.CreateNotificacionAsync(notificacion);

            return new NotificacionesDTO
            {
                NotificacionId = createdNotificacion.NotificacionId,
                UsuarioId = createdNotificacion.UsuarioId,
                Mensaje = createdNotificacion.Mensaje,
                FechaEnvio = createdNotificacion.FechaEnvio,
                Leido = createdNotificacion.Leido
            };
        }
        public async Task<bool> DeleteNotificacionAsync(int id)
        {
            return await _notificacionesRepository.DeleteNotificacionAsync(id);
        }

        public async Task<NotificacionesDTO?> UpdateNotificacionAsync(NotificacionesUpdateDTO notificacionUpdateDto)
        {
            var existing = await _notificacionesRepository.GetNotificacionByIdAsync(notificacionUpdateDto.NotificacionId);
            if (existing == null) return null;

            existing.Leido = notificacionUpdateDto.Leido ?? existing.Leido;

            var updatedNotificacion = await _notificacionesRepository.UpdateNotificacionAsync(existing);

            return new NotificacionesDTO
            {
                NotificacionId = updatedNotificacion.NotificacionId,
                UsuarioId = updatedNotificacion.UsuarioId,
                Mensaje = updatedNotificacion.Mensaje,
                FechaEnvio = updatedNotificacion.FechaEnvio,
                Leido = updatedNotificacion.Leido
            };
        }



    }
}
