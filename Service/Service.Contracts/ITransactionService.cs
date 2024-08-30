using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BudgetApp.Domain.Models;

namespace BudgetApp.Application.Service.Contracts
{
    public interface ITransactionService
    {
        public Task<ICollection<Transaction>> GetAllTransaction(bool trackChanges);
        public Task<Transaction> GetTransactionById(Guid TransactionId, bool trackChanges);
        public Transaction CreateTransaction(Transaction transaction);
        public Task<Transaction> UpdateTransaction(Guid transactionId,Transaction transaction,bool trackChanges);
        public Task<Transaction> DeleteTransaction(Guid transactionId, bool trackChanges);
    }
}
