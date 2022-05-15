using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Email is Required.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "UserName is Required.")]
        [Display(Name ="User Name")]
        [StringLength(50)]
        [MaxLength(50)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is Required.")]
        [Display(Name = "Password")]
        [StringLength(10)]
        [MaxLength(10)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool IsActive { get; set; }
    }
}