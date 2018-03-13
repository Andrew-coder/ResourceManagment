using System.Collections.Generic;

namespace RegistryManagmentV2.Models.Domain
{
    public class UserGroup
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Catalog> Catalogs { get; set; }
    }
}