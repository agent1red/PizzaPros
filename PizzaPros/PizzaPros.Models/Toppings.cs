using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PizzaPros.Models
{
    public class Toppings
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Pizza Toppings")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Toppings Type")]
        public int ToppingTypeId { get; set; }
        [ForeignKey("ToppingTypeId")]
        public virtual ToppingType ToppingType { get; set; }

    }
}

