using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RegistryManagmentV2.Models.Repository;

namespace RegistryManagmentV2.Models
{
    public class UnitOfWork : IUnitOfWork
    {
        private static ApplicationDbContext _context = new ApplicationDbContext();
        public IRepository<User> UserRepository { get; } = new UserRepository(_context);

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}