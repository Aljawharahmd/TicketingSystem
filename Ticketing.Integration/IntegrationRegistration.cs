using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Refit;
using Ticketing.Integration.Abstraction;
using Ticketing.Integration.Options;
using Ticketing.Integration.Proxies;
using Ticketing.Integration.Services;

namespace Ticketing.Integration
{
    public static class IntegrationRegistration
    {
        public static IServiceCollection RegisterIntegrationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<BiometricOptions>(options => configuration.GetSection(nameof(BiometricOptions)).Bind(options));

            services.AddRefitClient<IBiometricsProxy>().ConfigureHttpClient(c =>
                c.BaseAddress = new Uri(configuration.GetSection("BiometricOptions:BaseAddress").Value));

            services.AddScoped<IBiometricValidator, BiometricValidator>();
            return services;
        }
    }
}
