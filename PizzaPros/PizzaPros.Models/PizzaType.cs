using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;

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

        [Display(Name = "Topping 1")]
        public int ToppingOneId { get; set; }
        [ForeignKey("ToppingsId")]

        [Display(Name = "Topping 2")]
        public int ToppingTwoId { get; set; }
        [ForeignKey("ToppingsId")]

        [Display(Name = "Topping 3")]
        public string ToppingThreeId { get; set; }
        [ForeignKey("ToppingsId")]

        [Display(Name = "Topping 4")]
        public string ToppingFourId { get; set; }
        [ForeignKey("ToppingsId")]

        [Display(Name = "Topping 5")]
        public string ToppingFiveId { get; set; }
        [ForeignKey("ToppingsId")]

        [Display(Name = "Topping 6")]
        public string ToppingSixId { get; set; }
        [ForeignKey("ToppingsId")]

        [Display(Name = "Topping 7")]
        public string ToppingSevenId { get; set; }
        [ForeignKey("ToppingsId")]

        [Display(Name = "Topping 8")]
        public string ToppingEightId { get; set; }
        [ForeignKey("ToppingsId")]

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
