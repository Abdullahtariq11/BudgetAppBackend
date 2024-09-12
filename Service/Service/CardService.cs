using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BudgetApp.Application.Service.Contracts;
using BudgetApp.Domain.Contracts;
using BudgetApp.Domain.Models;

namespace BudgetApp.Application.Service
{
    public class CardService:ICardService
    {
        private readonly IRepositoryManager _repositoryManager;
        public CardService(IRepositoryManager repositoryManager)
        {
            _repositoryManager=repositoryManager;
        }

        public Task<Card> CreateBudgetCategoryForUserAsync(string userId, Card card, bool trackChanges)
        {
            throw new NotImplementedException();
        }

        public Task<Card> DeleteBudgetCategoryForUserAsync(string userId, Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Card>> GetBudgetCategoriesAsync(string userId, bool trackChanges)
        {
            throw new NotImplementedException();
        }

        public Task<Card> GetBudgetCategoryByIdAsync(string userId, Guid id, bool trackChanges)
        {
            throw new NotImplementedException();
        }

        public Task<Card> UpdateBudgetCategoryForUserAsync(string userId, Guid id, Card card, bool trackChanges)
        {
            throw new NotImplementedException();
        }
    }
}
