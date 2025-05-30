using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UESAN.INVES.CORE.Core.DTOs;
using UESAN.INVES.CORE.Core.Interfaces;

namespace UESAN.INVES.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificacionesController : ControllerBase
    {
        private readonly INotificacionesRepository _notificacionesRepository;
        public NotificacionesController(INotificacionesRepository notificacionesRepository)
        {
            _notificacionesRepository = notificacionesRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetNotificaciones()
        {
            var notificaciones = await _notificacionesRepository.GetAllNotificacionesAsync();
            return Ok(notificaciones);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetNotificacion(int id)
        {
            var notificacion = await _notificacionesRepository.GetNotificacionByIdAsync(id);
            if (notificacion == null)
            {
                return NotFound();
            }
            return Ok(notificacion);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutNotificacion(int id, [FromBody] NotificacionesDTO notificacionDto)
        {
            if (id != notificacionDto.NotificacionId)
            {
                return BadRequest("Notificacion ID mismatch");
            }
            // Se asume que el repositorio tiene un método UpdateNotificacionAsync que acepta la entidad
            var updated = await _notificacionesRepository.UpdateNotificacionAsync(new UESAN.INVES.CORE.Core.Entities.Notificaciones
            {
                NotificacionId = notificacionDto.NotificacionId,
                UsuarioId = notificacionDto.UsuarioId,
                Mensaje = notificacionDto.Mensaje,
                FechaEnvio = notificacionDto.FechaEnvio,
                Leido = notificacionDto.Leido
            });
            if (updated == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> PostNotificacion([FromBody] NotificacionesDTO notificacionDto)
        {
            if (notificacionDto == null)
            {
                return BadRequest("Notificacion cannot be null");
            }
            var createdNotificacion = await _notificacionesRepository.CreateNotificacionAsync(new UESAN.INVES.CORE.Core.Entities.Notificaciones
            {
                UsuarioId = notificacionDto.UsuarioId,
                Mensaje = notificacionDto.Mensaje,
                FechaEnvio = notificacionDto.FechaEnvio,
                Leido = notificacionDto.Leido
            });
            return CreatedAtAction(nameof(GetNotificacion), new { id = createdNotificacion.NotificacionId }, createdNotificacion);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNotificacion(int id)
        {
            var result = await _notificacionesRepository.DeleteNotificacionAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
