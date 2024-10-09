using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BudgetApp.Domain.Models;
using BudgetApp.Shared.RequestFeatures;

namespace BudgetApp.Domain.Contracts
{
    public interface ITransactionRepository
    {
        public Task<ICollection<Transaction>> GetAllAsync(string userId,TransactionParameter parameter,bool trackChanges);
        public Task<Transaction> GetByIdAsync(string userId,Guid TransactionId,bool trackChanges);

        public void CreateTransaction(Transaction transaction);
        public void UpdateTransaction(Transaction transaction);
        public void DeleteTransaction(Transaction transaction);

    }
}
