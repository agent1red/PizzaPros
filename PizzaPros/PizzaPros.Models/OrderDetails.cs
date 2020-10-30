
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PizzaPros.Models
{
    public class OrderDetails
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int OrderId { get; set; }
        [ForeignKey("OrderId")]
        public virtual OrderHeader OrderHeader { get; set; }

        [Required]
        public int PizzaTypeID { get; set; }
        [ForeignKey("PizzaTypeID")]
        public virtual PizzaType PizzaType { get; set; }

        [Required]
        public double Price { get; set; }

        public int Count { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }



    }
}
