using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegistryManagmentV2.Models.Domain
{
    public class Catalog
    {
        public long Id { get; set; }
        [Column(TypeName = "NVARCHAR")]
        public string Name { get; set; }
        [DefaultValue(5)] [Range(1, 10)] public int SecurityLevel { get; set; } = 5;
        public long? SuperCatalogId { get; set; }
        [ForeignKey("SuperCatalogId")]
        public virtual Catalog SuperCatalog { get; set; }
        public virtual ICollection<UserGroup> UserGroups { get; set; }
    }
}