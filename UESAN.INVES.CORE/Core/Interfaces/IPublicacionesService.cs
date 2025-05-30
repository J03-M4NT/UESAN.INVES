using UESAN.INVES.CORE.Core.DTOs;

namespace UESAN.INVES.CORE.Core.Interfaces
{
    public interface IPublicacionesService
    {
        Task<PublicacionesDTO> CreatePublicacionAsync(PublicacionesCreateDTO dto);
        Task<bool> DeletePublicacionAsync(int id);
        Task<IEnumerable<PublicacionesDTO>> GetAllPublicacionesAsync();
        Task<PublicacionesDTO?> GetPublicacionByIdAsync(int id);
        Task<IEnumerable<PublicacionesResumenDTO>> GetResumenPublicacionesAsync();
        Task<PublicacionesDTO?> UpdatePublicacionAsync(PublicacionesUpdateDTO dto);
    }
}