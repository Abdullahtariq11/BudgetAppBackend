using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BudgetApp.Domain.Contracts;
using BudgetApp.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BudgetApp.Infrastructure.Repository
{
    public class TransactionRepository : RepositoryBase<Transaction>, ITransactionRepository
    {
        public TransactionRepository(RepositoryContext context) : base(context)
        {
        }
        public async Task<ICollection<Transaction>> GetAllAsync(bool trackChanges)
        {
            return await FindAll(trackChanges).ToListAsync();
        }
        public async Task<Transaction> GetByIdAsync(Guid transactionId,bool trackChanges)
        {
            return await FindByCondition(t => t.Id.Equals(transactionId), trackChanges).SingleOrDefaultAsync();
        }

        public  void CreateTransaction(Transaction transaction)
        {
              Create(transaction);
            
        }
        public void UpdateTransaction(Transaction transaction) 
        {
            Update(transaction);
        }
        public void DeleteTransaction(Transaction transaction) 
        {
            Delete(transaction);
        }


    }
}
