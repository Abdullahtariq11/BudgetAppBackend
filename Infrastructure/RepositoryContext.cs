using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BudgetApp.Domain.Models;
using BudgetApp.Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;

namespace BudgetApp.Infrastructure
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Remove OwnsMany and instead use a regular relationship
            modelBuilder.Entity<Budget>().HasMany(b => b.Categories)
                .WithOne()
                .HasForeignKey(c => c.BudgetId);
            /// Applyconfiguration is used apply configuration defined in EntityTypeConfiguration
            modelBuilder.ApplyConfiguration(new BudgetConfiguration());
            modelBuilder.ApplyConfiguration(new TransactionConfiguration());

        }
        /// <summary>
        /// Db sets Defined which generate tables in database
        /// </summary>
        public DbSet<Budget> Budgets { get; set; }
        public DbSet<BudgetCategory> BudgetCategories { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
    }
}
