using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebDel3Part2.Models
{
    public class ComponentCategoryType
    {
        
        [Key]
        [Column(Order = 0)]
        public long CategoryId { get; set; }
        public Category Category { get; set; }

        [Key]
        [Column(Order = 1)]
        public long ComponentTypeId { get; set; }
        public ComponentType ComponentType { get; set; }
    }
}