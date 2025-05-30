using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UESAN.INVES.CORE.Core.DTOs;
using UESAN.INVES.CORE.Core.Interfaces;

namespace UESAN.INVES.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublicacionesGuardadasController : ControllerBase
    {
        private readonly IPublicacionesGuardadasRepository _publicacionesGuardadasRepository;
        public PublicacionesGuardadasController(IPublicacionesGuardadasRepository publicacionesGuardadasRepository)
        {
            _publicacionesGuardadasRepository = publicacionesGuardadasRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetPublicacionesGuardadas()
        {
            var publicacionesGuardadas = await _publicacionesGuardadasRepository.GetAllPublicacionesGuardadasAsync();
            return Ok(publicacionesGuardadas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPublicacionGuardada(int id)
        {
            var publicacionGuardada = await _publicacionesGuardadasRepository.GetPublicacionGuardadaByIdAsync(id);
            if (publicacionGuardada == null)
            {
                return NotFound();
            }
            return Ok(publicacionGuardada);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPublicacionGuardada(int id, [FromBody] PublicacionesGuardadasDTO publicacionGuardadaDto)
        {
            if (id != publicacionGuardadaDto.Id)
            {
                return BadRequest("PublicacionGuardada ID mismatch");
            }
            var updated = await _publicacionesGuardadasRepository.UpdateAsync(new UESAN.INVES.CORE.Core.Entities.PublicacionesGuardadas
            {
                Id = publicacionGuardadaDto.Id,
                UsuarioId = publicacionGuardadaDto.UsuarioId,
                PublicacionId = publicacionGuardadaDto.PublicacionId,
                FechaGuardado = publicacionGuardadaDto.FechaGuardado
            });
            if (!updated)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> PostPublicacionGuardada([FromBody] PublicacionesGuardadasDTO publicacionGuardadaDto)
        {
            if (publicacionGuardadaDto == null)
            {
                return BadRequest("PublicacionGuardada cannot be null");
            }
            var created = await _publicacionesGuardadasRepository.CreateAsync(new UESAN.INVES.CORE.Core.Entities.PublicacionesGuardadas
            {
                UsuarioId = publicacionGuardadaDto.UsuarioId,
                PublicacionId = publicacionGuardadaDto.PublicacionId,
                FechaGuardado = publicacionGuardadaDto.FechaGuardado
            });
            return CreatedAtAction(nameof(GetPublicacionGuardada), new { id = created.Id }, created);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePublicacionGuardada(int id)
        {
            var result = await _publicacionesGuardadasRepository.DeletePublicacionGuardadaAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
