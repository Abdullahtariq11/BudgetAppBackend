using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BudgetApp.Domain.Models;
using BudgetApp.Shared.Dtos.TransactionDto;
using BudgetApp.Shared.RequestFeatures;

namespace BudgetApp.Application.Service.Contracts
{
    public interface ITransactionService
    {
        public Task<ICollection<Transaction>> GetAllTransaction(TransactionParameter parameter,bool trackChanges);
        public Task<Transaction> GetTransactionById(Guid TransactionId, bool trackChanges);
        public Transaction CreateTransaction(TransactionDto transaction);
        public Task<Transaction> UpdateTransaction(Guid transactionId,Transaction transaction,bool trackChanges);
        public Task<Transaction> DeleteTransaction(Guid transactionId, bool trackChanges);
    }
}

