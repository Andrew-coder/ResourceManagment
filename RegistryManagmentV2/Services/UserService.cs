using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RegistryManagmentV2.Models;
using RegistryManagmentV2.Models.Domain;

namespace RegistryManagmentV2.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService()
        {
            _unitOfWork = new UnitOfWork();
        }

        //public User LoginUser(string email, string password)
        //{
        //    return _unitOfWork.UserRepository.AllEntities.SingleOrDefault(x => x.Email == email && x.Password == password);
        //}
    }
}