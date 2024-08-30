using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BudgetApp.Application.Service.Contracts;
using BudgetApp.Domain.Contracts;

namespace BudgetApp.Application.Service
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<BudgetService> _budgetService;
        private readonly Lazy<BudgetCategoryService> _budgetCategoryService;
        private readonly Lazy<TransactionService> _transactionService;
        public ServiceManager(IRepositoryManager repositoryManager)
        {
            _budgetService=new Lazy<BudgetService>(()=> new BudgetService(repositoryManager));
            _budgetCategoryService = new Lazy<BudgetCategoryService>(() => new BudgetCategoryService(repositoryManager));
            _transactionService = new Lazy<TransactionService>(() => new TransactionService(repositoryManager));
        }
        public ITransactionService transactionService => _transactionService.Value;

        public IBudgetService budgetService => _budgetService.Value;

        public IBudgetCategoryService budgetCategoryService => _budgetCategoryService.Value;
    }
}
