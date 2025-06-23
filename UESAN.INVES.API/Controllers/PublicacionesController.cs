using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UESAN.INVES.CORE.Core.DTOs;
using UESAN.INVES.CORE.Core.Interfaces;

namespace UESAN.INVES.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublicacionesController : ControllerBase
    {
        private readonly IPublicacionesRepository _publicacionesRepository;
        public PublicacionesController(IPublicacionesRepository publicacionesRepository)
        {
            _publicacionesRepository = publicacionesRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetPublicaciones()
        {
            var publicaciones = await _publicacionesRepository.GetAllPublicacionesAsync();
            return Ok(publicaciones);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPublicacion(int id)
        {
            var publicacion = await _publicacionesRepository.GetPublicacionByIdAsync(id);
            if (publicacion == null)
            {
                return NotFound();
            }
            return Ok(publicacion);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPublicacion(int id, [FromBody] PublicacionesDTO publicacionDto)
        {
            if (id != publicacionDto.PublicacionId)
            {
                return BadRequest("Publicacion ID mismatch");
            }
            var updated = await _publicacionesRepository.UpdatePublicacionAsync(new UESAN.INVES.CORE.Core.Entities.Publicaciones
            {
                PublicacionId = publicacionDto.PublicacionId,
                Nombre = publicacionDto.Titulo,
                // Mapear otros campos según la entidad
            });
            if (updated == null)
            {
                return NotFound();
            }
            return NoContent();
        }



        [HttpPost]
        public async Task<IActionResult> PostPublicacion([FromBody] PublicacionesDTO publicacionDto)
        {
            if (publicacionDto == null)
            {
                return BadRequest("Publicacion cannot be null");
            }
            var createdPublicacion = await _publicacionesRepository.CreatePublicacionAsync(new UESAN.INVES.CORE.Core.Entities.Publicaciones
            {
                Nombre = publicacionDto.Titulo,
                // Mapear otros campos según la entidad
            });
            return CreatedAtAction(nameof(GetPublicacion), new { id = createdPublicacion.PublicacionId }, createdPublicacion);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePublicacion(int id)
        {
            var result = await _publicacionesRepository.DeletePublicacionAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
