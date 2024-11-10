using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testcsharp.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; } // Primary Key
        [Required]
        public string Tittle { get; set; }
        public string Description { get; set; }
        [Required]
        public string ISBN { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        [Display(Name = "List Price")]
        [Range(1,1000)]
        public string ListPrice { get; set; }
    }
}
