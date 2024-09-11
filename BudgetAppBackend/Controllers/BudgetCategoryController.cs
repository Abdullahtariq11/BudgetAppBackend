using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudgetApp.Application.Service.Contracts;
using BudgetApp.Domain.Models;
using BudgetApp.Shared.Dtos.BudgetCategoryDto;
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
            if (budgets == null)
            {
                return NotFound();
            }
            return Ok(budgets);
        }
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetCategoryById(string userId, Guid id)
        {
            var budget = await _serviceManager.budgetCategoryService.GetBudgetCategoryByIdAsync(userId, id, trackChanges: false);
            if (budget == null)
            {
                return NotFound();
            }
            return Ok(budget);
        }
        [HttpPost]
        public async Task<IActionResult> CreateBudgetCategory(string userId, [FromBody] CreatedCategoryDto budgetCategorydto)
        {
            var budget = await _serviceManager.budgetCategoryService.CreateBudgetCategoryForUserAsync(userId, budgetCategorydto, trackChanges: false);
            if (budget == null)
            {
                return NoContent();
            }
            return Ok(budgetCategorydto);
        }
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteBudgetCategory(string userId, Guid id)
        {
            var budget = await _serviceManager.budgetCategoryService.DeleteBudgetCategoryForUserAsync(userId, id);
            if (budget == null)
            {
                return BadRequest("Not deleted");
            }
            return Ok(budget);

        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateCategory(string userId, Guid id, CreatedCategoryDto budgetCategory)
        {
            var budget = await _serviceManager.budgetCategoryService.UpdateBudgetCategoryForUserAsync(userId, id,budgetCategory,trackChanges:true);
            if (budget == null)
            {
                return BadRequest("Not updated");
            }
            return Ok(budget);
        }


    }
}