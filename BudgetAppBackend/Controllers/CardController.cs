using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudgetApp.Application.Service.Contracts;
using BudgetApp.Domain.Dtos.CardDto;
using BudgetApp.Domain.Models;
using Domain.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BudgetAppBackend.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/Users/[controller]")]
    public class CardController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        public CardController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }
        [HttpGet]
        public async Task<IActionResult> GetCardsForUser()
        {
            var userId = User.FindFirst("Id")?.Value;
            var cards = await _serviceManager.cardService.GetCardAsync(userId, trackChanges: false);
            return Ok(cards);
        }
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetCardById( Guid id)
        {
            var userId = User.FindFirst("Id")?.Value;
            var card = await _serviceManager.cardService.GetCardByIdAsync(userId, id, trackChanges: false);
            return Ok(card);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCard( [FromBody] CreatedCardDto newCard)
        {
            var userId = User.FindFirst("Id")?.Value;
            if (newCard == null)
            {
                throw new BadRequestException("Card data is missing.");
            }
            if (!ModelState.IsValid)
            {
                throw new BadRequestException("card model is not valid");
            }
            var card = await _serviceManager.cardService.CreateCardForUserAsync(userId, newCard, trackChanges: false);
            return CreatedAtAction(nameof(GetCardById), new { userId, id = card.Id}, card);
        }
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteCard(Guid id)
        {
            var userId = User.FindFirst("Id")?.Value;
            var card = await _serviceManager.cardService.DeleteCardForUserAsync(userId, id);
            return NoContent();

        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateCard( Guid id, CreatedCardDto updatedCard)
        {
            var userId = User.FindFirst("Id")?.Value;
            if (updatedCard == null)
            {
                throw new BadRequestException("Card data is missing.");
            }
            if (!ModelState.IsValid)
            {
                throw new BadRequestException("card model is not valid");
            }
            var card = await _serviceManager.cardService.UpdateCardForUserAsync(userId, id, updatedCard, trackChanges: true);
            return NoContent();
        }
    }
}