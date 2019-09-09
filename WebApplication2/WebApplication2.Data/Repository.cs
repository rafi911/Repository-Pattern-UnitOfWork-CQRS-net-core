using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace WebApplication2.Data
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbSet<T> objectSet;
        private readonly DatabaseContext context;
        public Repository(DatabaseContext context)
        {
            objectSet = context.Set<T>();
            this.context = context;
        }
        public void Add(T entity)
        {
            objectSet.Add(entity);
        }

        public void AddRange(ICollection<T> entities)
        {
            objectSet.AddRange(entities);
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            if (includeProperties == null || !includeProperties.Any())
            {
                return objectSet.Where(predicate);
            }

            IQueryable<T> queryable = includeProperties.Aggregate(objectSet.AsQueryable(), (current, includeProperty) => current.Include(includeProperty));

            return queryable.Where(predicate);
        }

        public T FindById(params object[] keyValues)
        {
            return objectSet.Find(keyValues);
        }

        public IQueryable<T> GetAllAsQueryable(Func<IQueryable<T>, IIncludableQueryable<T, object>> include)
        {
            IQueryable<T> queryable = objectSet.AsQueryable<T>();
            return include(queryable).AsNoTracking();
        }

        public IQueryable<T> GetAllAsQueryable()
        {
            return objectSet.AsQueryable<T>();
        }

        public void Remove(T entity)
        {
            objectSet.Remove(entity);
        }

        public void RemoveRange(ICollection<T> entities)
        {
            objectSet.RemoveRange(entities);
        }
    }
}
