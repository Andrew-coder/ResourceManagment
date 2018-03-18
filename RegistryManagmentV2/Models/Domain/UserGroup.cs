using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegistryManagmentV2.Models.Domain
{
    public class UserGroup
    {
        public int Id { get; set; }
        [StringLength(30)]
        [Index]
        [Column(TypeName = "NVARCHAR")]
        public string Name { get; set; }
        public virtual ICollection<Catalog> Catalogs { get; set; }
    }
}