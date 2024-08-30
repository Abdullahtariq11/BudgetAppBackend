using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BudgetApp.Application.Service.Contracts;
using BudgetApp.Domain.Contracts;

namespace BudgetApp.Application.Service
{
    public class BudgetService:IBudgetService
    {
        private readonly IRepositoryManager _repositoryManager;
        public BudgetService(IRepositoryManager repositoryManager)
        {
            _repositoryManager=repositoryManager;
        }

    }
}
