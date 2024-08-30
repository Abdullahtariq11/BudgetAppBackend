using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetApp.Domain.Contracts
{
    public interface IRepositoryManager
    {
        ITransactionRepository TransactionRepository { get; }
        IBudgetCategoryRepository BudgetCategoryRepository { get; }
        IBudgetRepository BudgetRepository { get; }
        void Save();
    }
}
