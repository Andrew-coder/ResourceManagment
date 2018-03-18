using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegistryManagmentV2.Models.Domain
{
    public class Resource
    {
        public int Id { get; set; }
        [Column(TypeName = "NVARCHAR")]
        public string Title { get; set; }
        public string Description { get; set; }
        public string Language { get; set; }
        public string Format { get; set; }
        [Range (1,3)]
        public int? Priority { get; set; }
        public virtual Catalog Catalog { get; set; }
    }
}