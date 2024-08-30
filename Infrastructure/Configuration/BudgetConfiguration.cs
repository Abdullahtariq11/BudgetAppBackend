using BudgetApp.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

public class BudgetConfiguration : IEntityTypeConfiguration<Budget>
{
    public void Configure(EntityTypeBuilder<Budget> builder)
    {
        var budgetId = Guid.NewGuid();

        builder.HasData(
            new Budget
            {
                Id = budgetId,
                Name = "Monthly Budget",
                TotalAmount = 2000m,
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.UtcNow.AddMonths(1),
                Categories = new List<BudgetCategory>()
            }
        );

      
    }
}
