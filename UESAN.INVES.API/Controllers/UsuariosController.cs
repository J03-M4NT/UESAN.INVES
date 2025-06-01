using Microsoft.AspNetCore.Mvc;
using UESAN.INVES.CORE.Core.DTOs;
using UESAN.INVES.CORE.Core.Interfaces;

[ApiController]
[Route("api/[controller]")]
public class UsuariosController : ControllerBase
{
    private readonly IUsuariosService _usuariosService;
    private readonly IJWTService _jwtService;

    public UsuariosController(IUsuariosService usuariosService, IJWTService jwtService)
    {
        _usuariosService = usuariosService;
        _jwtService = jwtService;
    }

    [HttpPost("singln")]
    public async Task<IActionResult> SingIn([FromBody] UsuarioLoginDTO loginDto)
    {
        var usuario = await _usuariosService.AutenticarAsync(loginDto.Email, loginDto.Password);
        if (usuario == null)
            return Unauthorized();

        var token = _jwtService.GenerateToken(usuario);

        var response = new UsuarioLoginResponseDTO
        {
            Id = usuario.Id,
            Email = usuario.Email,
            Nombre = usuario.Nombre,
            Token = token
            // Agrega otros campos si es necesario
        };

        return Ok(response);
    }
}