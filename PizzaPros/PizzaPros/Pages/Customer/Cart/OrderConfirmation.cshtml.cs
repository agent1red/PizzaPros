using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PizzaPros.Pages.Customer.Cart
{
    [Authorize]
    public class OrderConfirmationModel : PageModel
    {
        [BindProperty] // from summary post() handler id
        public int orderId { get; set; }
        public void OnGet(int id )
        {
            orderId = id;
        }
    }
}
