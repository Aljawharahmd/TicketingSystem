using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Ticketing.API.Proxies;
using Ticketing.Integration;
using Ticketing.Logging;
using Ticketing.Notification;
using Ticketing.Notification.Options;
using Ticketing.Security.Authentication.Abstractions;
using Ticketing.Security.Authentication.Middlewares;
using Ticketing.Security.Authentication.Options;
using Ticketing.Security.Authentication.Validation;
using Ticketing.Storage;
using Ticketing.Trace.Abstraction;
using Ticketing.Trace.Services;

namespace Ticketing.Staff.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.Configure<JtwOptions>(options => Configuration.GetSection(nameof(JtwOptions)).Bind(options));
            services.Configure<SmtpOptions>(options => Configuration.GetSection(nameof(SmtpOptions)).Bind(options));
            services.Configure<SmsOptions>(options => Configuration.GetSection(nameof(SmsOptions)).Bind(options));
            services.Configure<StorageOptions>(options => Configuration.GetSection(nameof(StorageOptions)).Bind(options));

            services.AddScoped<ITokenValidator, TokenValidator>();
            services.AddScoped<IRequestTrace, RequestTrace>();

            services.AddMvc();
            services.RegisterNotificationServices(Configuration);
            services.RegisterIntegrationServices(Configuration);
            services.RegisterApiProxies(Configuration);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseMiddleware<MvcRequestResponseLoggingMiddleware>();
            app.UseMiddleware<MvcJwtMiddleware>();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
