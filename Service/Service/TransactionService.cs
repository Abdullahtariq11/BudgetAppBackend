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
    public class TransactionService:ITransactionService
    {
        private readonly IRepositoryManager _repositoryManager;
        public TransactionService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<ICollection<Transaction>> GetAllTransaction(bool trackChanges)
        {
            var transactions= await _repositoryManager.TransactionRepository.GetAllAsync(trackChanges);
            if(transactions==null) return null;
            return transactions;
        }

        public async Task<Transaction> GetTransactionById(Guid TransactionId, bool trackChanges)
        {
            var transaction= await _repositoryManager.TransactionRepository.GetByIdAsync(TransactionId, trackChanges);
            if (transaction == null) return null;
            return transaction;
        }
        public Transaction CreateTransaction(Transaction transaction)
        {
            _repositoryManager.TransactionRepository.CreateTransaction(transaction);
             _repositoryManager.Save();
            return transaction;
        }

       public async Task<Transaction> UpdateTransaction(Guid transactionId,Transaction transaction,bool trackChanges)
       {
            var transactionRetrieved= await _repositoryManager.TransactionRepository.GetByIdAsync(transactionId,trackChanges);
            if(transactionRetrieved == null) return null ;
            transaction.Id = transactionRetrieved.Id;
            _repositoryManager.TransactionRepository.UpdateTransaction(transaction);
            _repositoryManager.Save();
            return transaction;


        }

        public async Task<Transaction> DeleteTransaction(Guid transactionId,bool trackChanges)
        {
            var transaction= await _repositoryManager.TransactionRepository.GetByIdAsync(transactionId, trackChanges);
            if(transaction==null) return null ;
             _repositoryManager.TransactionRepository.DeleteTransaction(transaction);
            _repositoryManager.Save();
            return transaction;
        }
    }
}
