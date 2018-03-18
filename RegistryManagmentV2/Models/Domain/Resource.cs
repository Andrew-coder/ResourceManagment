using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegistryManagmentV2.Models.Domain
{
    public class Resource
    {
        public long Id { get; set; }
        [Column(TypeName = "NVARCHAR")]
        public string Title { get; set; }
        public string Description { get; set; }
        public string Language { get; set; }
        public string Format { get; set; }
        [Range (1,3)]
        public int? Priority { get; set; }
        public ResourceStatus ResourceStatus { get; set; }
        public string Location { get; set; }
        
        public long? CatalogId { get; set; }
        [ForeignKey("CatalogId")]
        public virtual Catalog Catalog { get; set; }
    }
}