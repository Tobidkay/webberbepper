using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebDel3Part2.Models
{
    public class ComTypeViewModel
    {
        public ComponentType ComponentType { get; set; }
        public List<SelectListItem> Categories { get; set; }
        public List<string> ChoosenCategories { get; set; }
    }
}