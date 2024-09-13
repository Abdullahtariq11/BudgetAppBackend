using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.Service.Contracts;

namespace BudgetApp.Application.Service.Contracts
{
    public interface IServiceManager
    {
        public ITransactionService transactionService { get; }
        public ICardService cardService { get;  }
        public IBudgetCategoryService budgetCategoryService { get; }
        public IUserService userService { get;  }
    }
}
