using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistryManagmentV2.Models
{
    public interface IUnitOfWork
    {
        IRepository<User> UserRepository { get; }

        void Save();
    }
}
