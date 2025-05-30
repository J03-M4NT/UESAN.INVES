using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UESAN.INVES.CORE.Core.DTOs;
using UESAN.INVES.CORE.Core.Interfaces;

namespace UESAN.INVES.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuariosRepository _usuariosRepository;
        public UsuariosController(IUsuariosRepository usuariosRepository)
        {
            _usuariosRepository = usuariosRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsuarios()
        {
            var usuarios = await _usuariosRepository.GetAllUsuariosAsync();
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUsuario(int id)
        {
            var usuario = await _usuariosRepository.GetUsuarioByIdAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return Ok(usuario);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario(int id, [FromBody] UsuariosDTO usuarioDto)
        {
            if (id != usuarioDto.UsuarioId)
            {
                return BadRequest("Usuario ID mismatch");
            }
            var updated = await _usuariosRepository.UpdateUsuarioAsync(new UESAN.INVES.CORE.Core.Entities.Usuarios
            {
                UsuarioId = usuarioDto.UsuarioId,
                Nombre = usuarioDto.Nombre,
                Apellido = usuarioDto.Apellido,
                Correo = usuarioDto.Correo,
                RolId = usuarioDto.RolId,
                Estado = usuarioDto.Estado,
                FechaRegistro = usuarioDto.FechaRegistro
            });
            if (updated == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> PostUsuario([FromBody] UsuariosDTO usuarioDto)
        {
            if (usuarioDto == null)
            {
                return BadRequest("Usuario cannot be null");
            }
            var createdUsuario = await _usuariosRepository.CreateUsuarioAsync(new UESAN.INVES.CORE.Core.Entities.Usuarios
            {
                Nombre = usuarioDto.Nombre,
                Apellido = usuarioDto.Apellido,
                Correo = usuarioDto.Correo,
                RolId = usuarioDto.RolId,
                Estado = usuarioDto.Estado,
                FechaRegistro = usuarioDto.FechaRegistro
            });
            return CreatedAtAction(nameof(GetUsuario), new { id = createdUsuario.UsuarioId }, createdUsuario);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            var result = await _usuariosRepository.DeleteUsuarioAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
