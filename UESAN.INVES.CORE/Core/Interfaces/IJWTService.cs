using UESAN.INVES.CORE.Core.Settings;

namespace UESAN.INVES.CORE.Core.Interfaces
{
    public interface IJWTService
    {
        JWTSettings _settings { get; }

        string GenerateJWToken(User user);
    }
}