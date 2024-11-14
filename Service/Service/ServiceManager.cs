using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BudgetApp.Application.Service.Contracts;
using BudgetApp.Domain.Contracts;
using BudgetApp.Domain.Models;
using EmailService;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Service.Service;
using Service.Service.Contracts;

namespace BudgetApp.Application.Service
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<CardService> _cardService;
        private readonly Lazy<BudgetCategoryService> _budgetCategoryService;
        private readonly Lazy<TransactionService> _transactionService;
        private readonly Lazy<UserService> _userService;
       
      
     
        
        public ServiceManager(IConfiguration _configuration, IRepositoryManager repositoryManager,UserManager<User> userManager,SignInManager<User> signInManager, ILoggerFactory loggerFactory,IEmailSender emailSender)
        {
            _cardService=new Lazy<CardService>(()=> new CardService(repositoryManager, loggerFactory.CreateLogger<CardService>()));
            _budgetCategoryService = new Lazy<BudgetCategoryService>(() => new BudgetCategoryService(repositoryManager, loggerFactory.CreateLogger<BudgetCategoryService>()));
            _transactionService = new Lazy<TransactionService>(() => new TransactionService(repositoryManager, loggerFactory.CreateLogger<TransactionService>()));
            _userService=new Lazy<UserService>(()=> new UserService(userManager,signInManager, loggerFactory.CreateLogger<UserService>(),_configuration,emailSender));
        }
        public ITransactionService transactionService => _transactionService.Value;

        public ICardService cardService => _cardService.Value;

        public IBudgetCategoryService budgetCategoryService => _budgetCategoryService.Value;
        public IUserService userService=> _userService.Value;
    }
}
