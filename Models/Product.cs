using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Product Name is Required.")]
        [Display(Name = "Product Name")]
        [StringLength(50, ErrorMessage = "Product Name should be less then or 50 Character")]

        public string Name { get; set; }
        [Required(ErrorMessage = "Product Price is Required.")]
        [DataType(DataType.Currency)]
        public double Price { get; set; }
        [Required(ErrorMessage = "Product Supplier Name is Required.")]
        [DataType(DataType.MultilineText)]
       
        public int CategoryId { get; set; }//Forign Key

        //Load Products with their categories
        public Category Category { get; set; }
        public string Supplier { get; set; }
    }
}