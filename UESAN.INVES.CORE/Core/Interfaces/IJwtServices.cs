using UESAN.INVES.CORE.Core.Entities;

namespace UESAN.INVES.CORE.Core.Interfaces
{
    public interface IJwtServices
    {
        string GenerateToken(Usuarios usuario);
    }
}