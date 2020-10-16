using Microsoft.AspNetCore.Mvc.Rendering;
using PizzaPros.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaPros.DataAccess.Data.Repository.IRepository
{
    public interface IPizzaCrustFlavorRepository : IRepository<PizzaCrustFlavor>
    {
        IEnumerable<SelectListItem> GetPizzaCrustFlavorListForDropDown();
      

        void Update(PizzaCrustFlavor pizzaCrustFlavor);
    }
}
