using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BudgetApp.Domain.Models;

namespace BudgetApp.Domain.Contracts
{
    public interface IBudgetCategoryRepository
    {
        public Task<ICollection<BudgetCategory>> GetAllAsync(string userId,bool trackChanges);
        public Task<BudgetCategory> GetByIdAsync(string userId,Guid categoryId,bool trackChanges);

        public void CreateBudgetCategory(string userId,BudgetCategory category);
        public void UpdateBudgetCategory(string userId,BudgetCategory category);
        public void DeleteBudgetCategory(BudgetCategory category);
    }
}
