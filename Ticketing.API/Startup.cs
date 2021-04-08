using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Ticketing.Application.Services;
using Ticketing.Application.Services.Abstraction;
using Ticketing.Application.Services.Validation;
using Ticketing.Logging;
using Ticketing.Persistence;
using Ticketing.Protection.Options;
using Ticketing.Protection.Services;
using Ticketing.Protection.Services.Abstraction;
using Ticketing.Security.Authentication.Abstractions;
using Ticketing.Security.Authentication.Middlewares;
using Ticketing.Security.Authentication.Options;
using Ticketing.Security.Authentication.Validation;
using Ticketing.Storage;
using Ticketing.Storage.Abstractions;
using Ticketing.Trace.Abstraction;
using Ticketing.Trace.Services;

namespace Ticketing.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddControllers();
            services.Configure<JtwOptions>(options => Configuration.GetSection(nameof(JtwOptions)).Bind(options)); 
            services.Configure<OtpOptions>(options => Configuration.GetSection(nameof(OtpOptions)).Bind(options));
            services.Configure<StorageOptions>(options => Configuration.GetSection(nameof(StorageOptions)).Bind(options));
            services.AddScoped<ITokenValidator, TokenValidator>();
            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<IStaffMemberService, StaffMemberService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IReplyService, ReplyService>();
            services.AddScoped<ITicketService, TicketService>();
            services.AddScoped<IFileStorage, FileStorage>();
            services.AddScoped<IPathGenerator, PathGenerator>();
            services.AddScoped<IPasswordProtectionService, PasswordProtectionService>();
            services.AddScoped<IStorageService, StorageService>();
            services.AddScoped<IStatisticService, StatisticService>();
            services.AddScoped<IUserManagerAuthentication, UserManagerAuthentication>();
            services.AddScoped<IJwtMangerAuthentication, JwtMangerAuthentication>();
            services.AddScoped<IProductValidation,ProductValidation>();
            services.AddScoped<IClientValidation,ClientValidation>();
            services.AddScoped<IStaffMemberValidation,StaffMemberValidation>();
            services.AddScoped<IStorageValidation, StorageValidation>();
            services.AddScoped<IOtpService, OtpService>();
            services.AddScoped<IRequestTrace, RequestTrace>();

            services.AddHealthChecks()
                    .AddMySql(Configuration["DefaultConnection"]);

            services.AddDbContext<TicketingDbContext>(options =>
                options.UseMySQL(Configuration.GetConnectionString("DefaultConnection"))
            );
            services.AddSwaggerDocument();
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHealthChecks("/health");

            app.UseSwaggerUi3();

            app.UseOpenApi();

            app.UseHttpsRedirection();

            app.UseSerilogRequestLogging();

            app.UseRouting();

            app.UseMiddleware<ApiJwtMiddleware>();  

           // app.UseMiddleware<ApiRequestResponseLoggingMiddleware>();

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseAuthentication();

            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
