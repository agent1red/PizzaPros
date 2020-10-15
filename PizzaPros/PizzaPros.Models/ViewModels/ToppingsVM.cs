using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaPros.Models.ViewModels
{
    public class ToppingsVM
    {
        public Toppings Toppings { get; set; }

        public IEnumerable<SelectListItem> ToppingTypeList { get; set; }
    }
}
