using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PizzaPros.Models
{
    public class PizzaCrustFlavor
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name ="Crust Flavor")]
        public string CrustFlavor { get; set; }
        [Required]
        [Display(Name = "Flavor Description")]
        public string CrustFlavorDescription { get; set; }
        

    }
}
