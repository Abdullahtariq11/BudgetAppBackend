using BudgetApp.Application.Service.Contracts;
using BudgetApp.Domain.Models;
using BudgetApp.Shared.Dtos.TransactionDto;
using BudgetApp.Shared.RequestFeatures;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BudgetApp.API.Controllers
{
    [Route("api/transactions")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        public TransactionController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
            
        }

        [HttpGet]
        public async Task<IActionResult> GetTransactions([FromQuery] TransactionParameter parameter )
        {
            var transactions= await _serviceManager.transactionService.GetAllTransaction(parameter,trackChanges:false);
            if (transactions == null) return NotFound();
            return Ok(transactions);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetTransaction([FromRoute]Guid id)
        {
            var transaction= await _serviceManager.transactionService.GetTransactionById(id,trackChanges:false);
            if (transaction == null) return NotFound();
            return Ok(transaction);
        }
        [HttpPost]
        public  IActionResult CreateTransaction([FromBody] TransactionDto transaction)
        {
            if(transaction == null) return NoContent();
            _serviceManager.transactionService.CreateTransaction(transaction);
            return CreatedAtAction(nameof(CreateTransaction), transaction);
        }
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteTransaction(Guid id)
        {
            var transaction=await _serviceManager.transactionService.DeleteTransaction(id, trackChanges:false);
            if (transaction == null) return NotFound();
            return NoContent();
        }
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateTransaction(Guid id, [FromBody] Transaction transaction)
        {
            var transactionRetrieved=await _serviceManager.transactionService.UpdateTransaction(id,transaction,trackChanges:false);
            if(transactionRetrieved == null) return BadRequest();
            return NoContent();
        }
    }
}
