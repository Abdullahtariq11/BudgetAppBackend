using System.Security.Claims;
using BudgetApp.Application.Service.Contracts;
using BudgetApp.Domain.Models;
using BudgetApp.Shared.Dtos.TransactionDto;
using BudgetApp.Shared.RequestFeatures;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BudgetApp.API.Controllers
{
    [Route("api/Users/{userId}/transactions")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        public TransactionController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;

        }

        [HttpGet]
        public async Task<IActionResult> GetTransactions([FromQuery] TransactionParameter parameter, string userId)
        {
            var tokenUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (tokenUserId != userId)
            {
                return Forbid();  // Block if the user is trying to access another user's data
            }
            var transactions = await _serviceManager.transactionService.GetAllTransaction(userId, parameter, trackChanges: false);
            return Ok(transactions);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetTransaction(string userId, [FromRoute] Guid id)
        {
            var tokenUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (tokenUserId != userId)
            {
                return Forbid();  // Block if the user is trying to access another user's data
            }
            var transaction = await _serviceManager.transactionService.GetTransactionById(userId, id, trackChanges: false);
            return Ok(transaction);
        }
        [HttpPost]
        public async Task<IActionResult> CreateTransaction(string userId, [FromBody] TransactionDto transaction)
        {
            var tokenUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (tokenUserId != userId)
            {
                return Forbid();  // Block if the user is trying to access another user's data
            }
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var createdtransaction = await _serviceManager.transactionService.CreateTransaction(userId, transaction);
            return CreatedAtAction(nameof(GetTransaction), new { userId, id = createdtransaction.Id }, createdtransaction);
        }
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteTransaction(string userId, Guid id)
        {
            var tokenUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (tokenUserId != userId)
            {
                return Forbid();  // Block if the user is trying to access another user's data
            }
            var transaction = await _serviceManager.transactionService.DeleteTransaction(userId, id, trackChanges: false);
            return NoContent();
        }
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateTransaction(string userId, Guid id, [FromBody] Transaction transaction)
        {
            var tokenUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (tokenUserId != userId)
            {
                return Forbid();  // Block if the user is trying to access another user's data
            }
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var transactionRetrieved = await _serviceManager.transactionService.UpdateTransaction(userId, id, transaction, trackChanges: false);
            return NoContent();
        }
    }
}
