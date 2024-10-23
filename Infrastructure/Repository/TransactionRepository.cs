using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BudgetApp.Domain.Contracts;
using BudgetApp.Domain.Models;
using BudgetApp.Shared.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using Serilog;


namespace BudgetApp.Infrastructure.Repository
{
    public class TransactionRepository : RepositoryBase<Transaction>, ITransactionRepository
    {
        public TransactionRepository(RepositoryContext context) : base(context)
        {
        }
        public async Task<IQueryable<Transaction>> GetAllAsync(string userId, TransactionParameter parameter, bool trackChanges)
        {
            var query = FindByCondition(u => u.UserID.Equals(userId), trackChanges);

            return query;


        }
        
        
        public async Task<Transaction> GetByIdAsync(string userId, Guid transactionId, bool trackChanges)
        {

            return await FindByCondition(u => u.UserID == userId && u.Id == transactionId, trackChanges).SingleOrDefaultAsync();

        }

        public async Task CreateTransaction(Transaction transaction)
        {
            await Create(transaction);

        }
        public async Task UpdateTransaction(Transaction transaction)
        {
            await Update(transaction);
        }
        public async Task DeleteTransaction(Transaction transaction)
        {
            await Delete(transaction);
        }


    }
}
