﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BudgetApp.Domain.Dtos.TransactionDto;
using BudgetApp.Domain.Models;
using BudgetApp.Shared.RequestFeatures;
using Domain.Dtos.TransactionDto;

namespace BudgetApp.Application.Service.Contracts
{
    public interface ITransactionService
    {
        public Task<TransactionsDto> GetAllTransaction(string userId,TransactionParameter parameter,bool trackChanges);
        public Task<Transaction> GetTransactionById(string userId,Guid TransactionId, bool trackChanges);
        public Task<Transaction> CreateTransaction(string userId,TransactionDto transaction);
        public Task<UpdateTransactionDto> UpdateTransaction(string userId,Guid transactionId,UpdateTransactionDto transactionUpdates,bool trackChanges);
        public Task<Transaction> DeleteTransaction(string userId,Guid transactionId, bool trackChanges);
    }
}

