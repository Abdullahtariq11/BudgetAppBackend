using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BudgetApp.Domain.Models;

namespace BudgetApp.Domain.Contracts
{
    public interface ITransactionRepository
    {
        public Task<ICollection<Transaction>> GetAllAsync(bool trackChanges);
        public Task<Transaction> GetByIdAsync(Guid TransactionId,bool trackChanges);

        public void CreateTransaction(Transaction transaction);
        public void UpdateTransaction(Transaction transaction);
        public void DeleteTransaction(Transaction transaction);

    }
}
