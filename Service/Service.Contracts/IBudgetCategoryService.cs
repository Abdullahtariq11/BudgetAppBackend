using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BudgetApp.Domain.Dtos.BudgetCategoryDto;
using BudgetApp.Domain.Models;


namespace BudgetApp.Application.Service.Contracts
{
    public interface IBudgetCategoryService
    {
        public Task<ICollection<BudgetCategory>> GetBudgetCategoriesAsync(string userId,bool trackChanges);
        public  Task<BudgetCategory> GetBudgetCategoryByIdAsync(string userId,Guid id, bool trackChanges);
        public  Task<CreatedCategoryDto> CreateBudgetCategoryForUserAsync(string userId, CreatedCategoryDto budgetCategory,bool trackChanges);
        public  Task<BudgetCategory> DeleteBudgetCategoryForUserAsync(string userId,Guid id);
        public Task<CreatedCategoryDto> UpdateBudgetCategoryForUserAsync(string userId,Guid id, CreatedCategoryDto budgetCategory, bool trackChanges);
    }
}
