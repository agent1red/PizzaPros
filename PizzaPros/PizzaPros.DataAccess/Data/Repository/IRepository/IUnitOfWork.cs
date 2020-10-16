using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaPros.DataAccess.Data.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoryRepository Category { get; }
        IToppingsRepository Toppings { get; }
        IToppingTypeRepository ToppingType { get; }
        IPizzaCrustTypeRepository PizzaCrustType { get; }

        void Save();
    }
}
