using System.Collections.Generic;
using System.Drawing;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebDel3Part2.Models;

namespace WebDel3Part2.ViewModels
{
    public class ComTypeViewModel
    {
        public IFormFile Image { get; set; }
        public ComponentType ComponentType { get; set; }
        public List<SelectListItem> Categories { get; set; }
        public List<string> ChoosenCategories { get; set; }
    }
}