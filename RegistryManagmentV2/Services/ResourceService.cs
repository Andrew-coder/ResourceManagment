using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Web;
using RegistryManagmentV2.Models;
using RegistryManagmentV2.Models.Domain;

namespace RegistryManagmentV2.Services
{
    public class ResourceService : IResourceService
    {
        private readonly IUnitOfWork _uow;

        public ResourceService()
        {
            _uow = new UnitOfWork();
        }

        public ResourceService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public List<Resource> GetRootResourcesForUserGroup(string groupName)
        {
            var userGroup = _uow.UserGroupRepository.FindUserGroupByName(groupName);
            return _uow.ResourceRepository.FindRootCatalogs(userGroup);
        }

        public List<Resource> GetChildResourcesByUserGroup(long catalogId, string groupName)
        {
            var userGroup = _uow.UserGroupRepository.FindUserGroupByName(groupName);
            return _uow.ResourceRepository.GetChildCatalogsByUserGroup(catalogId, userGroup);
        }

        public void CreateResource(ResourceViewModel resourceViewModel, int catalogId)
        {
            var file = resourceViewModel.ResourceFile;
            var path = Path.Combine(resourceViewModel.ResourceLocation,  
                Path.GetFileName(file.FileName));  
            file.SaveAs(path);
            var catalog = _uow.CatalogRepository.GetById(catalogId);
            var resource = new Resource
            {
                Title = resourceViewModel.Title,
                Description = resourceViewModel.Description,
                Language = resourceViewModel.Language,
                Format = resourceViewModel.Format,
                Catalog = catalog
            };
            _uow.ResourceRepository.Add(resource);
            _uow.Save();
        }
    }
}