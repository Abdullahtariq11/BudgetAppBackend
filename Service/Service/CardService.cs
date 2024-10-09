using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BudgetApp.Application.Service.Contracts;
using BudgetApp.Domain.Contracts;
using BudgetApp.Domain.Models;
using BudgetApp.Shared.Dtos.CardDto;
using Domain.Exceptions;
using Microsoft.Extensions.Logging;

namespace BudgetApp.Application.Service
{
    public class CardService : ICardService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILogger _logger;
        public CardService(IRepositoryManager repositoryManager, ILogger<CardService> logger)
        {
            _repositoryManager = repositoryManager;
            _logger = logger;
        }

        public async Task<Card> CreateCardForUserAsync(string userId, CreatedCardDto card, bool trackChanges)
        {
            _logger.LogInformation("Creating card for user {userId}", userId);
            var cards = await _repositoryManager.CardRepository.GetAllAsync(userId, trackChanges);
            if (cards == null)
            {
                throw new NotFoundException($"User with {userId} is not found");
            }
            if (card == null)
            {
                throw new BadRequestException("Data provided is not correct");
            }

            if(!Enum.TryParse(card.cardType, true, out CardType cardType))
            {
                 throw new BadRequestException("Invalid card type");
            }
            var newCard = new Card
            {
               CardName=card.CardName,
               Balance=card.Balance,
               AvailableBalance=card.AvailableBalance,
               TotalCreditLimit=card.TotalCreditLimit,
               cardType=cardType,
            };

            _repositoryManager.CardRepository.CreateCard(userId, newCard);
            _repositoryManager.Save();
            return newCard;
        }

        public async Task<Card> DeleteCardForUserAsync(string userId, Guid id)
        {
            _logger.LogInformation("Deleting card for user {userId}", userId);
             var card = await _repositoryManager.CardRepository.GetByIdAsync(userId,id, trackChanges:true);
            if (card == null)
            {
                throw new NotFoundException($"Card with id {id} not found for user {userId}");
            }
            _repositoryManager.CardRepository.DeleteCard(card);
            _repositoryManager.Save();
            return card;
        }

        public async Task<ICollection<Card>> GetCardAsync(string userId, bool trackChanges)
        {
            _logger.LogInformation("Getting All cards for user {userId}", userId);
            var cards = await _repositoryManager.CardRepository.GetAllAsync(userId, trackChanges);
            return cards;
        }

        public async Task<Card> GetCardByIdAsync(string userId, Guid id, bool trackChanges)
        {
            _logger.LogInformation("Getting card for user {userId}", userId);
            var card = await _repositoryManager.CardRepository.GetByIdAsync(userId,id, trackChanges);
            return card;
        }

        public async Task<CreatedCardDto> UpdateCardForUserAsync(string userId, Guid id, CreatedCardDto updatedCard, bool trackChanges)
        {
            _logger.LogInformation("Updating card for user {userId}", userId);
            var card = await _repositoryManager.CardRepository.GetByIdAsync(userId,id, trackChanges);
            if (card == null)
            {
                throw new NotFoundException($"Card with id {id} not found for user {userId}");
            }
            Enum.TryParse(updatedCard.cardType, true, out CardType cardType);
            card.AvailableBalance = updatedCard.AvailableBalance;
            card.CardName = updatedCard.CardName;
            card.Balance = updatedCard.Balance;
            card.cardType=cardType;

            _repositoryManager.CardRepository.UpdateCard(userId,card);
            _repositoryManager.Save();
            return updatedCard;
        }
    }
}
