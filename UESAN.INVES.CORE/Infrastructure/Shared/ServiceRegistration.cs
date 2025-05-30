using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace UESAN.INVES.CORE.Infrastructure.Shared
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddJwtServices(this IServiceCollection services, string secretKey, string issuer, string audience, int expirationMinutes)
        {
            services.AddSingleton(new JwtServices(secretKey, issuer, audience, expirationMinutes));
            return services;
        }
    }
}