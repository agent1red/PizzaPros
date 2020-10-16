using Microsoft.AspNetCore.Mvc.Rendering;
using PizzaPros.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaPros.DataAccess.Data.Repository.IRepository
{
    public interface IPizzaTypeRepository : IRepository<PizzaType>
    {
       

        void Update(PizzaType pizzaType);
    }
}
