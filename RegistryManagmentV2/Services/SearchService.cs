using System.Collections.Generic;
using RegistryManagmentV2.Models;
using RegistryManagmentV2.Models.Domain;

namespace RegistryManagmentV2.Services
{
    public class SearchService : ISearchService
    {
        private readonly IUnitOfWork _uow;

        public SearchService()
        {
            _uow = new UnitOfWork();
        }

        public IList<Resource> SearchResourcesByTags(IList<string> tags, bool isAdmin)
        {
            if (isAdmin)
            {
                return _uow.ResourceRepository.GetAllResourcesByTagsOrderedByPriority(tags);
            }
            return _uow.ResourceRepository.GetApprovedResourcesByTagsOrderedByPriority(tags);
        }
    }
}