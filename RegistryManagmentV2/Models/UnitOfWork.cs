using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RegistryManagmentV2.Models.Domain;
using RegistryManagmentV2.Models.Repository;

namespace RegistryManagmentV2.Models
{
    public class UnitOfWork : IUnitOfWork
    {
        private static ApplicationDbContext _context = new ApplicationDbContext();

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}