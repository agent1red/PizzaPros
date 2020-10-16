using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PizzaPros.Models
{
    public class PizzaCrustType
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Crust Type")]
        public string CrustType { get; set; }
        [Required]
        [Display(Name = "Crust Type Description")]
        public string CrustTypeDescription { get; set; }

    }
}
