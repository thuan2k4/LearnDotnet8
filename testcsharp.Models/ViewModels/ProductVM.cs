using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testcsharp.Models.ViewModels
{
    // File này để làm ViewModel cho Product
    public class ProductVM
    {
        public string Name { get; set; }
        public Product Product { get; set; }
        public IEnumerable<SelectListItem> CategoryList { get; set; }
    }
}
