using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PizzaPros.DataAccess.Data.Repository.IRepository;
using PizzaPros.Models.ViewModels;

namespace PizzaPros.Pages.Admin.PizzaType
{
    public class UpsertModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public UpsertModel(IUnitOfWork unitOfWork, IWebHostEnvironment hostingEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostingEnvironment = hostingEnvironment;
        }



        // Object of PizzaType property from new view model
        [BindProperty]
        public PizzaTypeVM PizzaTypeObj { get; set; }

        //populate the viewmodel dropdown for all the associated lsits 
        public IActionResult OnGet(int? id)
        {

            PizzaTypeObj = new PizzaTypeVM
            {
                
                CategoryList = _unitOfWork.Category.GetCategoryListForDropDown(),
                ToppingTypeList = _unitOfWork.ToppingType.GetToppingTypeListForDropDown(),
                ToppingsList = _unitOfWork.Toppings.GetToppingListForDropDown(),
                PizzaCrustTypeList = _unitOfWork.PizzaCrustType.GetPizzaCrustTypeListForDropDown(),
                PizzaCrustFlavorList = _unitOfWork.PizzaCrustFlavor.GetPizzaCrustFlavorListForDropDown(),
                PizzaSizeList = _unitOfWork.PizzaSize.GetPizzaSizeListForDropDown(),
                PizzaType = new Models.PizzaType()
            };
            if (id != null)
            {
                PizzaTypeObj.PizzaType = _unitOfWork.PizzaType.GetFirstOrDefault(u => u.Id == id);
                if (PizzaTypeObj == null)
                {
                    return NotFound();
                }
            }
            return Page();
        }


        //Save the image the user uploads to pizzaType image folder
        public IActionResult OnPost()
        {
            string webRootPath = _hostingEnvironment.WebRootPath;
            var files = HttpContext.Request.Form.Files;

            if (!ModelState.IsValid)
            {
                PizzaTypeObj = new PizzaTypeVM
                {
                    CategoryList = _unitOfWork.Category.GetCategoryListForDropDown(),
                    ToppingTypeList = _unitOfWork.ToppingType.GetToppingTypeListForDropDown(),
                    ToppingsList = _unitOfWork.Toppings.GetToppingListForDropDown(),
                    PizzaCrustTypeList = _unitOfWork.PizzaCrustType.GetPizzaCrustTypeListForDropDown(),
                    PizzaCrustFlavorList = _unitOfWork.PizzaCrustFlavor.GetPizzaCrustFlavorListForDropDown(),
                    PizzaSizeList = _unitOfWork.PizzaSize.GetPizzaSizeListForDropDown(),
                    PizzaType = new Models.PizzaType()
                };
                return Page();
            }

            if (PizzaTypeObj.PizzaType.Id == 0)
            {
                //save file as Guid
                string fileName = Guid.NewGuid().ToString();
                //Find the path for uploads 
                var uploads = Path.Combine(webRootPath, @"images\pizzaTypes");
                var extension = Path.GetExtension(files[0].FileName);

                using (var fileStream = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                {
                    files[0].CopyTo(fileStream);
                }
                PizzaTypeObj.PizzaType.Image = @"\images\pizzaTypes\" + fileName + extension;

                _unitOfWork.PizzaType.Add(PizzaTypeObj.PizzaType);
            }
            else
            {
                //EDIT pizzaType retrieved from database
                var objFromDb = _unitOfWork.PizzaType.Get(PizzaTypeObj.PizzaType.Id);
                if (files.Count > 0)
                {
                    //New file wasn't uploaded

                    string fileName = Guid.NewGuid().ToString();
                    var uploads = Path.Combine(webRootPath, @"images\pizzaTypes");
                    var extension = Path.GetExtension(files[0].FileName);

                    var imagePath = Path.Combine(webRootPath, objFromDb.Image.TrimStart('\\'));
                    if (System.IO.File.Exists(imagePath))
                    {
                        System.IO.File.Delete(imagePath);
                    }


                    using (var fileStream = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                    {
                        files[0].CopyTo(fileStream);
                    }
                    PizzaTypeObj.PizzaType.Image = @"\images\pizzaTypes\" + fileName + extension;

                }
                else
                {
                    PizzaTypeObj.PizzaType.Image = objFromDb.Image;
                }


                _unitOfWork.PizzaType.Update(PizzaTypeObj.PizzaType);
            }
            _unitOfWork.Save();
            return RedirectToPage("./Index");
        }

    }
}
