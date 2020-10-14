using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PizzaPros.Models
{
    public class ToppingType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Topping Type")]
        public string Name { get; set; }
    }
}
