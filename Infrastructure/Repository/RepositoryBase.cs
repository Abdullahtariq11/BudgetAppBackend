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


        public void Create(T entity)
        {
             _context.Set<T>().AddAsync(entity);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);

        }

        public IQueryable<T> FindAll(bool trackChanges)
        {
            return !trackChanges ? _context.Set<T>().AsNoTracking() : _context.Set<T>();

        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges)
        {
            return !trackChanges ? _context.Set<T>().Where(expression).AsNoTracking() : _context.Set<T>().Where(expression);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
    }
}
