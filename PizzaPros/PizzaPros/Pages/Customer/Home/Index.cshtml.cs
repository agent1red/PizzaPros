using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PizzaPros.DataAccess.Data.Repository.IRepository;
using PizzaPros.Models;
using PizzaPros.Utility;

namespace PizzaPros.Pages.Customer.Home
{
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public IndexModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<PizzaType> PizzaTypeList { get; set; }
        public IEnumerable<Category> CategoryList { get; set; }
        public IEnumerable<ToppingType> ToppingTypeList { get; set; }
        public void OnGet()
        {
            // Retrieve the user id of the logged in user 
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            if (claim != null)
            {
                int ShoppingCartCount = _unitOfWork.ShoppingCart.GetAll(u => u.ApplicationUserId == claim.Value).ToList().Count;
                // assign to HttpContext 
                HttpContext.Session.SetInt32(SD.ShoppingCart, ShoppingCartCount);
            }

            PizzaTypeList = _unitOfWork.PizzaType
                .GetAll(null, q => q.OrderBy(c => c.PizzaSize.Size), "Category,ToppingType,PizzaCrustType,PizzaCrustFlavor,PizzaSize");
            CategoryList = _unitOfWork.Category.GetAll(null, q => q.OrderBy(c => c.DisplayOrder), null);
            ToppingTypeList = _unitOfWork.ToppingType.GetAll(null, q => q.OrderBy(c => c.Id), null);
        }
    }
}
