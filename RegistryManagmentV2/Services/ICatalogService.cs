using System.Collections.Generic;
using RegistryManagmentV2.Models.Domain;

namespace RegistryManagmentV2.Services
{
    public interface ICatalogService
    {
        List<Catalog> GetAllCatalogs(long? catalogId);
        List<Catalog> GetRootCatalogsForUserGroup(string groupName);
        List<Catalog> GetChildCatalogsByUserGroup(long? catalogId, string userGroup);
        void SaveCatalog(Catalog catalog);
    }
}