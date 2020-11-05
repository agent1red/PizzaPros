using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaPros.Models.ViewModels
{
    public class OrderDetailsVM
    {
        public OrderHeader OrderHeader { get; set; }
        public List<OrderDetails> OrderDetails { get; set; }// list used for more than one orderdetail item 
    }
}
