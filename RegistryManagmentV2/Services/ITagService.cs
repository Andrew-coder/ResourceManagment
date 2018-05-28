using System.Collections.Generic;
using System.Collections.ObjectModel;
using RegistryManagmentV2.Models.Domain;

namespace RegistryManagmentV2.Services
{
    public interface ITagService
    {
        List<Tag> GetTagsWithNames(Collection<string> names);
    }
}
