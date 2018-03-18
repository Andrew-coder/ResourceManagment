using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc.Html;
using RegistryManagmentV2.Models.Domain;

namespace RegistryManagmentV2.Models.Repository
{
    public class CatalogRepository : Repository<Catalog>
    {
        public CatalogRepository(ApplicationDbContext context) : base(context)
        {
           
        }

        public List<Catalog> FindRootCatalogs(UserGroup userGroup)
        {
            var catalogs = userGroup.Catalogs.Select(catalog => catalog.Id).ToArray();
            return Context.Catalogs
                .Where(catalog => catalog.SuperCatalog == null)
                .Where(catalog => catalogs.Contains(catalog.Id))
                .ToList();
        }
        
        public List<Catalog> GetAllChildCatalogs(long catalogId)
        { 
            return Context.Catalogs
                .Where(catalog => catalog.SuperCatalogId == catalogId)
                .ToList();
        }
        
        public List<Catalog> GetChildCatalogsByUserGroup(long catalogId, UserGroup userGroup)
        {
            var catalogs = userGroup.Catalogs.Select(catalog => catalog.Id).ToArray();
            return Context.Catalogs
                .Where(catalog => catalog.SuperCatalogId == catalogId)
                .Where(catalog => catalogs.Contains(catalog.Id))
                .ToList();
        }
    }
}