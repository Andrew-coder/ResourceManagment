using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RegistryManagmentV2.Models.Domain;

namespace RegistryManagmentV2.Models
{
    public interface IUnitOfWork
    {
        //IRepository<User> UserRepository { get; }

        void Save();
    }
}
