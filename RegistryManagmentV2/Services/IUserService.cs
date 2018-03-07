using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RegistryManagmentV2.Models;

namespace RegistryManagmentV2.Services
{
    public interface IUserService
    {
        User LoginUser(string login, string password);
    }
}
