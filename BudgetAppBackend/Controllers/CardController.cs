using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudgetApp.Application.Service.Contracts;
using BudgetApp.Domain.Models;
using BudgetApp.Shared.Dtos.CardDto;
using Microsoft.AspNetCore.Mvc;

namespace BudgetAppBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CardController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        public CardController(IServiceManager serviceManager)
        {
            _serviceManager=serviceManager;
        }
        [HttpGet]
        public async Task<IActionResult> GetCardsForUser(string userId)
        {
            var cards = await _serviceManager.cardService.GetCardAsync(userId, trackChanges: false);
            if (cards == null)
            {
                return NotFound();
            }
            return Ok(cards);
        }
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetCardById(string userId, Guid id)
        {
            var card = await _serviceManager.cardService.GetCardByIdAsync(userId, id, trackChanges: false);
            if (card == null)
            {
                return NotFound();
            }
            return Ok(card);
        }
        [HttpPost]
        public async Task<IActionResult> CreateBudgetCategory(string userId, [FromBody] CreatedCardDto newCard)
        {
            var card = await _serviceManager.cardService.CreateCardForUserAsync(userId, newCard, trackChanges: false);
            if (card == null)
            {
                return NoContent();
            }
            return Ok(newCard);
        }
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteBudgetCategory(string userId, Guid id)
        {
            var card = await _serviceManager.cardService.DeleteCardForUserAsync(userId, id);
            if (card == null)
            {
                return BadRequest("Not deleted");
            }
            return Ok(card);

        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateCategory(string userId, Guid id, CreatedCardDto updatedCard)
        {
            var card = await _serviceManager.cardService.UpdateCardForUserAsync(userId, id, updatedCard, trackChanges: true);
            if (card == null)
            {
                return BadRequest("Not updated");
            }
            return Ok(card);
        }
    }
}