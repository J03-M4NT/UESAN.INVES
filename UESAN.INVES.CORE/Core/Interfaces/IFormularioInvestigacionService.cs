using UESAN.INVES.CORE.Core.DTOs;

namespace UESAN.INVES.CORE.Core.Interfaces
{
    public interface IFormularioInvestigacionService
    {
        Task<FormularioInvestigacionDTO> CreateFormularioAsync(FormularioInvestigacionCreateDTO dto);
        Task<bool> DeleteFormularioAsync(int id);
        Task<IEnumerable<FormularioInvestigacionDTO>> GetAllFormulariosAsync();
        Task<FormularioInvestigacionDTO?> GetFormularioByIdAsync(int id);
        Task<bool> UpdateFormularioAsync(FormularioInvestigacionUpdateDTO dto);
    }
}