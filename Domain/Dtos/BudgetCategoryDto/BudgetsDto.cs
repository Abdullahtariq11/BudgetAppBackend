using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudgetApp.Domain.Models;

namespace Domain.Dtos.BudgetCategoryDto
{
     public record BudgetsDto(ICollection<BudgetCategory> budgets,int? pageSize,int? pageNumber,int totalItems);
}
