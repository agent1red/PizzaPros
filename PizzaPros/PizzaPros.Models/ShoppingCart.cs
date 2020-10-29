using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PizzaPros.Models
{
    public class ShoppingCart
    {
        public ShoppingCart()
        {
            Count = 1;
        }
        public int Id { get; set; }

        public int PizzaTypeId { get; set; }
        [NotMapped]
        [ForeignKey("PizzaTypeId")]
        public virtual PizzaType PizzaType { get; set; }

        public string ApplicationUserId { get; set; }

        [NotMapped]
        [ForeignKey("ApplicationUserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }

        [Range(1,20, ErrorMessage = "You can only add up to 20 items.")]
        public int Count { get; set; }
    }
}
