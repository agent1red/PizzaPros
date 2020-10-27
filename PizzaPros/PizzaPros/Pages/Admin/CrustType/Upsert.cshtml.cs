using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PizzaPros.DataAccess.Data.Repository.IRepository;
using PizzaPros.Utility;

namespace PizzaPros.Pages.Admin.CrustType
{
    [Authorize(Roles = SD.ManagerRole)]
    public class UpsertModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpsertModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [BindProperty]
        public Models.PizzaCrustType PizzaCrustTypeObj { get; set; }


        public IActionResult OnGet(int? id)
        {
            PizzaCrustTypeObj = new Models.PizzaCrustType();
            if (id != null)
            {
                PizzaCrustTypeObj = _unitOfWork.PizzaCrustType.GetFirstOrDefault(p => p.Id == id);
                if (PizzaCrustTypeObj == null)
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
            if (PizzaCrustTypeObj.Id == 0)
            {
                _unitOfWork.PizzaCrustType.Add(PizzaCrustTypeObj);
            }
            else
            {
                _unitOfWork.PizzaCrustType.Update(PizzaCrustTypeObj);
            }
            _unitOfWork.Save();
            return RedirectToPage("./Index");
        }
    }
}
