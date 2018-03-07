using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RegistryManagmentV2.Models.Repository
{
    public class UserRepository : Repository<User>
    {
        public UserRepository(DbContext context) : base(context) { }
    }
}