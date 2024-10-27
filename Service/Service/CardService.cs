using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BudgetApp.Application.Service.Contracts;
using BudgetApp.Domain.Contracts;
using BudgetApp.Domain.Dtos.CardDto;
using BudgetApp.Domain.Models;
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

            if (!Enum.TryParse(card.cardType, true, out CardType cardType))
            {
                throw new BadRequestException("Invalid card type");
            }


            SubCardType? subCardType = null;
            //create card subtype only if card is debit
            if (cardType == CardType.Debit)
            {
                if (string.IsNullOrEmpty(card.subCardType) || !Enum.TryParse(card.subCardType, true, out SubCardType parsedSubtype))
                {
                    throw new BadRequestException("For Debit cards, subtype must be 'Savings' or 'Chequing'.");
                }
                subCardType = parsedSubtype;
            }
            var newCard = new Card
            {
                CardName = card.CardName,
                Balance = card.Balance,
                AvailableBalance = card.AvailableBalance,
                TotalCreditLimit = card.TotalCreditLimit,
                cardType = cardType,
                subCardType = subCardType
            };

            _repositoryManager.CardRepository.CreateCard(userId, newCard);
            _repositoryManager.Save();
            return newCard;
        }

        public async Task<Card> DeleteCardForUserAsync(string userId, Guid id)
        {
            _logger.LogInformation("Deleting card for user {userId}", userId);
            var card = await _repositoryManager.CardRepository.GetByIdAsync(userId, id, trackChanges: true);
            if (card == null)
            {
                throw new NotFoundException($"Card with id {id} not found for user {userId}");
            }
            _repositoryManager.CardRepository.DeleteCard(card);
            _repositoryManager.Save();
            return card;
        }

        public async Task<ICollection<CreatedCardDto>> GetCardAsync(string userId, bool trackChanges)
        {
            _logger.LogInformation("Getting All cards for user {userId}", userId);
            var cards = await _repositoryManager.CardRepository.GetAllAsync(userId, trackChanges);
            var cardDtos = new List<CreatedCardDto>();
            foreach (var card in cards)
            {
                var cardDto = new CreatedCardDto
                (card.Id, card.CardName, card.Balance, card.AvailableBalance, card.TotalCreditLimit, card.cardType.ToString(), card.subCardType.ToString());
                cardDtos.Add(cardDto);
            }

            return cardDtos;
        }

        public async Task<Card> GetCardByIdAsync(string userId, Guid id, bool trackChanges)
        {
            _logger.LogInformation("Getting card for user {userId}", userId);
            var card = await _repositoryManager.CardRepository.GetByIdAsync(userId, id, trackChanges);
            return card;
        }

        public async Task<CreatedCardDto> UpdateCardForUserAsync(string userId, Guid id, CreatedCardDto updatedCard, bool trackChanges)
        {
            _logger.LogInformation("Updating card for user {userId}", userId);
            var card = await _repositoryManager.CardRepository.GetByIdAsync(userId, id, trackChanges);
            if (card == null)
            {
                throw new NotFoundException($"Card with id {id} not found for user {userId}");
            }

            SubCardType? subCardType = null;
            //create card subtype only if card is debit
            if (updatedCard.cardType == CardType.Debit.ToString())
            {
                if (updatedCard.subCardType == "0")
                {
                    throw new BadRequestException("For Debit cards, subtype must be 'Savings' or 'Chequing'.");
                }

            }

            Enum.TryParse(updatedCard.cardType, true, out CardType cardType);
            Enum.TryParse(updatedCard.subCardType, true, out SubCardType subType);

            if (cardType == CardType.Debit)
            {
                card.AvailableBalance = null;
                card.TotalCreditLimit = null;
                card.CardName = updatedCard.CardName;
                card.Balance = updatedCard.Balance;
                card.subCardType = subType;
            }
            else if (cardType == CardType.Credit)
            {
                card.AvailableBalance = updatedCard.AvailableBalance;
                card.TotalCreditLimit = updatedCard.TotalCreditLimit;
                card.CardName = updatedCard.CardName;
                card.Balance = null;
                card.subCardType = null;
            }


            _repositoryManager.CardRepository.UpdateCard(userId, card);
            _repositoryManager.Save();
            return new CreatedCardDto(id, updatedCard.CardName,updatedCard.Balance,updatedCard.AvailableBalance,
            updatedCard.TotalCreditLimit,updatedCard.cardType,updatedCard.subCardType);
        }
    }
}
