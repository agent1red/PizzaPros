using Microsoft.AspNetCore.Mvc.Rendering;
using PizzaPros.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaPros.DataAccess.Data.Repository.IRepository
{
    public interface IToppingTypeRepository : IRepository<ToppingType>
    {
        IEnumerable<SelectListItem> GetToppingTypeListForDropDown();

        void Update(ToppingType toppingType);
    }
}
