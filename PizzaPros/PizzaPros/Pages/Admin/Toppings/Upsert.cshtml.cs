using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PizzaPros.DataAccess.Data.Repository.IRepository;
using PizzaPros.Models.ViewModels;

namespace PizzaPros.Pages.Admin.Toppings
{
    public class UpsertModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;


        public UpsertModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [BindProperty]
        public ToppingsVM ToppingsItemObj { get; set; }

        //populate the viewmodel dropdown
        public IActionResult OnGet(int? id)
        {

            ToppingsItemObj = new ToppingsVM
            {
                ToppingTypeList = _unitOfWork.ToppingType.GetToppingTypeListForDropDown(),

                Toppings = new Models.Toppings()
            };
            if (id != null)
            {
                ToppingsItemObj.Toppings = _unitOfWork.Toppings.GetFirstOrDefault(u => u.Id == id);
                if (ToppingsItemObj == null)
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
                ToppingsItemObj = new ToppingsVM
                {
                    ToppingTypeList = _unitOfWork.ToppingType.GetToppingTypeListForDropDown(),
                    Toppings = new Models.Toppings()
                };
                return Page();
            }
            if (ToppingsItemObj.Toppings.Id == 0)
            {
                _unitOfWork.Toppings.Add(ToppingsItemObj.Toppings);
            }
            else
            {

                _unitOfWork.Toppings.Update(ToppingsItemObj.Toppings);
            }
             _unitOfWork.Save();
            return RedirectToPage("./Index");
        }
    }
}

