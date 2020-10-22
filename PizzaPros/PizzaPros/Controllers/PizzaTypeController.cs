using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaPros.DataAccess.Data.Repository.IRepository;

namespace PizzaPros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaTypeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        //Will be deleting images from server
        private readonly IWebHostEnvironment _hostingEnvironment;

        public PizzaTypeController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostingEnvironment = hostEnvironment;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Json(new
            {
                data = _unitOfWork.PizzaType
                .GetAll(null, null, "Category,ToppingType,PizzaCrustType,PizzaCrustFlavor,PizzaSize")
            });

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            try
            {
                var objFromDb = _unitOfWork.PizzaType.GetFirstOrDefault(p => p.Id == id);
                if (objFromDb == null)
                {
                    return Json(new { success = false, message = "Error while deleting" });
                }

                //check if image is in root 
                var imagePath = Path.Combine(_hostingEnvironment.WebRootPath, objFromDb.Image.TrimStart('\\'));
                if (System.IO.File.Exists(imagePath))
                {
                    System.IO.File.Delete(imagePath);
                }
                _unitOfWork.PizzaType.Remove(objFromDb);
                _unitOfWork.Save();

            }
            catch (Exception ex)
            {

                return Json(new { success = true, message = "Error while deleting" });
            }

            return Json(new { success = true, message = "Delete successful" });
        }

    }
}
