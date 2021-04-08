using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Refit;
using Ticketing.Notification.Abstraction;
using Ticketing.Notification.Options;
using Ticketing.Notification.Proxies;
using Ticketing.Notification.Services;

namespace Ticketing.Notification
{
    public static class NotificationRegistration
    {
        public static IServiceCollection RegisterNotificationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<SmsOptions>(options => configuration.GetSection(nameof(SmsOptions)).Bind(options));
            services.Configure<SmtpOptions>(options => configuration.GetSection(nameof(SmtpOptions)).Bind(options));

            services.AddRefitClient<IRichProxy>().ConfigureHttpClient(c => c.BaseAddress = new Uri(configuration.GetSection("SmsOptions:Server").Value));

            services.AddScoped<ISmsSender, RichSmsSender>();
            services.AddScoped<IEmailSender, EmailSender>();
            return services;
        }
    }
}
