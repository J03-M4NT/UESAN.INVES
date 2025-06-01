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
        private readonly IUsuariosService _usuariosService;

        public UsuariosController(IUsuariosService usuariosService)
        {
            _usuariosService = usuariosService;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsuarios()
        {
            var usuarios = await _usuariosService.GetAllUsuariosAsync();
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUsuario(int id)
        {
            var usuario = await _usuariosService.GetUsuarioByIdAsync(id);
            if (usuario == null)
                return NotFound();
            return Ok(usuario);
        }

        [HttpPost("signin")]
        public async Task<IActionResult> SignIn([FromBody] SignInDTO signInDto)
        {
            var result = await _usuariosService.SignInAsync(signInDto);
            if (result == null)
                return Unauthorized("Credenciales inválidas");
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUsuario([FromBody] UsuariosCreateDTO dto)
        {
            var id = await _usuariosService.CreateUsuarioAsync(dto);
            return Ok(new { UsuarioId = id });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUsuario(int id, [FromBody] UsuariosUpdateDTO dto)
        {
            if (id != dto.UsuarioId)
                return BadRequest("ID mismatch");

            var success = await _usuariosService.UpdateUsuarioAsync(dto);
            if (!success)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            var deleted = await _usuariosService.DeleteUsuarioAsync(id);
            if (!deleted)
                return NotFound();
            return NoContent();
        }
    }
}
