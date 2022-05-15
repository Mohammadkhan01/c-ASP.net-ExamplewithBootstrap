using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.ViewModel
{
    public class ProductFromViewModel
    {
        public Product Product { get; set; }
        public List<Category> Categories { get; set; }

    }
}