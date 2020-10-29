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
        IPizzaCrustFlavorRepository PizzaCrustFlavor { get; }
        IPizzaSizeRepository PizzaSize { get; }
        IPizzaTypeRepository PizzaType { get; }
        IApplicationUserRepository ApplicationUser { get; }
        IShoppingCartRepository ShoppingCart { get; }

        void Save();
    }
}
