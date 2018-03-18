using System.Collections.Generic;
using RegistryManagmentV2.Models;
using RegistryManagmentV2.Models.Domain;

namespace RegistryManagmentV2.Services
{
    public interface IResourceService
    {
        List<Resource> GetRootResourcesForUserGroup(string groupName);
        List<Resource> GetChildResourcesByUserGroup(long catalogId, string userGroup);
        void CreateResource(ResourceViewModel resourceViewModel, int catalogId);
    }
}