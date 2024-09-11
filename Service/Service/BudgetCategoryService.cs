using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BudgetApp.Application.Service.Contracts;
using BudgetApp.Domain.Contracts;
using BudgetApp.Domain.Models;
using BudgetApp.Shared.Dtos.BudgetCategoryDto;

namespace BudgetApp.Application.Service
{
    public class BudgetCategoryService:IBudgetCategoryService
    {
        private readonly IRepositoryManager _repositoryManager;

        public BudgetCategoryService(IRepositoryManager repositoryManager)
          {
            _repositoryManager = repositoryManager;
        }

        public async Task<CreatedCategoryDto> CreateBudgetCategoryForUserAsync(string userId, CreatedCategoryDto budgetCategoryDto,bool trackChanges)
        {
            var budgets= await _repositoryManager.BudgetCategoryRepository.GetAllAsync(userId,trackChanges);
            if(budgets==null||budgetCategoryDto==null)
            {
                return null;
            }
            var budgetCategory = new BudgetCategory
            {
                AllocatedAmount=budgetCategoryDto.allocatedAmount,
                RemainingAmount=budgetCategoryDto.remainingAmount,
                CategoryName=budgetCategoryDto.categoryName,    
                LastUpdated=budgetCategoryDto.lastUpdated

            };

            _repositoryManager.BudgetCategoryRepository.CreateBudgetCategory(userId,budgetCategory);
            _repositoryManager.Save();
            return budgetCategoryDto;
        }

        public async Task<BudgetCategory> DeleteBudgetCategoryForUserAsync(string userId, Guid id)
        {
            var budget= await _repositoryManager.BudgetCategoryRepository.GetByIdAsync(userId,id,trackChanges:true);
            if(budget==null){
                return null;
            }
             _repositoryManager.BudgetCategoryRepository.DeleteBudgetCategory(budget);
             _repositoryManager.Save();
            return budget;
           
        }

        public async Task<ICollection<BudgetCategory>> GetBudgetCategoriesAsync(string userId, bool trackChanges)
        {
            var budgets=await _repositoryManager.BudgetCategoryRepository.GetAllAsync(userId,trackChanges);
            return budgets;      
        }
        public async Task<BudgetCategory> GetBudgetCategoryByIdAsync(string userId,Guid id, bool trackChanges)
        {
            var budget=await _repositoryManager.BudgetCategoryRepository.GetByIdAsync(userId,id,trackChanges);
            return budget;
        }

        public async Task<CreatedCategoryDto> UpdateBudgetCategoryForUserAsync(string userId,Guid id, CreatedCategoryDto budgetCategory, bool trackChanges)
        {
            var budget = await _repositoryManager.BudgetCategoryRepository.GetByIdAsync(userId, id, trackChanges);
            if (budget == null)
            {
                return null;
            }
            budget.AllocatedAmount=budgetCategory.allocatedAmount;
            budget.CategoryName=budgetCategory.categoryName;
            budget.RemainingAmount=budgetCategory.remainingAmount;
            budget.LastUpdated=budgetCategory.lastUpdated;
            _repositoryManager.BudgetCategoryRepository.UpdateBudgetCategory(userId,budget);
            _repositoryManager.Save();
            return budgetCategory;
        }
    }
}
