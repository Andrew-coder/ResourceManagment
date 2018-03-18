using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegistryManagmentV2.Models.Domain
{
    public class Catalog
    {
        public int Id { get; set; }
        [Column(TypeName = "NVARCHAR")]
        public string Name { get; set; }
        public virtual Catalog SuperCatalog { get; set; }
        public virtual ICollection<UserGroup> UserGroups { get; set; }
    }
}