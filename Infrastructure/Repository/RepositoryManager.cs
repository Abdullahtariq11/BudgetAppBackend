using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BudgetApp.Domain.Contracts;

namespace BudgetApp.Infrastructure.Repository
{
    /// <summary>
    /// Manages all the repositories and responsible for final change in database
    /// </summary>
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext repositoryContext;
        private readonly Lazy<TransactionRepository> transactionRepository;
        private readonly Lazy<BudgetRepository> budgetRepository;
        private readonly Lazy<BudgetCategoryRepository> categoryRepository;
        public RepositoryManager(RepositoryContext context )
        {
            repositoryContext= context;
            ///using lazy intialization to improver performance as repository only created when needed
            transactionRepository= new Lazy<TransactionRepository>(()=>new TransactionRepository(context));
            budgetRepository= new Lazy<BudgetRepository>(()=>new BudgetRepository(context));
            categoryRepository = new Lazy<BudgetCategoryRepository>(()=>new BudgetCategoryRepository(context));
        }

        public ITransactionRepository TransactionRepository => transactionRepository.Value;

        public IBudgetCategoryRepository BudgetCategoryRepository => categoryRepository.Value;

        public IBudgetRepository BudgetRepository => budgetRepository.Value;

        public  void Save()
        {
            repositoryContext.SaveChanges();
        }
    }
}
