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
    public class PizzaCrustFlavorController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public PizzaCrustFlavorController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Json(new { data = _unitOfWork.PizzaCrustFlavor.GetAll() });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            var objFromDb = _unitOfWork.PizzaCrustFlavor.GetFirstOrDefault(u => u.Id == id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }
                _unitOfWork.PizzaCrustFlavor.Remove(objFromDb);
                _unitOfWork.Save();
                return Json(new { success = true, message = "Delete successful" });
        }

    }
}
