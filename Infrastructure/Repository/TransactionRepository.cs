using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BudgetApp.Domain.Contracts;
using BudgetApp.Domain.Models;
using BudgetApp.Shared.RequestFeatures;
using Microsoft.EntityFrameworkCore;

namespace BudgetApp.Infrastructure.Repository
{
    public class TransactionRepository : RepositoryBase<Transaction>, ITransactionRepository
    {
        public TransactionRepository(RepositoryContext context) : base(context)
        {
        }
        public async Task<ICollection<Transaction>> GetAllAsync(TransactionParameter parameter, bool trackChanges)
        {
            IQueryable<Transaction> query = FindAll(trackChanges);

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

            return await query
                .Skip((parameter.PageNumber - 1) * parameter.PageSize)
                .Take(parameter.PageSize)
                .OrderBy(t => t.Category)
                .ToListAsync();
        }
        public async Task<Transaction> GetByIdAsync(Guid transactionId, bool trackChanges)
        {
            return await FindByCondition(t => t.Id.Equals(transactionId), trackChanges).SingleOrDefaultAsync();
        }

        public void CreateTransaction(Transaction transaction)
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
