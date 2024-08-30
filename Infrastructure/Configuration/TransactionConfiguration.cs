using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BudgetApp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BudgetApp.Infrastructure.Configuration
{
    public class TransactionConfiguration:IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.HasData
                (
                new Transaction
                {
                    Id = Guid.NewGuid(),
                    Amount = 1000m,
                    TransactionDate = DateTime.UtcNow.AddMonths(-1),
                    Category = "Salary",
                    Type = TransactionType.Income,
                    Description = "Monthly salary"
                },
                new Transaction
                {
                    Id = Guid.NewGuid(),
                    Amount = 200m,
                    TransactionDate = DateTime.UtcNow.AddDays(-10),
                    Category = "Groceries",
                    Type = TransactionType.Expense,
                    Description = "Weekly groceries"
                },
                new Transaction
                {
                    Id = Guid.NewGuid(),
                    Amount = 50m,
                    TransactionDate = DateTime.UtcNow.AddDays(-5),
                    Category = "Entertainment",
                    Type = TransactionType.Expense,
                    Description = "Movie night"
                }

                );
        }
    }
}
