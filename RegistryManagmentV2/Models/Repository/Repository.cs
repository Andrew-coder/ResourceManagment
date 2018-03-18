using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RegistryManagmentV2.Models.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        public ApplicationDbContext Context { get; }

        public Repository(ApplicationDbContext context)
        {
            Context = context;
        }
        public IQueryable<T> AllEntities => Context.Set<T>();

        public T GetById(long id)
        {
            return Context.Set<T>().Find(id);
        }

        public void Add(T item)
        {
            Context.Set<T>().Add(item);
        }

        public void Remove(T item)
        {
            Context.Set<T>().Remove(item);
        }

        public void Update(T item)
        {
            Context.Entry(item).State = EntityState.Modified;
        }
    }
}