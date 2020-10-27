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
            
        }

        public ICategoryRepository Category { get; private set; } // DO NOT set outside of this 
        public IToppingsRepository Toppings { get; private set; } // DO NOT set outside of this 
        public IToppingTypeRepository ToppingType { get; private set; } // DO NOT set outside of this 
        public IPizzaCrustTypeRepository PizzaCrustType { get; private set; } // DO NOT set outside of this 
        public IPizzaCrustFlavorRepository PizzaCrustFlavor { get; private set; } // DO NOT set outside of this 
        public IPizzaSizeRepository PizzaSize { get; private set; } // DO NOT set outside of this 
        public IPizzaTypeRepository PizzaType { get; private set; } // DO NOT set outside of this 
        public IApplicationUserRepository ApplicationUser { get; private set; } // DO NOT set outside of this 

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
