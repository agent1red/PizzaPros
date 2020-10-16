using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PizzaPros.DataAccess.Data.Repository.IRepository;

namespace PizzaPros.Pages.Admin.CrustFlavor
{
    public class UpsertModel : PageModel
    {


        private readonly IUnitOfWork _unitOfWork;

        public UpsertModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [BindProperty]
        public Models.PizzaCrustFlavor PizzaCrustFlavorObj { get; set; }


        public IActionResult OnGet(int? id)
        {
            PizzaCrustFlavorObj = new Models.PizzaCrustFlavor();
            if (id != null)
            {
                PizzaCrustFlavorObj = _unitOfWork.PizzaCrustFlavor.GetFirstOrDefault(p => p.Id == id);
                if (PizzaCrustFlavorObj == null)
                {
                    return NotFound();
                }
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (PizzaCrustFlavorObj.Id == 0)
            {
                _unitOfWork.PizzaCrustFlavor.Add(PizzaCrustFlavorObj);
            }
            else
            {
                _unitOfWork.PizzaCrustFlavor.Update(PizzaCrustFlavorObj);
            }
            _unitOfWork.Save();
            return RedirectToPage("./Index");
        }

    }
}
