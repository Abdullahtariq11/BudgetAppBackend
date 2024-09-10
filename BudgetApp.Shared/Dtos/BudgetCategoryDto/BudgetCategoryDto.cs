using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetApp.Shared.Dtos.BudgetCategoryDto
{
    public record BudgetCategoryDto(decimal allocatedAmount, decimal remainingAmount, DateTime lastUpdated,string categoryName,string userId);

}