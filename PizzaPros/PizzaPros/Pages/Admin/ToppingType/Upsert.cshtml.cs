using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PizzaPros.DataAccess.Data.Repository.IRepository;
using PizzaPros.Utility;

namespace PizzaPros.Pages.Admin.ToppingType
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
        public Models.ToppingType ToppingTypeObj { get; set; }


        public IActionResult OnGet(int? id)
        {
            ToppingTypeObj = new Models.ToppingType();
            if (id != null)
            {
                ToppingTypeObj = _unitOfWork.ToppingType.GetFirstOrDefault(u => u.Id == id);
                if (ToppingTypeObj == null)
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
            if (ToppingTypeObj.Id == 0)
            {
                _unitOfWork.ToppingType.Add(ToppingTypeObj);
            }
            else
            {
                _unitOfWork.ToppingType.Update(ToppingTypeObj);
            }
            _unitOfWork.Save();
            return RedirectToPage("./Index");
        }
    }
}
