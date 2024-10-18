using BudgetApp.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

public class BudgetConfiguration : IEntityTypeConfiguration<BudgetCategory>
{
    public void Configure(EntityTypeBuilder<BudgetCategory> builder)
    {
        var budgetId = Guid.NewGuid();

        // Configure relationship between BudgetCategory and User
        builder.HasOne(bc => bc.User)
               .WithMany(u => u.BudgetCategories)
               .HasForeignKey(bc => bc.UserID)
               .OnDelete(DeleteBehavior.Cascade);

        // Configure relationship between Card and Transactions
        builder.HasMany(bc => bc.Transactions)
               .WithOne(t => t.BudgetCategory)
               .HasForeignKey(t => t.BudgetCategoryId)
               .OnDelete(DeleteBehavior.SetNull);

        // Seed data for Budget Categories
        /*
        var userId = "a29f7b85-9f5f-4b0e-9497-9c6f91b8b1c4"; // Use the correct user ID
        builder.HasData(
            new BudgetCategory
            {
                Id =  Guid.Parse("c52f7b85-4d5e-4b0e-9497-9c6f91b8c9d1"),
                CategoryName = "Groceries",
                AllocatedAmount = 500,
                LastUpdated = DateTime.UtcNow,
                UserID = userId
            },
            new BudgetCategory
            {
                Id = Guid.NewGuid(),
                CategoryName = "Entertainment",
                AllocatedAmount = 200,
                LastUpdated = DateTime.UtcNow.AddMonths(1),
                UserID = userId
            }
        );
        */


    }
}
