using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UESAN.INVES.CORE.Core.DTOs;
using UESAN.INVES.CORE.Core.Interfaces;

namespace UESAN.INVES.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly ICategoriasService _categoriasService;
        public CategoriasController(ICategoriasService categoriasService)
        {
            _categoriasService = categoriasService;
        }

        // GET: api/Categorias
        [HttpGet]
        public async Task<IActionResult> GetCategorias()
        {
            var categorias = await _categoriasService.GetAllCategoriasAsync();
            return Ok(categorias);
        }

        // GET: api/Categorias/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoria(int id)
        {
            var categoria = await _categoriasService.GetCategoriaByIdAsync(id);
            if (categoria == null)
            {
                return NotFound();
            }
            return Ok(categoria);
        }

        // PUT: api/Categorias/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategoria(int id, [FromBody] CategoriasUpdateDTO categoriaUpdateDto)
        {
            if (id != categoriaUpdateDto.CategoriaId)
            {
                return BadRequest("Categoria ID mismatch");
            }
            var updated = await _categoriasService.UpdateCategoriaAsync(categoriaUpdateDto);
            if (updated == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        // POST: api/Categorias
        [HttpPost]
        public async Task<IActionResult> PostCategoria([FromBody] CategoriasCreateDTO categoriaCreateDto)
        {
            if (categoriaCreateDto == null)
            {
                return BadRequest("Categoria cannot be null");
            }
            var createdCategoria = await _categoriasService.CreateCategoriaAsync(categoriaCreateDto);
            return CreatedAtAction(nameof(GetCategoria), new { id = createdCategoria.CategoriaId }, createdCategoria);
        }

        // DELETE: api/Categorias/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoria(int id)
        {
            var result = await _categoriasService.DeleteCategoriaAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
