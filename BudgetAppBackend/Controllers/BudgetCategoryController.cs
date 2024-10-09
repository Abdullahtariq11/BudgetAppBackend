using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudgetApp.Application.Service.Contracts;
using BudgetApp.Domain.Models;
using BudgetApp.Shared.Dtos.BudgetCategoryDto;
using Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace BudgetAppBackend.Controllers
{
    [ApiController]
    [Route("api/Users/{userId}/BudgetCategories")]
    public class BudgetCategoryController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        public BudgetCategoryController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }
        [HttpGet]
        public async Task<IActionResult> GetCategoriesForUser(string userId)
        {
            var budgets = await _serviceManager.budgetCategoryService.GetBudgetCategoriesAsync(userId, trackChanges: false);
            return Ok(budgets);
        }
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetCategoryById(string userId, Guid id)
        {
            var budget = await _serviceManager.budgetCategoryService.GetBudgetCategoryByIdAsync(userId, id, trackChanges: false);
            return Ok(budget);
        }
        [HttpPost]
        public async Task<IActionResult> CreateBudgetCategory(string userId, [FromBody] CreatedCategoryDto budgetCategorydto)
        {
            if (budgetCategorydto == null)
            {
                throw new BadRequestException("BudgetCategory data is missing.");
            }
            if (!ModelState.IsValid)
            {
                throw new BadRequestException("BudgetCategory model is not valid");
            }
            var budget = await _serviceManager.budgetCategoryService.CreateBudgetCategoryForUserAsync(userId, budgetCategorydto, trackChanges: false);
            return CreatedAtAction(nameof(GetCategoryById), new { userId, id = budget.id }, budget);
        }
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteBudgetCategory(string userId, Guid id)
        {
            var budget = await _serviceManager.budgetCategoryService.DeleteBudgetCategoryForUserAsync(userId, id);

            return NoContent();

        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateCategory(string userId, Guid id, CreatedCategoryDto budgetCategory)
        {
            if (budgetCategory == null)
            {
                throw new BadRequestException("Budget category data is missing.");
            }
            if (!ModelState.IsValid)
            {
                throw new BadRequestException("BudgetCategory model is not valid");
            }
            var budget = await _serviceManager.budgetCategoryService.UpdateBudgetCategoryForUserAsync(userId, id, budgetCategory, trackChanges: true);

            return NoContent();
        }


    }
}