using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UESAN.INVES.CORE.Core.Settings;
using UESAN.INVES.CORE.Core.Interfaces;


namespace UESAN.INVES.CORE.Infrastructure.Shared
{
    public static class ServiceRegistration
    {
        public static void AddSharedInfrastructure(this IServiceCollection services, IConfiguration _config)
        {
            services.Configure<JWTSettings>(_config.GetSection("JWTSettings"));

            // REGISTRA JWT SERVICE
            var jwtSettings = _config.GetSection("JWTSettings").Get<JWTSettings>();
            services.AddSingleton<IJwtServices>(new JwtServices(
                jwtSettings.SecretKey,
                jwtSettings.Issuer,
                jwtSettings.Audience,
                (int)jwtSettings.DurationInMinutes));
        }
    }
}