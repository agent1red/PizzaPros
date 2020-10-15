using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PizzaPros.Models
{
    public class PizzaSize
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Size { get; set; }

    }
}
