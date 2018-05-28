using System.Linq;
using RegistryManagmentV2.Models.Domain;

namespace RegistryManagmentV2.Models.Repository
{
    public class TagRepository : Repository<Tag>
    {
        public TagRepository(ApplicationDbContext context) : base(context)
        {
        }

        public Tag FindTagByText(string text)
        {
            return Context.Tags.FirstOrDefault(tag => tag.TagValue.Equals(text));
        }

        public bool CheckIfExists(string text)
        {
            return Context.Tags.Any(tag => tag.TagValue.Equals(text));
        }
    }
}