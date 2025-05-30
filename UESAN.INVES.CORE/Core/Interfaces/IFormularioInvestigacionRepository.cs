using UESAN.INVES.CORE.Core.Entities;

namespace UESAN.INVES.CORE.Core.Interfaces
{
    public interface IFormularioInvestigacionRepository
    {
        Task<FormularioInvestigacion> CreateFormularioInvestigacionAsync(FormularioInvestigacion formulario);
        Task<bool> DeleteFormularioInvestigacionAsync(int id);
        IEnumerable<FormularioInvestigacion> GetAllFormulariosInvestigacion();
        Task<List<FormularioInvestigacion>> GetAllFormulariosInvestigacionAsync();
        Task<FormularioInvestigacion?> GetFormularioInvestigacionByIdAsync(int id);
        Task<List<FormularioInvestigacion>> GetFormulariosByUserIdAsync(int userId);
        Task<bool> UpdateFormularioInvestigacionAsync(FormularioInvestigacion formulario);
    }
}