using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BudgetApp.Domain.Models;

namespace BudgetApp.Application.Service.Contracts
{
    public interface ICardService
    {
         public Task<ICollection<Card>> GetBudgetCategoriesAsync(string userId,bool trackChanges);
        public  Task<Card> GetBudgetCategoryByIdAsync(string userId,Guid id, bool trackChanges);
        public  Task<Card> CreateBudgetCategoryForUserAsync(string userId, Card card,bool trackChanges);
        public  Task<Card> DeleteBudgetCategoryForUserAsync(string userId,Guid id);
        public Task<Card> UpdateBudgetCategoryForUserAsync(string userId,Guid id, Card card, bool trackChanges);
    }
}

