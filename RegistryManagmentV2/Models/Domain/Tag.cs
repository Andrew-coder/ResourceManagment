using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RegistryManagmentV2.Models.Domain
{
    public class Tag
    {
        public Tag()
        {
        }

        public Tag(string tagValue)
        {
            TagValue = tagValue;
        }

        public long Id { get; set; }

        [StringLength(30)]
        [Index("TagValue_Index", IsUnique = true)]
        [Column(TypeName = "NVARCHAR")]
        [Required]
        public string TagValue { get; set; }
        public virtual ICollection<Resource> Resources { get; set; }
    }
}