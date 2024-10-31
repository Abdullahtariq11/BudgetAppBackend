using System.Security.Claims;
using System.Text;
using BudgetApp.Application.Service;
using BudgetApp.Application.Service.Contracts;
using BudgetApp.Domain.Contracts;
using BudgetApp.Domain.Models;
using BudgetApp.Infrastructure;
using BudgetApp.Infrastructure.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using Serilog.Configuration;
using Serilog.Events;

namespace BudgetApp.API.Extension
{
    public static class ServiceExtensions
    {
        public static void ConfigureRepositoryManager(this IServiceCollection services) => services.AddScoped<IRepositoryManager, RepositoryManager>();
        public static void ConfigureServiceManager(this IServiceCollection services) => services.AddScoped<IServiceManager, ServiceManager>();
        public static void ConfigurePosgreSqlContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<RepositoryContext>(opts => opts.UseNpgsql(configuration.GetConnectionString("posgresConnectionString")));
        }
        /// <summary>
        /// Adding and Configuring identity.
        /// </summary>
        public static void ConfigureIdentity(this IServiceCollection services)
        {
            var builder = services.AddIdentity<User, IdentityRole>(o =>
            {
                o.Password.RequireDigit = true;
                o.Password.RequiredLength = 8;
                o.Password.RequireUppercase = true;
                o.Password.RequireLowercase = true;
                o.Password.RequireNonAlphanumeric = false;
                o.User.RequireUniqueEmail = true;
            })
            .AddEntityFrameworkStores<RepositoryContext>()
            .AddDefaultTokenProviders();
        }
        /// <summary>
        /// Configure Serilog
        /// </summary>

        //configure serilog using fluent method
        public static void ConfigureSerilog(this IHostBuilder host)
        {
            host.UseSerilog((context, configuration) =>
            {
                configuration.ReadFrom.Configuration(context.Configuration)
                .MinimumLevel.Override("Microsoft", LogEventLevel.Warning);
            });
        }

        /// <summary>
        /// Configure JWT token
        /// </summary>

        public static void ConfigureJWT(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["JWT:Issuer"],
                    ValidAudience = configuration["JWT:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Key"]))

                };
                // Add the SecurityStamp validation logic here
                options.Events = new JwtBearerEvents
                {
                    OnTokenValidated = async context =>
                    {
                        var userManager = context.HttpContext.RequestServices.GetRequiredService<UserManager<User>>();
                        var userId = context.Principal.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                        var user = await userManager.FindByIdAsync(userId);

                        if (user == null || user.SecurityStamp != context.Principal.FindFirst("SecurityStamp")?.Value)
                        {
                            context.Fail("Unauthorized");
                        }
                    }
                };
            });
        }

    }
}
