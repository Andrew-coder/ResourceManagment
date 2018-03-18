using RegistryManagmentV2.Models;

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