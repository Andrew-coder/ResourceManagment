
using System.Collections.Generic;
using RegistryManagmentV2.Models.Domain;

namespace RegistryManagmentV2.Services
{
    public interface ISearchService
    {
        IList<Resource> SearchResourcesByTags(IList<string> tags);
    }
}
