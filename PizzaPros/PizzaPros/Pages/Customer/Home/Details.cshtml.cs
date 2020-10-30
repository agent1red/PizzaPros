using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PizzaPros.DataAccess.Data.Repository.IRepository;
using PizzaPros.Models;
using PizzaPros.Utility;

namespace PizzaPros.Pages.Customer.Home
{
    [Authorize]
    public class DetailsModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public DetailsModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [BindProperty]
        public ShoppingCart ShopingCartObj { get; set; }

        public IEnumerable<PizzaType> PizzaTypeList { get; set; }
        public IEnumerable<Toppings> ToppingsList { get; set; }
        public void OnGet(int id)
        {
            ShopingCartObj = new ShoppingCart()
            {

                PizzaType = _unitOfWork.PizzaType.GetFirstOrDefault(includeProperties: "Category,ToppingType,PizzaCrustType,PizzaCrustFlavor,PizzaSize", filter: c => c.Id == id),
                PizzaTypeId = id
            };
            
            PizzaTypeList = _unitOfWork.PizzaType
               .GetAll(null, q => q.OrderBy(c => c.PizzaSize.Size), "Category,ToppingType,PizzaCrustType,PizzaCrustFlavor,PizzaSize");
            ToppingsList = _unitOfWork.Toppings.GetAll(null, q => q.OrderBy(c => c.Id), null);
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                // Retrieve the user id of the logged in user 
                var claimsIdentity = (ClaimsIdentity)this.User.Identity;
                var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

                ShopingCartObj.ApplicationUserId = claim.Value;
                //access the database for shopping cart 

                ShoppingCart cartFromDb = _unitOfWork.ShoppingCart.GetFirstOrDefault(c => c.ApplicationUserId == ShopingCartObj.ApplicationUserId &&
                                          c.PizzaTypeId == ShopingCartObj.PizzaTypeId);
                
                if (cartFromDb == null) // add new item to cart 
                {
                    _unitOfWork.ShoppingCart.Add(ShopingCartObj);
                    
                }
                else // if object exists increment count of object 
                {
                    
                    _unitOfWork.ShoppingCart.IncrementCount(cartFromDb, ShopingCartObj.Count);
                }
                _unitOfWork.Save();
                //increase the session 
                var count = _unitOfWork.ShoppingCart.GetAll(c => c.ApplicationUserId == ShopingCartObj.ApplicationUserId).ToList().Count;
                HttpContext.Session.SetInt32(SD.ShoppingCart, count);
                return RedirectToPage("Index");
            }
            else
            {
               ShopingCartObj.PizzaType = _unitOfWork.PizzaType.GetFirstOrDefault(includeProperties: "Category,ToppingType,PizzaCrustType,PizzaCrustFlavor,PizzaSize", filter: c => c.Id == ShopingCartObj.PizzaTypeId);
               return Page();
            }
        }
    }
}
