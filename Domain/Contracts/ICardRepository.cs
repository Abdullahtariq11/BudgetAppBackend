using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BudgetApp.Domain.Models;

namespace BudgetApp.Domain.Contracts
{
    public interface ICardRepository
    {
        public Task<ICollection<Card>> GetAllAsync(string userId,bool trackChanges);
        public Task<Card> GetByIdAsync(string userId,Guid cardId,bool trackChanges);

        public void CreateCard(string userId,Card card);
        public void UpdateCard(string userId,Card card);
        public Task DeleteCard(Card card);
    }
}
