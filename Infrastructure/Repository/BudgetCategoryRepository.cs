﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BudgetApp.Domain.Contracts;
using BudgetApp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Serilog;



namespace BudgetApp.Infrastructure.Repository
{
    public class BudgetCategoryRepository : RepositoryBase<BudgetCategory>, IBudgetCategoryRepository
    {

        public BudgetCategoryRepository(RepositoryContext context) : base(context)
        {
        }

        public void CreateBudgetCategory(string userId, BudgetCategory category)
        {
            category.UserID = userId;
            Create(category);
            
        }

        public void DeleteBudgetCategory(BudgetCategory budgetCategory)
        {
            Delete(budgetCategory);
            
        }

        public async Task<IQueryable<BudgetCategory>> GetAllAsync(string userId, bool trackChanges)
        {

            var querry=  FindByCondition(u=>u.UserID .Equals(userId) ,trackChanges);
            return querry;
        }

        public async Task<BudgetCategory> GetByIdAsync(string userId, Guid categoryId, bool trackChanges)
        {
            return await FindByCondition(u => u.UserID == userId && u.Id == categoryId, trackChanges).SingleOrDefaultAsync();
        }

        public void UpdateBudgetCategory(string userId, BudgetCategory category)
        {
            category.UserID = userId;
            Update(category);
            
        }
    }
}
