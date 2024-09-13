using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BudgetApp.Domain.Models;
using BudgetApp.Shared.Dtos.CardDto;

namespace BudgetApp.Application.Service.Contracts
{
    public interface ICardService
    {
         public Task<ICollection<Card>> GetCardAsync(string userId,bool trackChanges);
        public  Task<Card> GetCardByIdAsync(string userId,Guid id, bool trackChanges);
        public  Task<Card> CreateCardForUserAsync(string userId, CreatedCardDto card,bool trackChanges);
        public  Task<Card> DeleteCardForUserAsync(string userId,Guid id);
        public Task<CreatedCardDto> UpdateCardForUserAsync(string userId,Guid id, CreatedCardDto card, bool trackChanges);
    }
}

