
using System.Linq;
using RegistryManagmentV2.Models.Domain;

namespace RegistryManagmentV2.Models.Repository
{
    public class UserGroupRepository : Repository<UserGroup>
    {
        public UserGroupRepository(ApplicationDbContext context) : base(context)
        {
        }

        public UserGroup FindUserGroupByName(string name)
        {
            return Context.UserGroups.First(userGroup => userGroup.Name.Equals(name));
        }
    }
}