using System.Collections.Generic;
using RegistryManagmentV2.Models;
using RegistryManagmentV2.Models.Domain;

namespace RegistryManagmentV2.Services
{
    public interface IResourceService
    {
        List<Resource> GetAllResources(long? catalogId);
        List<Resource> GetRootResourcesForUserGroup();
        List<Resource> GetChildResourcesByUserGroup(long? catalogId, string userGroup);
        void CreateResource(ResourceViewModel resourceViewModel, long catalogId);
        void ApproveResource(long resourceId);
        void UpdateResource(Resource resource);
    }
}