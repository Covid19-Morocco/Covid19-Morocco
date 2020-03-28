using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Covid19.Morocco.Data;

namespace Covid19.Morocco.Infrastructure
{
    public class RepositoryBase<T> where T : class
    {
        #region Properties
        private CoronaContext _dbContext;
        private readonly IDbSet<T> _dbSet;

        protected IDbFactory DbFactory { get; }

        protected CoronaContext DbContext => _dbContext ?? (_dbContext = DbFactory.Init());
        #endregion

        protected RepositoryBase(IDbFactory dbFactory)
        {
            DbFactory = dbFactory;
            _dbSet = DbContext.Set<T>();
        }

        #region Implementation
        public virtual void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public virtual void Update(T entity)
        {
            _dbSet.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public virtual void Delete(Expression<Func<T, bool>> where)
        {
            IEnumerable<T> objects = _dbSet.Where<T>(where).AsEnumerable();
            foreach (T obj in objects)
                _dbSet.Remove(obj);
        }

        public virtual T Get(Guid id) => _dbSet.Find(id);

        public virtual IEnumerable GetAll(params Expression<Func<T, object>>[] includeExpressions) => includeExpressions.Aggregate<Expression<Func<T, object>>, IQueryable<T>>
            (_dbSet, (current, expression) => current.Include(expression)).ToList();

        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> where) => _dbSet.Where(where).ToList();

        public T Get(Expression<Func<T, bool>> where) => _dbSet.Where(where).FirstOrDefault();
        #endregion
    }
}