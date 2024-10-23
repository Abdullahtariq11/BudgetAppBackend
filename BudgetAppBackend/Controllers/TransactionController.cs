using System.Security.Claims;
using BudgetApp.Application.Service.Contracts;
using BudgetApp.Domain.Models;
using BudgetApp.Shared.Dtos.TransactionDto;
using BudgetApp.Shared.RequestFeatures;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BudgetApp.API.Controllers
{
    [Route("api/Users/transactions")]
    [Authorize]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        public TransactionController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;

        }

        [HttpGet]
        public async Task<IActionResult> GetTransactions([FromQuery] TransactionParameter parameter)
        {
            var userId = User.FindFirst("Id")?.Value;
            var tokenUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (tokenUserId != userId)
            {
                return Forbid();  // Block if the user is trying to access another user's data
            }
            var transactions = await _serviceManager.transactionService.GetAllTransaction(userId, parameter, trackChanges: false);
            var totalItems= transactions.Count;
            var response= new {
                transactions,
                totalItems,
                parameter.PageNumber,
                parameter.PageSize,
            };
            return Ok(response);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetTransaction( [FromRoute] Guid id)
        {
            var userId = User.FindFirst("Id")?.Value;
            var tokenUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (tokenUserId != userId)
            {
                return Forbid();  // Block if the user is trying to access another user's data
            }
            var transaction = await _serviceManager.transactionService.GetTransactionById(userId, id, trackChanges: false);
            return Ok(transaction);
        }
        [HttpPost]
        public async Task<IActionResult> CreateTransaction([FromBody] TransactionDto transaction)
        {
            var userId = User.FindFirst("Id")?.Value;
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
        public async Task<IActionResult> DeleteTransaction(Guid id)
        {
            var userId = User.FindFirst("Id")?.Value;
            var tokenUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (tokenUserId != userId)
            {
                return Forbid();  // Block if the user is trying to access another user's data
            }
            var transaction = await _serviceManager.transactionService.DeleteTransaction(userId, id, trackChanges: false);
            return NoContent();
        }
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateTransaction(Guid id, [FromBody] Transaction transaction)
        {
            var userId = User.FindFirst("Id")?.Value;
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
