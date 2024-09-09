using BudgetApp.Application.Service;
using BudgetApp.Application.Service.Contracts;
using BudgetApp.Domain.Contracts;
using BudgetApp.Domain.Models;
using BudgetApp.Infrastructure;
using BudgetApp.Infrastructure.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

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
        public static void ConfigureIdentity(this IServiceCollection services){
            var builder=services.AddIdentity<User,IdentityRole>(o=>
            {
                o.Password.RequireDigit=true;
                o.Password.RequiredLength=8;
                o.Password.RequireUppercase=true;
                o.Password.RequireLowercase=true;
                o.Password.RequireNonAlphanumeric=false;
                o.User.RequireUniqueEmail=true;
            })
            .AddEntityFrameworkStores<RepositoryContext>()
            .AddDefaultTokenProviders();
        }
    }
}
