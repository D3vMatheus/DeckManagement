﻿using DeckManager.Context;
using DeckManager.Repositories.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DeckManager.Repositories.Services
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected DeckManagerDbContext _context;
        
        public Repository(DeckManagerDbContext context)
        {
            _context = context;
        }

        public IEnumerable<T>? GetAll()
        {
            return _context.Set<T>().AsNoTracking().ToList();
        }

        public T? Get(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().AsNoTracking().FirstOrDefault(predicate);
        }
        public T? Post(T entity)
        {
            _context.Set<T>().Add(entity);

            return entity;

        }
        public T? Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return entity;  
        }

        public T? Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            return entity;
        }
    }
}
