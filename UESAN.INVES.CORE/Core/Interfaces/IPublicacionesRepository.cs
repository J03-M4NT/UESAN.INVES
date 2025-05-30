using UESAN.INVES.CORE.Core.Entities;

namespace UESAN.INVES.CORE.Core.Interfaces
{
    public interface IPublicacionesRepository
    {
        Task<Publicaciones> CreatePublicacionAsync(Publicaciones publicacion);
        Task<bool> DeletePublicacionAsync(int id);
        IEnumerable<Publicaciones> GetAllPublicaciones();
        Task<List<Publicaciones>> GetAllPublicacionesAsync();
        Task<Publicaciones?> GetPublicacionByIdAsync(int id);
        Task<List<Publicaciones>> GetPublicacionesByCategoryIdAsync(int categoryId);
        Task<List<Publicaciones>> GetPublicacionesByUserIdAsync(int userId);
        Task<Publicaciones?> UpdatePublicacionAsync(Publicaciones publicacion);
    }
}