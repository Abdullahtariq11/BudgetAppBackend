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
    public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            // Configure relationship between Transaction and User
            builder.HasOne(t => t.User)
                   .WithMany(u => u.Transactions)
                   .HasForeignKey(t => t.UserID)
                   .OnDelete(DeleteBehavior.Cascade);

            // Configure relationship between Transaction and Card
            builder.HasOne(t => t.Card)
                   .WithMany(c => c.Transactions)
                   .HasForeignKey(t => t.CardId)
                   .OnDelete(DeleteBehavior.SetNull);

            // Configure relationship between Transaction and budgetCategory
            builder.HasOne(t => t.BudgetCategory)
                   .WithMany(bc => bc.Transactions)
                   .HasForeignKey(t => t.BudgetCategoryId)
                   .OnDelete(DeleteBehavior.SetNull);

            // Seed data for Transactions
            /*
            var userId = "a29f7b85-9f5f-4b0e-9497-9c6f91b8b1c4"; // Use the correct user ID
            var cardId = "54e0c90e-1e91-42d1-8d24-8e00fa63ec0b"; // Use correct card ID
            //var budgetCategoryId = "c52f7b85-4d5e-4b0e-9497-9c6f91b8c9d1"; // Use a correct or existing budget category ID
            builder.HasData(
                new Transaction
                {
                    Id = Guid.NewGuid(),
                    Amount = 200,
                    Type = TransactionType.Expense,
                    Category = "Groceries",
                    Description = "Weekly groceries",
                    TransactionDate = DateTime.UtcNow,
                    UserID = userId,
                    CardId = Guid.Parse(cardId),
                    BudgetCategoryId = null // This can be set to null if optional
                },
                new Transaction
                {
                    Id = Guid.NewGuid(),
                    Amount = 500,
                    Type = TransactionType.Income,
                    Category = "Freelance",
                    Description = "Web development project",
                    TransactionDate = DateTime.UtcNow,
                    UserID = userId,
                    CardId = Guid.Parse(cardId),
                    BudgetCategoryId = null // Budget category is not mandatory here
                }
            );*/
        }
    }
}