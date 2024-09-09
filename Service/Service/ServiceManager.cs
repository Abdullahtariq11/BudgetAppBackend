using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BudgetApp.Application.Service.Contracts;
using BudgetApp.Domain.Contracts;
using BudgetApp.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Service.Service;
using Service.Service.Contracts;

namespace BudgetApp.Application.Service
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<BudgetService> _budgetService;
        private readonly Lazy<BudgetCategoryService> _budgetCategoryService;
        private readonly Lazy<TransactionService> _transactionService;
        private readonly Lazy<UserService> _userService;
        public ServiceManager(IRepositoryManager repositoryManager,UserManager<User> userManager,SignInManager<User> signInManager)
        {
            _budgetService=new Lazy<BudgetService>(()=> new BudgetService(repositoryManager));
            _budgetCategoryService = new Lazy<BudgetCategoryService>(() => new BudgetCategoryService(repositoryManager));
            _transactionService = new Lazy<TransactionService>(() => new TransactionService(repositoryManager));
            _userService=new Lazy<UserService>(()=> new UserService(userManager,signInManager));
        }
        public ITransactionService transactionService => _transactionService.Value;

        public IBudgetService budgetService => _budgetService.Value;

        public IBudgetCategoryService budgetCategoryService => _budgetCategoryService.Value;
        public IUserService userService=> _userService.Value;
    }
}
