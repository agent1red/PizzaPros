using PizzaPros.DataAccess.Data.Repository.IRepository;
using PizzaPros.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaPros.DataAccess.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Category = new CategoryRepository(_db);
            Toppings = new ToppingsRepository(_db);
            ToppingType = new ToppingTypeRepository(_db);
            PizzaCrustType = new PizzaCrustTypeRepository(_db);
            PizzaCrustFlavor = new PizzaCrustFlavorRepository(_db);
            PizzaSize = new PizzaSizeRepository(_db);
            PizzaType = new PizzaTypeRepository(_db);
            ApplicationUser = new ApplicationUserRepository(_db);
            ShoppingCart = new ShoppingCartRepository(_db);
            OrderHeader = new OrderHeaderRepository(_db);
            OrderDetails = new OrderDetailsRepository(_db);
        }

        // DO NOT set outside of this 
        public ICategoryRepository Category { get; private set; } 
        public IToppingsRepository Toppings { get; private set; } 
        public IToppingTypeRepository ToppingType { get; private set; }
        public IPizzaCrustTypeRepository PizzaCrustType { get; private set; }
        public IPizzaCrustFlavorRepository PizzaCrustFlavor { get; private set; }
        public IPizzaSizeRepository PizzaSize { get; private set; }
        public IPizzaTypeRepository PizzaType { get; private set; }
        public IApplicationUserRepository ApplicationUser { get; private set; }
        public IShoppingCartRepository ShoppingCart { get; private set; }
         public IOrderHeaderRepository OrderHeader { get; private set; }
        public IOrderDetailsRepository OrderDetails { get; private set; }

        //Implement Save()
        public void Dispose()
        {
            _db.Dispose();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
