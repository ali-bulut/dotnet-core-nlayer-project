using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SampleNLayerProject.Core.Repositories
{
    public interface IRepository<TEntity> where TEntity:class
    {
        // The Task<TEntity> class represents a single operation that returns TEntity value and that usually executes asynchronously.
        // We can apply async with single-threaded or multithreaded programming. So, multithreading is one form of asynchronous programming!
        // Multithreading programming is all about concurrent execution of different functions.
        // Async programming is about non-blocking execution between functions.
        Task<TEntity> GetByIdAsync(int id);
        Task<IEnumerable<TEntity>> GetAllAsync();

        // func and predicate delegates. In that case Func => will get TEntity as parameter and will return bool.
        // A Predicate delegate is typically used to search items in a collection or a set of data.
        // Predicate<T> is basically equivalent to Func<T,bool>. Syntax difference between predicate & func is that here in predicate,
        // you don't specify a return type because it is always a bool.
        // When we want to treat lambda expressions as expression trees and look inside them instead of executing them,
        // we should use Expression<>
        Task<IEnumerable<TEntity>> Where(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
        // If we use Task without <>, that means void in async programming.
        Task AddAsync(TEntity entity);
        Task AddRangeAsync(IEnumerable<TEntity> entities);
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
        TEntity Update(TEntity entity);
    }
}
