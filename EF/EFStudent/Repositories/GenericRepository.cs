using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using EFStudent.Contexts;
using EFStudent.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EFStudent.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly StudentContext _context;
        public GenericRepository(StudentContext context)
        {
            _context = context;
        }

        public T Add(T entity)
        {
            return _context.Set<T>().Add(entity).Entity;
        }
        public void AddRange(IEnumerable<T> entities)
        {
            _context.Set<T>().AddRange(entities);
        }
        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(expression);
        }
        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }
        public T GetById(Guid id)
        {
            return _context.Set<T>().Find(id);
        }
        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }
        public void RemoveRange(IEnumerable<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
        }
    }
}