using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace BudgetApp.Infrastructure.ContextFactory
{
    /// <summary>
    /// The primary purpose of this class is to support design-time operations for Entity Framework Core,
    /// such as creating and applying migrations.
    /// When EF Core tools need to create a DbContext instance outside of your application’s runtime
    /// (e.g., during migration generation), they use this factory.
    /// </summary>
    public class RepositoryContextFactory:IDesignTimeDbContextFactory<RepositoryContext>
    {
        public RepositoryContext CreateDbContext(string[] args)
        {
            var basePath = Directory.GetCurrentDirectory();
            var configuration= new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile(Path.Combine(basePath,"..","BudgetAppBackend","appsettings.json"))
                .Build();
            var builder = new DbContextOptionsBuilder<RepositoryContext>()
                .UseNpgsql(configuration.GetConnectionString("posgresConnectionString"));
            return new RepositoryContext(builder.Options);
                
        }
    }
}
