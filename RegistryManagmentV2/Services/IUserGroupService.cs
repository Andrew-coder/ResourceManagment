using System.Collections.Generic;
using RegistryManagmentV2.Models.Domain;

namespace RegistryManagmentV2.Services
{
    public interface IUserGroupService
    {
        List<UserGroup> GetAllUserGroups();
        UserGroup GetUserGroupById(long id);
        void CreateUserGroup(UserGroup userGroup);
        void UpdateUserGroup(UserGroup userGroup);
        void DeleteUserGroup(long id);
    }
}