using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using BudgetApp.Domain.Contracts;
using BudgetApp.Shared.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace BudgetApp.Infrastructure.Repository
{
    /// <summary>
    /// Repository base, all the repository classes inherit basic functionality from here to interact with the database
    /// </summary>
   
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly ILogger _logger;
        private readonly RepositoryContext _context;
        

        public RepositoryBase(RepositoryContext context, ILogger logger)
        {
            _context = context;
            _logger = logger;
        }


        public async void Create(T entity)
        {
            try
            {
                await _context.Set<T>().AddAsync(entity);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error occurred while creating entity.");
                throw;
            }
            
        }

        public void Delete(T entity)
        {
            try
            {
                 _context.Set<T>().Remove(entity);
            }
            catch (Exception ex)
            {
                 _logger.Error(ex, "Error occurred while Deleting entity.");
                throw;
            }
            
        }

        public IQueryable<T> FindAll(bool trackChanges)
        {
            try
            {
                return !trackChanges ? _context.Set<T>().AsNoTracking() : _context.Set<T>();
            }
            catch (Exception ex)
            {
                 _logger.Error(ex, "Error occurred while getting all entity.");
                throw;
            }
            

        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges)
        {
            try
            {
                 return !trackChanges ? _context.Set<T>().Where(expression).AsNoTracking() : _context.Set<T>().Where(expression);
            }
            catch(Exception ex)
            {
                 _logger.Error(ex, "Error occurred while getting a entity.");
                throw;
            }
            
        }

        public void Update(T entity)
        {
            try
            {
                _context.Set<T>().Update(entity);
            }
            catch (Exception ex)
            {
                 _logger.Error(ex, "Error occurred while updating a entity.");
                throw;
            }
            
        }
    }
}
