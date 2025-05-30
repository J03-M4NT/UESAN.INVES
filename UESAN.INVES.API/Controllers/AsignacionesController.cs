using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UESAN.INVES.CORE.Core.DTOs;
using UESAN.INVES.CORE.Core.Interfaces;

namespace UESAN.INVES.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsignacionesController : ControllerBase
    {
        private readonly IAsignacionesService _asignacionesService;
        public AsignacionesController(IAsignacionesService asignacionesService)
        {
            _asignacionesService = asignacionesService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsignaciones()
        {
            var asignaciones = await _asignacionesService.GetAllAsignacionesAsync();
            return Ok(asignaciones);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsignacion(int id)
        {
            var asignacion = await _asignacionesService.GetAsignacionByIdAsync(id);
            if (asignacion == null)
            {
                return NotFound();
            }
            return Ok(asignacion);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsignacion(int id, [FromBody] AsignacionesUpdateDTO asignacionUpdateDto)
        {
            if (id != asignacionUpdateDto.AsignacionId)
            {
                return BadRequest("Asignacion ID mismatch");
            }
            var updated = await _asignacionesService.UpdateAsignacionAsync(asignacionUpdateDto);
            if (updated == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> PostAsignacion([FromBody] AsignacionesCreateDTO asignacionCreateDto)
        {
            if (asignacionCreateDto == null)
            {
                return BadRequest("Asignacion cannot be null");
            }
            var createdAsignacion = await _asignacionesService.CreateAsignacionAsync(asignacionCreateDto);
            return CreatedAtAction(nameof(GetAsignacion), new { id = createdAsignacion.AsignacionId }, createdAsignacion);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsignacion(int id)
        {
            var result = await _asignacionesService.DeleteAsignacionAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
