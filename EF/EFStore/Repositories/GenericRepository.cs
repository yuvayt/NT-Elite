using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using EFStore.Contexts;
using EFStore.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EFStore.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly StoreContext _context;
        internal DbSet<T> dbSet;
        public GenericRepository(StoreContext context)
        {
            this._context = context;
            this.dbSet = _context.Set<T>();
        }

        public T Add(T entity)
        {
            return dbSet.Add(entity).Entity;
        }
        public void AddRange(IEnumerable<T> entities)
        {
            dbSet.AddRange(entities);
        }
        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            return dbSet.Where(expression);
        }
        public IEnumerable<T> GetAll()
        {
            return dbSet.ToList();
        }
        public T GetById(Guid id)
        {
            return _context.Set<T>().Find(id);
        }
        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }
        public void RemoveRange(IEnumerable<T> entities)
        {
            dbSet.RemoveRange(entities);
        }
    }
}