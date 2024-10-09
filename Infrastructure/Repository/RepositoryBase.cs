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

        private readonly RepositoryContext _context;


        public RepositoryBase(RepositoryContext context)
        {
            _context = context;
        }


        public async Task Create(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public  Task Delete(T entity)
        {
             _context.Set<T>().Remove(entity);
             return Task.CompletedTask;

        }

        public IQueryable<T> FindAll(bool trackChanges)
        {
            return !trackChanges ? _context.Set<T>().AsNoTracking() : _context.Set<T>();

        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges)
        {
            return !trackChanges ? _context.Set<T>().Where(expression).AsNoTracking() : _context.Set<T>().Where(expression);
        }

        //Since it doesnt need to return anything we can return task completed to make code readibility and consitency better 
        //although code act synchronously
        public  Task Update(T entity)
        {
             _context.Set<T>().Update(entity);
             return Task.CompletedTask;
            
        }
    }
}
