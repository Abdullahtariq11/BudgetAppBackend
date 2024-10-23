using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudgetApp.Application.Service.Contracts;
using BudgetApp.Domain.Dtos.BudgetCategoryDto;
using BudgetApp.Domain.Models;

using Domain.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BudgetAppBackend.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/Users/BudgetCategories")]
    public class BudgetCategoryController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        public BudgetCategoryController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategoriesForUser()
        {
            var userId = User.FindFirst("Id")?.Value;
            var budgets = await _serviceManager.budgetCategoryService.GetBudgetCategoriesAsync(userId, trackChanges: false);
            return Ok(budgets);
        }
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetCategoryById(Guid id)
        {
            var userId = User.FindFirst("Id")?.Value;
            var budget = await _serviceManager.budgetCategoryService.GetBudgetCategoryByIdAsync(userId, id, trackChanges: false);
            return Ok(budget);
        }
        [HttpPost]
        public async Task<IActionResult> CreateBudgetCategory( [FromBody] CreatedCategoryDto budgetCategorydto)
        {
            var userId = User.FindFirst("Id")?.Value;
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
        public async Task<IActionResult> DeleteBudgetCategory( Guid id)
        {
            var userId = User.FindFirst("Id")?.Value;
            var budget = await _serviceManager.budgetCategoryService.DeleteBudgetCategoryForUserAsync(userId, id);

            return NoContent();

        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateCategory( Guid id, CreatedCategoryDto budgetCategory)
        {
            var userId = User.FindFirst("Id")?.Value;
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