using Microsoft.AspNetCore.Mvc.Rendering;
using PizzaPros.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaPros.DataAccess.Data.Repository.IRepository
{
    public interface IPizzaTypeRepository : IRepository<PizzaType>
    {

        IEnumerable<SelectListItem> GetToppingListForDropDown();
        void Update(PizzaType pizzaType);
    }
}
