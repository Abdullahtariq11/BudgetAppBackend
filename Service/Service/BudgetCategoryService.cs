using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BudgetApp.Application.Service.Contracts;
using BudgetApp.Domain.Contracts;
using BudgetApp.Domain.Dtos.BudgetCategoryDto;
using BudgetApp.Domain.Models;
using BudgetApp.Shared.RequestFeatures;
using Domain.Dtos.BudgetCategoryDto;
using Domain.Exceptions;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BudgetApp.Application.Service
{
    public class BudgetCategoryService : IBudgetCategoryService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILogger _logger;

        public BudgetCategoryService(IRepositoryManager repositoryManager, ILogger<BudgetCategoryService> logger)
        {
            _repositoryManager = repositoryManager;
            _logger = logger;
        }

        public async Task<CreatedCategoryDto> CreateBudgetCategoryForUserAsync(string userId, CreatedCategoryDto budgetCategoryDto, bool trackChanges)
        {

            _logger.LogInformation("Budget category {CategoryName} created for user {UserId}", budgetCategoryDto.categoryName, userId);

            var budgets = await _repositoryManager.BudgetCategoryRepository.GetAllAsync(userId, trackChanges);

            if (budgets == null || budgetCategoryDto == null)
            {
                throw new NotFoundException($"User with {userId} is not found");
            }
            var budgetCategory = new BudgetCategory
            {
                AllocatedAmount = budgetCategoryDto.allocatedAmount,
                RemainingAmount = budgetCategoryDto.remainingAmount,
                CategoryName = budgetCategoryDto.categoryName,
                LastUpdated = budgetCategoryDto.lastUpdated

            };

            _repositoryManager.BudgetCategoryRepository.CreateBudgetCategory(userId, budgetCategory);
            _repositoryManager.Save();
            return budgetCategoryDto;
        }

        public async Task<BudgetCategory> DeleteBudgetCategoryForUserAsync(string userId, Guid id)
        {
            var budget = await _repositoryManager.BudgetCategoryRepository.GetByIdAsync(userId, id, trackChanges: true);

            if (budget == null)
            {
                throw new NotFoundException($"Budget category with id {id} not found for user {userId}");
            }
            _repositoryManager.BudgetCategoryRepository.DeleteBudgetCategory(budget);
            _repositoryManager.Save();
            return budget;

        }

        public async Task<BudgetsDto> GetBudgetCategoriesAsync(string userId, BudgetParameter budgetParameter, bool trackChanges)
        {

            var querry = await _repositoryManager.BudgetCategoryRepository.GetAllAsync(userId, trackChanges);

            if (budgetParameter.HasValidFilter())
            {
                if (budgetParameter.FilterOn.Equals("categoryName", StringComparison.OrdinalIgnoreCase))
                {
                    querry = querry.Where(bc => bc.CategoryName.Contains(budgetParameter.FilterQuery));
                }
            }
            var totalItems = querry.Count();
            var budgets = await querry
                .Skip((budgetParameter.PageNumber - 1) * budgetParameter.PageSize)
                .Take(budgetParameter.PageSize)
                .OrderBy(bc => bc.CategoryName)
                .ToListAsync();
                

               var response= new BudgetsDto ( budgets,budgetParameter.PageSize,budgetParameter.PageNumber,totalItems);

            return response;
        }
        public async Task<BudgetCategory> GetBudgetCategoryByIdAsync(string userId, Guid id, bool trackChanges)
        {
            var budget = await _repositoryManager.BudgetCategoryRepository.GetByIdAsync(userId, id, trackChanges);
            return budget;
        }

        public async Task<CreatedCategoryDto> UpdateBudgetCategoryForUserAsync(string userId, Guid id, CreatedCategoryDto budgetCategory, bool trackChanges)
        {
            var budget = await _repositoryManager.BudgetCategoryRepository.GetByIdAsync(userId, id, trackChanges);
            if (budget == null)
            {
                throw new NotFoundException($"Budget category with id {id} not found for user {userId}");
            }
            budget.AllocatedAmount = budgetCategory.allocatedAmount;
            budget.CategoryName = budgetCategory.categoryName;
            budget.RemainingAmount = budgetCategory.remainingAmount;
            budget.LastUpdated = budgetCategory.lastUpdated;
            _repositoryManager.BudgetCategoryRepository.UpdateBudgetCategory(userId, budget);
            _repositoryManager.Save();
            return budgetCategory;
        }
    }
}
