using UESAN.INVES.CORE.Infrastructure.Data;

namespace UESAN.INVES.CORE.Core.Interfaces
{
    public interface ICategoriasRepository
    {
        Task<Categorias> CreateCategoriaAsync(Categorias categoria);
        Task<bool> DeleteCategoriaAsync(int id);
        IEnumerable<Categorias> GetAllCategorias();
        Task<List<Categorias>> GetAllCategoriasAsync();
        Task<Categorias?> GetCategoriaByIdAsync(int id);
        Task<Categorias?> UpdateCategoriaAsync(Categorias categoria);
    }
}