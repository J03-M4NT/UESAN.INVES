using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UESAN.INVES.CORE.Core.DTOs;
using UESAN.INVES.CORE.Core.Interfaces;
using UESAN.INVES.CORE.Infrastructure.Data;

namespace UESAN.INVES.CORE.Core.Services
{
    public class CategoriasService : ICategoriasService
    {
        private readonly ICategoriasRepository _categoriasRepository;

        public CategoriasService(ICategoriasRepository categoriasRepository)
        {
            _categoriasRepository = categoriasRepository;
        }

        public async Task<IEnumerable<CategoriasDTO>> GetAllCategoriasAsync()
        {
            var categorias = await _categoriasRepository.GetAllCategoriasAsync();
            return categorias.Select(c => new CategoriasDTO
            {
                CategoriaId = c.CategoriaId,
                NombreCategoria = c.NombreCategoria
            });
        }

        public async Task<CategoriasDTO?> GetCategoriaByIdAsync(int id)
        {
            var categoria = await _categoriasRepository.GetCategoriaByIdAsync(id);
            if (categoria == null) return null;
            return new CategoriasDTO
            {
                CategoriaId = categoria.CategoriaId,
                NombreCategoria = categoria.NombreCategoria
            };
        }

        public async Task<CategoriasDTO> CreateCategoriaAsync(CategoriasCreateDTO categoriaCreateDto)
        {
            var categoria = new Categorias
            {
                NombreCategoria = categoriaCreateDto.NombreCategoria
            };

            var createdCategoria = await _categoriasRepository.CreateCategoriaAsync(categoria);

            return new CategoriasDTO
            {
                CategoriaId = createdCategoria.CategoriaId,
                NombreCategoria = createdCategoria.NombreCategoria
            };
        }

        public async Task<CategoriasDTO?> UpdateCategoriaAsync(CategoriasUpdateDTO categoriaUpdateDto)
        {
            var categoria = new Categorias
            {
                CategoriaId = categoriaUpdateDto.CategoriaId,
                NombreCategoria = categoriaUpdateDto.NombreCategoria
            };

            var updatedCategoria = await _categoriasRepository.UpdateCategoriaAsync(categoria);
            if (updatedCategoria == null) return null;

            return new CategoriasDTO
            {
                CategoriaId = updatedCategoria.CategoriaId,
                NombreCategoria = updatedCategoria.NombreCategoria
            };
        }

        public async Task<bool> DeleteCategoriaAsync(int id)
        {
            return await _categoriasRepository.DeleteCategoriaAsync(id);
        }

    }
}
