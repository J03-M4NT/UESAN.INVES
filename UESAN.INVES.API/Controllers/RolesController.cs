using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UESAN.INVES.CORE.Core.DTOs;
using UESAN.INVES.CORE.Core.Interfaces;

namespace UESAN.INVES.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRolesRepository _rolesRepository;
        public RolesController(IRolesRepository rolesRepository)
        {
            _rolesRepository = rolesRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetRoles()
        {
            var roles = await _rolesRepository.GetAllRolesAsync();
            return Ok(roles);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRol(int id)
        {
            var rol = await _rolesRepository.GetRoleByIdAsync(id);
            if (rol == null)
            {
                return NotFound();
            }
            return Ok(rol);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutRol(int id, [FromBody] RolesDTO rolDto)
        {
            if (id != rolDto.RolId)
            {
                return BadRequest("Rol ID mismatch");
            }
            var updated = await _rolesRepository.UpdateRoleAsync(new UESAN.INVES.CORE.Core.Entities.Roles
            {
                RolId = rolDto.RolId,
                NombreRol = rolDto.NombreRol
            });
            if (updated == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> PostRol([FromBody] RolesDTO rolDto)
        {
            if (rolDto == null)
            {
                return BadRequest("Rol cannot be null");
            }
            var createdRol = await _rolesRepository.CreateRoleAsync(new UESAN.INVES.CORE.Core.Entities.Roles
            {
                NombreRol = rolDto.NombreRol
            });
            return CreatedAtAction(nameof(GetRol), new { id = createdRol.RolId }, createdRol);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRol(int id)
        {
            var result = await _rolesRepository.DeleteRoleAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
