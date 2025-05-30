using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UESAN.INVES.CORE.Core.Interfaces;
namespace UESAN.INVES.CORE.Core.Settings
{
    public class JWTSettings : IJWTSettings
    {
        public string SecretKey { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public double DurationInMinutes { get; set; }

    }

}