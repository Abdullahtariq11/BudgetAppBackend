using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using BudgetApp.Application.Service.Contracts;
using BudgetApp.Domain.Contracts;
using BudgetApp.Domain.Models;
using BudgetApp.Shared.Dtos.TransactionDto;
using BudgetApp.Shared.RequestFeatures;
using Domain.Exceptions;
using Microsoft.Extensions.Logging;

namespace BudgetApp.Application.Service
{
    public class TransactionService : ITransactionService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILogger _logger;
        public TransactionService(IRepositoryManager repositoryManager, ILogger<TransactionService> logger)
        {
            _repositoryManager = repositoryManager;
            _logger = logger;
        }

        public async Task<ICollection<Transaction>> GetAllTransaction(string userId, TransactionParameter parameter, bool trackChanges)
        {
            _logger.LogInformation("Getting Transactions for user {userId}",userId);

            var transactions = await _repositoryManager.TransactionRepository.GetAllAsync(userId, parameter, trackChanges);
            if (transactions == null)
            {
                throw new NotFoundException($"Transactions not found for user {userId}");
            }

            return transactions;
        }

        public async Task<Transaction> GetTransactionById(string userId, Guid TransactionId, bool trackChanges)
        {
            var transaction = await _repositoryManager.TransactionRepository.GetByIdAsync(userId, TransactionId, trackChanges);
            if (transaction == null)
            {
                throw new NotFoundException($"Transaction with id {TransactionId} not found for user {userId}");
            }
            return transaction;
        }
        public async Task<Transaction> CreateTransaction(string userId, TransactionDto transactionDto)
        {
            _logger.LogInformation("Updating transaction for user {userId}", userId);

            if (!Enum.TryParse(transactionDto.transactionType, true, out TransactionType transactionType))
            {
                throw new BadRequestException("Invalid transaction type");
            }
            var transaction = new Transaction()
            {
                Amount = transactionDto.amount,
                TransactionDate = transactionDto.transactionDate,
                Description = transactionDto.description,
                Category = transactionDto.category,
                Type = transactionType,
                UserID = userId
            };
            await _repositoryManager.TransactionRepository.CreateTransaction(transaction);
            _repositoryManager.Save();
            return transaction;
        }

        public async Task<Transaction> UpdateTransaction(string userId, Guid transactionId, Transaction transaction, bool trackChanges)
        {
            _logger.LogInformation("Updating transaction for user {userId}", userId);
            var transactionRetrieved = await _repositoryManager.TransactionRepository.GetByIdAsync(userId, transactionId, trackChanges);
            if (transactionRetrieved == null)
            {
                throw new NotFoundException($"Transaction with id {transactionId} not found for user {userId}");
            }

            transaction.Id = transactionRetrieved.Id;
            await _repositoryManager.TransactionRepository.UpdateTransaction(transaction);
            _repositoryManager.Save();
            return transaction;


        }

        public async Task<Transaction> DeleteTransaction(string userId, Guid transactionId, bool trackChanges)
        {
            _logger.LogInformation("Deleting transaction for user {userId}", userId);
            var transaction = await _repositoryManager.TransactionRepository.GetByIdAsync(userId, transactionId, trackChanges);
            if (transaction == null)
            {
                throw new NotFoundException($"Transaction with id {transactionId} not found for user {userId}");
            }

            await _repositoryManager.TransactionRepository.DeleteTransaction(transaction);
            _repositoryManager.Save();
            return transaction;
        }
    }
}
