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
        public Task<ICollection<Transaction>> GetAllTransaction(string userId,TransactionParameter parameter,bool trackChanges);
        public Task<Transaction> GetTransactionById(string userId,Guid TransactionId, bool trackChanges);
        public Task<Transaction> CreateTransaction(string userId,TransactionDto transaction);
        public Task<Transaction> UpdateTransaction(string userId,Guid transactionId,Transaction transaction,bool trackChanges);
        public Task<Transaction> DeleteTransaction(string userId,Guid transactionId, bool trackChanges);
    }
}

