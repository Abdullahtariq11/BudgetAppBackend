using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BudgetApp.Domain.Contracts;
using Infrastructure.Repository;

namespace BudgetApp.Infrastructure.Repository
{
    /// <summary>
    /// Manages all the repositories and responsible for final change in database
    /// </summary>
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext repositoryContext;
        private readonly Lazy<TransactionRepository> transactionRepository;
        private readonly Lazy<CardRepository> cardRepository;
        private readonly Lazy<BudgetCategoryRepository> categoryRepository;
        public RepositoryManager(RepositoryContext context )
        {
            repositoryContext= context;
            ///using lazy intialization to improver performance as repository only created when needed
            transactionRepository= new Lazy<TransactionRepository>(()=>new TransactionRepository(context));
            cardRepository= new Lazy<CardRepository>(()=>new CardRepository(context));
            categoryRepository = new Lazy<BudgetCategoryRepository>(()=>new BudgetCategoryRepository(context));
        }

        public ITransactionRepository TransactionRepository => transactionRepository.Value;

        public IBudgetCategoryRepository BudgetCategoryRepository => categoryRepository.Value;

        public ICardRepository CardRepository => cardRepository.Value;

        public  void Save()
        {
            repositoryContext.SaveChanges();
        }
    }
}
