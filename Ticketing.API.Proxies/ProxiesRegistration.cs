using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Refit;

namespace Ticketing.API.Proxies
{
    public static class ProxiesRegistration
    {
        public static IServiceCollection RegisterApiProxies(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var apiUrl = new Uri(configuration.GetSection("APIOptions:BaseAddress").Value);
            services.AddRefitClient<IAccountProxy>().ConfigureHttpClient(c => c.BaseAddress = apiUrl);
            services.AddRefitClient<IClientProxy>().ConfigureHttpClient(c => c.BaseAddress = apiUrl);
            services.AddRefitClient<IStaffMemberProxy>().ConfigureHttpClient(c => c.BaseAddress = apiUrl);
            services.AddRefitClient<IProductProxy>().ConfigureHttpClient(c => c.BaseAddress = apiUrl);
            services.AddRefitClient<IReplyProxy>().ConfigureHttpClient(c => c.BaseAddress = apiUrl);
            services.AddRefitClient<ITicketProxy>().ConfigureHttpClient(c => c.BaseAddress = apiUrl);
            services.AddRefitClient<IStatisticProxy>().ConfigureHttpClient(c => c.BaseAddress = apiUrl);
            services.AddRefitClient<IFileProxy>().ConfigureHttpClient(c => c.BaseAddress = apiUrl);
            services.AddRefitClient<IOtpProxy>().ConfigureHttpClient(c => c.BaseAddress = apiUrl);

            return services;
        }
    }
}
