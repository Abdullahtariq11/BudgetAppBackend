using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using BudgetApp.Application.Service.Contracts;
using BudgetApp.Domain.Contracts;
using BudgetApp.Domain.Dtos.TransactionDto;
using BudgetApp.Domain.Models;
using BudgetApp.Shared.RequestFeatures;
using Domain.Exceptions;
using Microsoft.EntityFrameworkCore;
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

        public async Task updateBalance(decimal transactionAmount, Guid cardId, TransactionType transactionType, Guid? budgetCategoryId, string userId)
        {
            var card = await _repositoryManager.CardRepository.GetByIdAsync(userId, cardId, trackChanges: true);
            if (card == null)
            {
                throw new NotFoundException($"card with id {cardId} not found for user {userId}");
            }
            BudgetCategory budgetCategory = null;
            if (budgetCategoryId.HasValue && budgetCategoryId != Guid.Empty)
            {
                budgetCategory = await _repositoryManager.BudgetCategoryRepository.GetByIdAsync(userId, budgetCategoryId.Value, trackChanges: true);
                if (budgetCategory == null)
                {
                    _logger.LogWarning("Budget category with id {BudgetCategoryId} not found for user {UserId}", budgetCategoryId, userId);

                }
            }

            // Update card and budget category balances
            var adjustment = transactionType == TransactionType.Income ? transactionAmount : -transactionAmount;
            if (card.cardType.ToString() == "Debit")
            {
                card.Balance += adjustment;
            }
            else if (card.cardType.ToString() == "Credit")
            {
                card.AvailableBalance += adjustment;

            }
            if (budgetCategory != null)
            {
                budgetCategory.RemainingAmount += adjustment;
            }

            // Save the changes
            _repositoryManager.CardRepository.UpdateCard(userId, card);
            if (budgetCategory != null)
            {
                _repositoryManager.BudgetCategoryRepository.UpdateBudgetCategory(userId, budgetCategory);
            }

            _repositoryManager.Save();

        }

        public async Task<TransactionsDto> GetAllTransaction(string userId, TransactionParameter parameter, bool trackChanges)
        {
            _logger.LogInformation("Getting Transactions for user {userId}", userId);

            var query = await _repositoryManager.TransactionRepository.GetAllAsync(userId, parameter, trackChanges);

            var totalItems = query.Count();

            if (parameter.HasValidFilter())
            {
                if (parameter.FilterOn.Equals("Category", StringComparison.OrdinalIgnoreCase))
                {
                    query = query.Where(t => t.Category.Contains(parameter.FilterQuery));
                }
                if (parameter.FilterOn.Equals("Type", StringComparison.OrdinalIgnoreCase))
                {
                    if (Enum.TryParse(parameter.FilterQuery, true, out TransactionType transactionType))
                    {
                        query = query.Where(t => t.Type == transactionType);
                    }
                }
            }

            var transactions = await query
                .Skip((parameter.PageNumber - 1) * parameter.PageSize)
                .Take(parameter.PageSize)
                .OrderBy(t => t.Category)
                .ToListAsync();
            if (transactions == null)
            {
                throw new NotFoundException($"Transactions not found for user {userId}");
            }

            var response = new TransactionsDto(transactions, parameter.PageSize, parameter.PageNumber, totalItems);
            return response;


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
                UserID = userId,
                CardId = transactionDto.cardId,
                BudgetCategoryId = transactionDto.BudgetCategoryId,
            };
            await updateBalance(transactionDto.amount, transactionDto.cardId, transactionType, transactionDto.BudgetCategoryId, userId);
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

            // Check if there's a change in amount, type, or budget category
            bool isAmountChanged = transactionRetrieved.Amount != transaction.Amount;
            bool isTypeChanged = transactionRetrieved.Type != transaction.Type;
            bool isCategoryChanged = transactionRetrieved.BudgetCategoryId != transaction.BudgetCategoryId;

            // If there are any changes, reverse the original transaction's impact first
            if (isAmountChanged || isTypeChanged || isCategoryChanged)
            {
                // Reverse the original transaction's effect
                await updateBalance(-transactionRetrieved.Amount, transactionRetrieved.CardId, transactionRetrieved.Type, transactionRetrieved.BudgetCategoryId, userId);

                // Apply the new transaction's effect
                await updateBalance(transaction.Amount, transaction.CardId, transaction.Type, transaction.BudgetCategoryId, userId);
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

            await updateBalance(-transaction.Amount, transaction.CardId, transaction.Type, transaction.BudgetCategoryId, userId);
            await _repositoryManager.TransactionRepository.DeleteTransaction(transaction);
            _repositoryManager.Save();
            return transaction;
        }
    }
}
