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
    public class ToppingsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ToppingsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Json(new { data = _unitOfWork.Toppings.GetAll(null, null, "ToppingType") });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            var objFromDb = _unitOfWork.Toppings.GetFirstOrDefault(u => u.Id == id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }
                _unitOfWork.Toppings.Remove(objFromDb);
                _unitOfWork.Save();
                return Json(new { success = true, message = "Delete successful" });
        }

    }
}
