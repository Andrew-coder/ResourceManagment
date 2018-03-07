using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RegistryManagmentV2.Models.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        private DbContext _context;
        public Repository(DbContext context)
        {
            _context = context;
        }
        public IQueryable<T> AllEntities => _context.Set<T>();

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Add(T item)
        {
            _context.Set<T>().Add(item);
        }

        public void Remove(T item)
        {
            _context.Set<T>().Remove(item);
        }

        public void Update(T item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }
    }
}