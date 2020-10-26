using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PizzaPros.DataAccess.Data.Repository.IRepository;
using PizzaPros.Models;

namespace PizzaPros.Pages.Customer.Home
{
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public IndexModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<PizzaType> PizzaTypeList { get; set; }
        public IEnumerable<Category> CategoryList { get; set; }
        public IEnumerable<ToppingType> ToppingTypeList { get; set; }
        public void OnGet()
        {
            PizzaTypeList = _unitOfWork.PizzaType
                .GetAll(null, q => q.OrderBy(c => c.PizzaSize.Size), "Category,ToppingType,PizzaCrustType,PizzaCrustFlavor,PizzaSize");
            CategoryList = _unitOfWork.Category.GetAll(null, q => q.OrderBy(c => c.DisplayOrder), null);
            ToppingTypeList = _unitOfWork.ToppingType.GetAll(null, q => q.OrderBy(c => c.Id), null);
        }
    }
}
