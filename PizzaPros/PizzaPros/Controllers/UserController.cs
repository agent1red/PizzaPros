using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaPros.DataAccess.Data.Repository.IRepository;

namespace PizzaPros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Json(new { data = _unitOfWork.ApplicationUser.GetAll() });
        }


        [HttpPost]
        public IActionResult LockUnlock([FromBody] string id)
        {
            var objFromDb = _unitOfWork.ApplicationUser.GetFirstOrDefault(u => u.Id == id);
            bool userIsLocked = objFromDb.LockoutEnd != null && objFromDb.LockoutEnd > DateTime.Now;

            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error while Locking/unlocking" });
            }
            // If user is locked
            if (userIsLocked)
            {
                objFromDb.LockoutEnd = DateTime.Now;
            }
            //If user is not locked
            else
            {
                objFromDb.LockoutEnd = DateTime.Now.AddMinutes(2);
            }
            _unitOfWork.Save();

            return userIsLocked ? Json(new { success = true, message = "User Unlocked Successful " })
                : Json(new { success = true, message = "User Locked Successful" });
        }

    }
}
