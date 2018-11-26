using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebDel3.Models
{
    public class ComponentCategoryType
    {
        [Key]
        [Column(Order = 0)]
        public int ComponentTypeId { get; set; }
        public ComponentType ComponentType { get; set; }
        [Key]
        [Column(Order = 1)]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}