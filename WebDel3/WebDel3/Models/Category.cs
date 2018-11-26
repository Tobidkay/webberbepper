using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebDel3.Models
{
    public class Category
    {
        public Category()
        {
            ComponentCategoryTypes = new List<ComponentCategoryType>();
        }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public ICollection<ComponentCategoryType> ComponentCategoryTypes { get; protected set; }
    }
}