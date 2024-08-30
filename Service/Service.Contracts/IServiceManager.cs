using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetApp.Application.Service.Contracts
{
    public interface IServiceManager
    {
        public ITransactionService transactionService { get; }
        public IBudgetService budgetService { get;  }
        public IBudgetCategoryService budgetCategoryService { get; }
    }
}
