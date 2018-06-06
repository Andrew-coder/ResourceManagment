using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegistryManagmentV2.Models.Domain
{
    public class UserGroup
    {
        public long Id { get; set; }
        [StringLength(30)]
        [Index("GroupName_Index", IsUnique = true)]
        [Column(TypeName = "NVARCHAR")]
        [Display(Name = "Імя")]
        public string Name { get; set; }
        [DefaultValue(5)]
        [Range(1, 10)]
        public int SecurityLevel { get; set; } = 5;
        public virtual ICollection<Catalog> Catalogs { get; set; }
    }
}