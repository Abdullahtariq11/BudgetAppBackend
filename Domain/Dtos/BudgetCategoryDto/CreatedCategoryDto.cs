using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetApp.Domain.Dtos.BudgetCategoryDto
{
    public record CreatedCategoryDto(Guid id,decimal allocatedAmount, decimal remainingAmount, DateTime lastUpdated,string categoryName);

}