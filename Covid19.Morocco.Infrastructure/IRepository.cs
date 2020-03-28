using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Covid19.Morocco.Infrastructure
{
    public interface IRepository<T> where T : class
    {
        // Marks an entity as new 
        void Add(T entity);
        // Marks an entity as modified
        void Update(T entity);
        // Marks an entity to be removed
        void Delete(T entity);
        void Delete(Expression<Func<T, bool>> where);
        // Get an entity by int id
        T Get(Guid id);
        // Get an entity using delegate 
        T Get(Expression<Func<T, bool>> where);
        // Get all entities of type T
        IEnumerable GetAll(params Expression<Func<T, object>>[] includeExpressions);
        // Get entities using delegate
        IEnumerable<T> GetMany(Expression<Func<T, bool>> where);
    }
}