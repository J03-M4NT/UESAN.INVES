using Microsoft.AspNetCore.Mvc;
using UESAN.INVES.CORE.Core.Entities;
using UESAN.INVES.CORE.Core.Interfaces;
using System.Threading.Tasks;

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

        // GET: api/Notificaciones
        [HttpGet]
        public async Task<IActionResult> GetNotificaciones()
        {
            var notificaciones = await _notificacionesRepository.GetAllNotificacionesAsync();
            return Ok(notificaciones);
        }

        // GET: api/Notificaciones/5
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

        // POST: api/Notificaciones
        [HttpPost]
        public async Task<IActionResult> PostNotificacion([FromBody] Notificaciones notificacion)
        {
            if (notificacion == null)
            {
                return BadRequest("Notificacion cannot be null");
            }
            var created = await _notificacionesRepository.CreateNotificacionAsync(notificacion);
            return CreatedAtAction(nameof(GetNotificacion), new { id = created.NotificacionId }, created);
        }

        // PUT: api/Notificaciones/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNotificacion(int id, [FromBody] Notificaciones notificacion)
        {
            if (id != notificacion.NotificacionId)
            {
                return BadRequest("Notificacion ID mismatch");
            }
            var existing = await _notificacionesRepository.GetNotificacionByIdAsync(id);
            if (existing == null)
            {
                return NotFound();
            }
            var updated = await _notificacionesRepository.UpdateNotificacionAsync(notificacion);
            return Ok(updated);
        }

        // DELETE: api/Notificaciones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNotificacion(int id)
        {
            var deleted = await _notificacionesRepository.DeleteNotificacionAsync(id);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
