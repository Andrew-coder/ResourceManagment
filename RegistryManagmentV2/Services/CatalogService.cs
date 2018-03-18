using System.Collections.Generic;
using System.Linq;
using RegistryManagmentV2.Models;
using RegistryManagmentV2.Models.Domain;

namespace RegistryManagmentV2.Services
{
    public class CatalogService : ICatalogService
    {
        private readonly IUnitOfWork _uow;

        public CatalogService()
        {
            _uow = new UnitOfWork();
        }

        public CatalogService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public List<Catalog> GetAllCatalogs(long? catalogId)
        {
            var catalogs = new List<Catalog>();
            if (catalogId.HasValue)
            {
                catalogs = _uow.CatalogRepository.GetAllChildCatalogs(catalogId.Value);
            }
            else
            {
                catalogs = _uow.CatalogRepository
                    .AllEntities
                    .Where(catalog => catalog.SuperCatalog == null)
                    .ToList();
            }
            return catalogs;
        }

        public List<Catalog> GetRootCatalogsForUserGroup(string groupName)
        {
            var userGroup = _uow.UserGroupRepository.FindUserGroupByName(groupName);
            return _uow.CatalogRepository.FindRootCatalogs(userGroup);
        }

        public List<Catalog> GetChildCatalogsByUserGroup(long? catalogId, string groupName)
        {
            var userGroup = _uow.UserGroupRepository.FindUserGroupByName(groupName);
            if (catalogId.HasValue)
            {
                return _uow.CatalogRepository.GetChildCatalogsByUserGroup(catalogId.Value, userGroup);
            }
            return GetRootCatalogsForUserGroup(groupName);
        }
    }
}
