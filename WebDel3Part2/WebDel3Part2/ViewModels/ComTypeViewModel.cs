using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebDel3Part2.Models;

namespace WebDel3Part2.ViewModels
{
    public class ComTypeViewModel
    {
        public ComponentType ComponentType { get; set; }
        public List<SelectListItem> Categories { get; set; }
        public List<string> ChoosenCategories { get; set; }
    }
}