using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PizzaPros.Pages.Admin.Order
{
    [Authorize]
    public class OrderListModel : PageModel
    {
        
        public IActionResult OnGet()
        {
            return Page();
        }
    }
}
