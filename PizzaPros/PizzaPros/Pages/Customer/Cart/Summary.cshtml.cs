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
using Stripe;

namespace PizzaPros.Pages.Customer.Cart
{
    public class SummaryModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public SummaryModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // view model to add 
        [BindProperty] // bind property to make it available to the OnPost() handler
        public OrderDetailsCartVM detailCart { get; set; }
        public IActionResult OnGet()
        {
            detailCart = new OrderDetailsCartVM()
            {
                OrderHeader = new Models.OrderHeader()
            };

            //Initialize OrderTotal to 0;
            detailCart.OrderHeader.OrderTotal = 0;

            //Retrieve shopping cart from db for the logged in user using claims 

            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            //retrieve shopping cart
            IEnumerable<ShoppingCart> cart = _unitOfWork.ShoppingCart.GetAll(c => c.ApplicationUserId == claim.Value);

            if (cart != null)
            {
                detailCart.listCart = cart.ToList();
            }

            foreach (var cartList in detailCart.listCart)
            {
                cartList.PizzaType = _unitOfWork.PizzaType.GetFirstOrDefault(m => m.Id == cartList.PizzaTypeId);
                cartList.PizzaType.Category = _unitOfWork.Category.GetFirstOrDefault(c => c.Id == cartList.PizzaType.CategoryId);

                //order total 

                detailCart.OrderHeader.OrderTotal += (cartList.PizzaType.Price * cartList.Count);
            }

            ApplicationUser applicationUser = _unitOfWork.ApplicationUser.GetFirstOrDefault(c => c.Id == claim.Value);
            detailCart.OrderHeader.PickupName = applicationUser.FullName;
            detailCart.OrderHeader.PickUpTime = DateTime.Now;
            detailCart.OrderHeader.PhoneNumber = applicationUser.PhoneNumber;
            return Page();
        }

        // stripe payment handler 
        public IActionResult OnPost(string stripeToken)
        {
            //create OrderHeader and Order Details and add inside the database
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            // Retrieve all the items from the shopping cart 
            detailCart.listCart = _unitOfWork.ShoppingCart.GetAll(c => c.ApplicationUserId == claim.Value).ToList();

            //Update OrderHeader and change the PaymentStatus for the order status and payment and add Date/Time
            detailCart.OrderHeader.PaymentStatus = SD.PaymentStatusPending;
            detailCart.OrderHeader.OrderDate = DateTime.Now;
            detailCart.OrderHeader.UserId = claim.Value;
            detailCart.OrderHeader.Status = SD.PaymentStatusPending;
            detailCart.OrderHeader.PickUpTime = Convert.ToDateTime(detailCart
                                                                .OrderHeader
                                                                .PickUpDate
                                                                .ToShortDateString() + " " + detailCart
                                                                .OrderHeader
                                                                .PickUpTime
                                                                .ToShortTimeString()
                                                                );
            detailCart.OrderHeader.PhoneNumber = detailCart.OrderHeader.PhoneNumber.Replace(" ", "")
                                        .Replace("(", "")
                                        .Replace(")", "")
                                        .Replace("-", "");

            List<OrderDetails> orderDetailslist = new List<OrderDetails>();
            _unitOfWork.OrderHeader.Add(detailCart.OrderHeader);
            _unitOfWork.Save();

            //Loop through OrderDetails
            foreach (var item in detailCart.listCart)
            {
                item.PizzaType = _unitOfWork.PizzaType.GetFirstOrDefault(m => m.Id == item.PizzaTypeId);
                OrderDetails orderDetails = new OrderDetails
                {
                    PizzaTypeID = item.PizzaTypeId,
                    OrderId = detailCart.OrderHeader.Id,
                    Description = item.PizzaType.Description,
                    Name = item.PizzaType.Name,
                    Price = item.PizzaType.Price,
                    Count = item.Count
                };
                // Modify the Order Total 

                detailCart.OrderHeader.OrderTotal += (orderDetails.Count * orderDetails.Price);
                // add to orderDetails database 
                _unitOfWork.OrderDetails.Add(orderDetails);
            }
            //added string conversion for formating price to $0.00 
            detailCart.OrderHeader.OrderTotal =  detailCart.OrderHeader.OrderTotal;
            // remove from cart from database using RemoveRange ref (Irepository, Repository)
            _unitOfWork.ShoppingCart.RemoveRange(detailCart.listCart);

            // End Session
            HttpContext.Session.SetInt32(SD.ShoppingCart, 0);
            _unitOfWork.Save();

            if(stripeToken != null)
            {
              // Charge Stripe using creditcard (Stripe Logic)
              var options = new ChargeCreateOptions
              {
                  //add amount in cents for stripe 
                  Amount = Convert.ToInt32(detailCart.OrderHeader.OrderTotal * 100),
                  Currency = "usd",
                  Source = stripeToken, // from  IActionResult OnPost(string stripeToken) argument
                  Description = "Order ID : " + detailCart.OrderHeader.Id, // from cart Orderheader.Id 
              };
              var service = new ChargeService();
              Charge charge = service.Create(options);

              // Log transaction ID from stripe to database 

              detailCart.OrderHeader.TransactionId = charge.Id;

              if (charge.Status.ToLower() == "succeeded")
              {
                  // if successful send email 
                  detailCart.OrderHeader.PaymentStatus = SD.PaymentStatusApproved;
                  detailCart.OrderHeader.Status = SD.StatusSubmitted;
              }
              else // not successful
              {
                  detailCart.OrderHeader.PaymentStatus = SD.PaymentStatusRejected;
              }

            }
            else // if stripeToken == null
            {
                detailCart.OrderHeader.PaymentStatus = SD.PaymentStatusRejected;
            }
            _unitOfWork.Save();
            // when successful transaction, redirect to OrderConfirmation page 
            return RedirectToPage("/Customer/Cart/OrderConfirmation", new {id = detailCart.OrderHeader.Id });
        }

    }
}
