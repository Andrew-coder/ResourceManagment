using System.Collections.Generic;

namespace RegistryManagmentV2.Models.Domain
{
    public class Catalog
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual Catalog SuperCatalog { get; set; }
        public virtual ICollection<UserGroup> UserGroups { get; set; }
    }
}