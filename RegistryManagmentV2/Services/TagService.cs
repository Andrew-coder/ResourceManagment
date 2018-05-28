using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Migrations;
using System.Linq;
using RegistryManagmentV2.Models;
using RegistryManagmentV2.Models.Domain;
using WebGrease.Css.Extensions;

namespace RegistryManagmentV2.Services
{
    public class TagService : ITagService
    {
        private readonly IUnitOfWork _uow;

        public TagService()
        {
            _uow = new UnitOfWork();
        }

        public TagService(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public List<Tag> GetTagsWithNames(Collection<string> names)
        {
            return names.Distinct().Select(GetSingleTagByValueOrCreateNew).ToList();
        }

        private Tag GetSingleTagByValueOrCreateNew(string tagValue)
        {
            if(_uow.TagRepository.CheckIfExists(tagValue))
            {
                return _uow.TagRepository.FindTagByText(tagValue);
            }
            return new Tag(tagValue);
        }
    }
}