using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using RegistryManagmentV2.Models.Domain;

namespace RegistryManagmentV2.Models.Repository
{
    public class ResourceRepository : Repository<Resource>
    {
        public ResourceRepository(ApplicationDbContext context) : base(context)
        {
        }

        public List<Resource> FindRootCatalogs(UserGroup userGroup)
        {
            var catalogs = userGroup.Catalogs.Select(catalog => catalog.Id).ToArray();
            return Context.Resources
                .Where(resource => resource.Catalog == null)
                //.Where(resource => resource.Catalog.UserGroups.Contains(userGroup))
                .ToList();
        }

        public List<Resource> GetChildCatalogsByUserGroup(long catalogId, UserGroup userGroup)
        {
            return Context.Resources
                .Where(resource => resource.Catalog.Id == catalogId)
                //.Where(resource => resource.Catalog.UserGroups.Contains(userGroup))
                .ToList();
        }
    }
}