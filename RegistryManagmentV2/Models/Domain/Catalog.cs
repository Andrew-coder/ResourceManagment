using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegistryManagmentV2.Models.Domain
{
    public class Catalog
    {
        public long Id { get; set; }
        [Column(TypeName = "NVARCHAR")]
        public string Name { get; set; }
        public long? SuperCatalogId { get; set; }
        [ForeignKey("SuperCatalogId")]
        public virtual Catalog SuperCatalog { get; set; }
        public virtual ICollection<UserGroup> UserGroups { get; set; }
    }
}