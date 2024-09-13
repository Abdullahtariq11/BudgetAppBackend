using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudgetApp.Domain.Contracts;
using BudgetApp.Domain.Models;
using BudgetApp.Infrastructure;
using BudgetApp.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Serilog;


namespace Infrastructure.Repository
{
    public class CardRepository : RepositoryBase<Card>,ICardRepository
    {
        public CardRepository(RepositoryContext context,ILogger logger) : base(context,logger)
        {
        }
        public void CreateCard(string userId, Card card)
        {
            card.UserId = userId;
            Create(card);
            
        }

        public void DeleteCard(Card card)
        {
            Delete(card);
            
        }

        public async Task<ICollection<Card>> GetAllAsync(string userId, bool trackChanges)
        {
             return await FindByCondition(c=>c.UserId .Equals(userId) ,trackChanges).ToListAsync();
        }

        public async Task<Card> GetByIdAsync(string userId, Guid cardId, bool trackChanges)
        {
            return await FindByCondition(c => c.UserId == userId && c.Id == cardId, trackChanges).SingleOrDefaultAsync();
        }

        public void UpdateCard(string userId, Card card)
        {
            card.UserId = userId;
            Update(card);
        
        }
    }
}