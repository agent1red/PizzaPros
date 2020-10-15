using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PizzaPros.Models
{
   public class PizzaType
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Image { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Price should be greater than $1")]
        public double Price { get; set; }

        [Display(Name = "Category Type")]
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

        [Display(Name = "Topping Type")]
        public int ToppingTypeId { get; set; }
        [ForeignKey("ToppingTypeId")]
        public virtual ToppingType ToppingType { get; set; }

        [Display(Name = "Crust Type")]
        public int PizzaCrustId { get; set; }
        [ForeignKey("PizzaCrustId")]
        public virtual PizzaCrust PizzaCrust { get; set; }

        [Display(Name = "Pizza Size")]
        public int PizzaSizeId { get; set; }
        [ForeignKey("PizzaSizeId")]
        public virtual PizzaSize PizzaSize { get; set; }
    }
}
