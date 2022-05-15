using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        [Display(Name = "Category Name")]
        public string Name { get; set; }
    }
}