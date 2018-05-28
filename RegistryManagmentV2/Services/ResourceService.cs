using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using RegistryManagmentV2.Models;
using RegistryManagmentV2.Models.Domain;

namespace RegistryManagmentV2.Services
{
    public class ResourceService : IResourceService
    {
        private readonly IUnitOfWork _uow;
        private readonly ITagService _tagService;

        public ResourceService()
        {
            _uow = new UnitOfWork();
            _tagService = new TagService(_uow);
        }

        public ResourceService(IUnitOfWork uow)
        {
            _uow = uow;
            _tagService = new TagService();
        }

        public List<Resource> GetAllResources(long? catalogId)
        {
            var resources = new List<Resource>();
            if (catalogId.HasValue)
            {
                resources = _uow.ResourceRepository
                    .AllEntities
                    .Where(resource => resource.CatalogId == catalogId)
                    .ToList();
            }
            else
            {
                resources = _uow.ResourceRepository
                    .AllEntities
                    .Where(resource => resource.Catalog == null)
                    .ToList();
            }
            return resources;
        }

        public List<Resource> GetRootResourcesForUserGroup()
        {
            return _uow.ResourceRepository.FindRootCatalogs();
        }

        public List<Resource> GetChildResourcesByUserGroup(long? catalogId, string groupName)
        {
            if (catalogId.HasValue)
            {
                return _uow.ResourceRepository.GetChildCatalogsByUserGroup(catalogId.Value);
            }

            return GetRootResourcesForUserGroup();
        }

        public void CreateResource(ResourceViewModel resourceViewModel, long catalogId)
        {
            var file = resourceViewModel.ResourceFile;
            var path = Path.Combine(resourceViewModel.ResourceLocation,  
                Path.GetFileName(file.FileName));  
            file.SaveAs(path);
            var catalog = _uow.CatalogRepository.GetById(catalogId);
            var tagNames = new Collection<string>(resourceViewModel.Tags.Split(','));
            var tags = _tagService.GetTagsWithNames(tagNames);
            var resource = new Resource
            {
                Title = resourceViewModel.Title,
                Description = resourceViewModel.Description,
                Language = resourceViewModel.Language,
                Format = resourceViewModel.Format,
                Location = path,
                Tags = tags,
                ResourceStatus = ResourceStatus.PendingForCreationApprove,
                Catalog = catalog
            };
            _uow.ResourceRepository.Add(resource);
            _uow.Save();
        }

        public void ApproveResource(long resourceId)
        {
            var resource =_uow.ResourceRepository.GetById(resourceId);
            resource.ResourceStatus = ResourceStatus.Approved;
            _uow.Save();
        }

        public void UpdateResource(Resource resource)
        {
            var resourceToBeUpdated = _uow.ResourceRepository.GetById(resource.Id);
            resourceToBeUpdated.Title = resource.Title;
            resourceToBeUpdated.Description = resource.Description;
            resourceToBeUpdated.Format = resource.Format;
            resourceToBeUpdated.Language = resource.Language;
            resourceToBeUpdated.Priority = resource.Priority;
            resourceToBeUpdated.Location = resource.Location;
            resourceToBeUpdated.ResourceStatus = resource.ResourceStatus;
            _uow.Save();
        }
    }
}