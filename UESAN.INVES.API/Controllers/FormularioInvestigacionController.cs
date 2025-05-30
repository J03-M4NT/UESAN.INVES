using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UESAN.INVES.CORE.Core.DTOs;
using UESAN.INVES.CORE.Core.Interfaces;

namespace UESAN.INVES.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormularioInvestigacionController : ControllerBase
    {
        private readonly IFormularioInvestigacionService _formularioService;
        public FormularioInvestigacionController(IFormularioInvestigacionService formularioService)
        {
            _formularioService = formularioService;
        }

        [HttpGet]
        public async Task<IActionResult> GetFormularios()
        {
            var formularios = await _formularioService.GetAllFormulariosAsync();
            return Ok(formularios);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFormulario(int id)
        {
            var formulario = await _formularioService.GetFormularioByIdAsync(id);
            if (formulario == null)
            {
                return NotFound();
            }
            return Ok(formulario);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutFormulario(int id, [FromBody] FormularioInvestigacionUpdateDTO formularioUpdateDto)
        {
            if (id != formularioUpdateDto.FormularioId)
            {
                return BadRequest("Formulario ID mismatch");
            }
            var updated = await _formularioService.UpdateFormularioAsync(formularioUpdateDto);
            if (!updated)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> PostFormulario([FromBody] FormularioInvestigacionCreateDTO formularioCreateDto)
        {
            if (formularioCreateDto == null)
            {
                return BadRequest("Formulario cannot be null");
            }
            var createdFormulario = await _formularioService.CreateFormularioAsync(formularioCreateDto);
            return CreatedAtAction(nameof(GetFormulario), new { id = createdFormulario.FormularioId }, createdFormulario);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFormulario(int id)
        {
            var result = await _formularioService.DeleteFormularioAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
