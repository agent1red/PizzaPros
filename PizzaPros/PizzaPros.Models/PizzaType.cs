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
        public string Image { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Price should be greater than $1")]
        public double Price { get; set; }

        /// <summary>
        /// pizza ingredients
        /// </summary>

        public string ToppingOne { get; set; }
        public string ToppingTwo { get; set; }
        public string ToppingThree { get; set; }
        public string ToppingFour { get; set; }
        public string ToppingFive { get; set; }
        public string ToppingSix { get; set; }
        public string ToppingSeven { get; set; }
        public string ToppingEight { get; set; }

        [Display(Name = "Category Type")]
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

        [Display(Name = "Topping Type")]
        public int ToppingTypeId { get; set; }
        [ForeignKey("ToppingTypeId")]
        public virtual ToppingType ToppingType { get; set; }

        [Display(Name = "Crust Type")]
        public int PizzaCrustTypeId { get; set; }
        [ForeignKey("PizzaCrustTypeId")]
        public virtual PizzaCrustType PizzaCrustType { get; set; }

        [Display(Name = "Crust Flavor")]
        public int PizzaCrustFlavorId { get; set; }
        [ForeignKey("PizzaCrustFlavorId")]
        public virtual PizzaCrustFlavor PizzaCrustFlavor { get; set; }

        [Display(Name = "Pizza Size")]
        public int PizzaSizeId { get; set; }
        [ForeignKey("PizzaSizeId")]
        public virtual PizzaSize PizzaSize { get; set; }
    }
}
