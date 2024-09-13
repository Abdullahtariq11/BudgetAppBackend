using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BudgetApp.Application.Service.Contracts;
using BudgetApp.Domain.Contracts;
using BudgetApp.Domain.Models;
using BudgetApp.Shared.Dtos.CardDto;

namespace BudgetApp.Application.Service
{
    public class CardService : ICardService
    {
        private readonly IRepositoryManager _repositoryManager;
        public CardService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<Card> CreateCardForUserAsync(string userId, CreatedCardDto card, bool trackChanges)
        {
            var cards = await _repositoryManager.CardRepository.GetAllAsync(userId, trackChanges);
            if (cards == null || cards == null)
            {
                return null;
            }

            Enum.TryParse(card.cardType, true, out CardType cardType);
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
             var card = await _repositoryManager.CardRepository.GetByIdAsync(userId,id, trackChanges:true);
            if (card == null)
            {
                return null;
            }
            _repositoryManager.CardRepository.DeleteCard(card);
            _repositoryManager.Save();
            return card;
        }

        public async Task<ICollection<Card>> GetCardAsync(string userId, bool trackChanges)
        {
            var cards = await _repositoryManager.CardRepository.GetAllAsync(userId, trackChanges);
            return cards;
        }

        public async Task<Card> GetCardByIdAsync(string userId, Guid id, bool trackChanges)
        {
            var card = await _repositoryManager.CardRepository.GetByIdAsync(userId,id, trackChanges);
            return card;
        }

        public async Task<CreatedCardDto> UpdateCardForUserAsync(string userId, Guid id, CreatedCardDto updatedCard, bool trackChanges)
        {
            var card = await _repositoryManager.CardRepository.GetByIdAsync(userId,id, trackChanges);
            if (card == null)
            {
                return null;
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
