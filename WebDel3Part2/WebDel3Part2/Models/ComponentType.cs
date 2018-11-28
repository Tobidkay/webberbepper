using System.Collections.Generic;
using System.ComponentModel;

namespace WebDel3Part2.Models
{
    public class ComponentType
    {
        public ComponentType()
        {
            Components = new List<Component>();
            ComponentCategoryTypes = new List<ComponentCategoryType>();
        }
        public long ComponentTypeId { get; set; }
        [DisplayName("Component Name")]
        public string ComponentName { get; set; }
        [DisplayName("Component Info")]
        public string ComponentInfo { get; set; }
        public string Location { get; set; }
        public ComponentStatus Status { get; set; }
        public string Datasheet { get; set; }
        [DisplayName("Image Url")]
        public string ImageUrl { get; set; }
        public string Manufacturer { get; set; }
        public string WikiLink { get; set; }
        [DisplayName("Admin Comment")]
        public string AdminComment { get; set; }
        public virtual ESImage Image { get; set; }
        public ICollection<Component> Components { get; protected set; }
        public ICollection<ComponentCategoryType> ComponentCategoryTypes { get; set; }
    }
}