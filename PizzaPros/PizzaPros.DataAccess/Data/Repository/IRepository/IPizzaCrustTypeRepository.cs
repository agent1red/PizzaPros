using Microsoft.AspNetCore.Mvc.Rendering;
using PizzaPros.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaPros.DataAccess.Data.Repository.IRepository
{
    public interface IPizzaCrustTypeRepository : IRepository<PizzaCrustType>
    {
        IEnumerable<SelectListItem> GetPizzaCrustTypeListForDropDown();
      

        void Update(PizzaCrustType pizzaCrustType);
    }
}
