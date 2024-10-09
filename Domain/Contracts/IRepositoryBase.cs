using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BudgetApp.Shared.RequestFeatures;

namespace BudgetApp.Domain.Contracts
{
    public interface IRepositoryBase<T>
    {
        IQueryable<T> FindAll(bool trackChanges);
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges);
        Task Create(T entity);
        Task Update(T entity);
        Task Delete(T entity);
    }
}
