using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UESAN.INVES.CORE.Core.DTOs;
using UESAN.INVES.CORE.Core.Entities;
using UESAN.INVES.CORE.Core.Interfaces;

namespace UESAN.INVES.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccesosController : ControllerBase
    {
        private readonly IAccesosRepository _accesosRepository;
        public AccesosController(IAccesosRepository accesosRepository)
        {
            _accesosRepository = accesosRepository;
        }

        // GET: api/Accesos
        [HttpGet]
        public async Task<IActionResult> GetAccesos()
        {
            var accesos = await _accesosRepository.GetAllAccesosAsync();
            return Ok(accesos);
        }

        // GET: api/Accesos/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAcceso(int id)
        {
            var acceso = await _accesosRepository.GetAccesoByIdAsync(id);
            if (acceso == null)
            {
                return NotFound();
            }
            return Ok(acceso);
        }


        //PUT: api/Accesos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAcceso(int id, [FromBody] Accesos acceso)
        {
            if (id != acceso.AccesoId)
            {
                return BadRequest("Acceso ID mismatch");
            }
            var existingAcceso = await _accesosRepository.GetAccesoByIdAsync(id);
            if (existingAcceso == null)
            {
                return NotFound();
            }
            var updated = await _accesosRepository.UpdateAccesoAsync(acceso);
            if (!updated)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating access record");
            }
            return NoContent();
        }


        // POST: api/Accesos
        [HttpPost]
        public async Task<IActionResult> PostAcceso([FromBody] Accesos acceso)
        {
            if (acceso == null)
            {
                return BadRequest("Acceso cannot be null");
            }
            var createdAcceso = await _accesosRepository.CreateAccesoAsync(acceso);
            return CreatedAtAction(nameof(GetAcceso), new { id = createdAcceso.AccesoId }, createdAcceso);
        }


        //Delete : api/Accesos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAcceso(int id)
        {
            var result = await _accesosRepository.DeleteAccesosAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }


    }
}
