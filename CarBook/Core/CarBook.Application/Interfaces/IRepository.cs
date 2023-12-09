using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query;

namespace CarBook.Application.Interfaces;

public interface IRepository<T> where T : class
{
    Task<List<T>> GetAllAsync();
    Task<T> GetByIdAsync(Guid id);
    Task CreateAsync(T entity);
    Task UpdateAsync(T entity);
    Task RemoveAsync(T entity);
    List<T> GetListWithPredicateAndIncludes(
       Expression<Func<T, bool>>? predicate = null,
       Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
       bool enableTracking = true
   );
}
