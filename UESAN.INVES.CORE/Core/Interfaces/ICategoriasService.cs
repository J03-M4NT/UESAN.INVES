using UESAN.INVES.CORE.Core.DTOs;

namespace UESAN.INVES.CORE.Core.Interfaces
{
    public interface ICategoriasService
    {
        Task<CategoriasDTO> CreateCategoriaAsync(CategoriasCreateDTO categoriaCreateDto);
        Task<bool> DeleteCategoriaAsync(int id);
        Task<IEnumerable<CategoriasDTO>> GetAllCategoriasAsync();
        Task<CategoriasDTO?> GetCategoriaByIdAsync(int id);
        Task<CategoriasDTO?> UpdateCategoriaAsync(CategoriasUpdateDTO categoriaUpdateDto);
    }
}