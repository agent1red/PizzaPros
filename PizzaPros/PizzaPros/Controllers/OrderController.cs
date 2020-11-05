using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaPros.DataAccess.Data.Repository.IRepository;
using PizzaPros.Models;
using PizzaPros.Models.ViewModels;
using PizzaPros.Utility;

namespace PizzaPros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : Controller 
    {

        private readonly IUnitOfWork _unitOfWork;

        public OrderController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //Updated to get data from OrderList page for Cancelled, Completed, or Inprocessed orders 
        [HttpGet]
        [Authorize]
        public  IActionResult Get(string status = null)
        {
            List<OrderDetailsVM> orderListVM = new List<OrderDetailsVM>();

            IEnumerable<OrderHeader> OrderHeaderList;

            if (User.IsInRole(SD.CustomerRole))
            {
                // retrieve all order for the logged in customer from database
                var claimsIdentity = (ClaimsIdentity)User.Identity;
                var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
                // get info from single customer and display ApplicationUser properties 
                OrderHeaderList = _unitOfWork.OrderHeader.GetAll(u => u.UserId == claim.Value, null, "ApplicationUser");
            }
            else
            {
                //If not customer retrieve all the orders 
                OrderHeaderList = _unitOfWork.OrderHeader.GetAll(null, null, "ApplicationUser");
            }

            //Added to get data from OrderList page for Cancelled, Completed, or Inprocessed orders 
            if (status == "cancelled")
            {
                OrderHeaderList = OrderHeaderList.Where(o => o.Status == SD.StatusCancelled 
                                                        || o.Status == SD.StatusRefunded
                                                        || o.Status == SD.PaymentStatusRejected);
            }
            else
            {
                if (status == "completed")
                {
                    OrderHeaderList = OrderHeaderList.Where(o => o.Status == SD.StatusCompleted);
                }
                else
                {
                    OrderHeaderList = OrderHeaderList.Where(o => o.Status == SD.StatusReady 
                                                                || o.Status == SD.StatusInProcess 
                                                                || o.Status == SD.StatusSubmitted
                                                                || o.Status == SD.PaymentStatusPending);
                }
            }

            foreach (OrderHeader item in OrderHeaderList)
            {
                OrderDetailsVM individual = new OrderDetailsVM
                {
                    // assign order header 
                    OrderHeader = item,
                    // retrieve from DataBase
                    OrderDetails = _unitOfWork.OrderDetails.GetAll(o => o.OrderId == item.Id).ToList()
                };
            // Add to orderListVM
            orderListVM.Add(individual);
            }
            return Json(new { data = orderListVM });
        }
    }
}
