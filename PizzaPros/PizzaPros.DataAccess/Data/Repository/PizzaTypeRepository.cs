using Microsoft.AspNetCore.Mvc.Rendering;
using PizzaPros.DataAccess.Data.Repository.IRepository;
using PizzaPros.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PizzaPros.DataAccess.Data.Repository
{
    public class PizzaTypeRepository : Repository<PizzaType>, IPizzaTypeRepository
    {
        private readonly ApplicationDbContext _db;

        public PizzaTypeRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

     

        public void Update(PizzaType pizzaType)
        {
            var pizzaTypeFromDb = _db.PizzaType.FirstOrDefault(p => p.Id == pizzaType.Id);

            pizzaTypeFromDb.Name = pizzaType.Name;
            pizzaTypeFromDb.Description = pizzaType.Description;
            pizzaTypeFromDb.Price = pizzaType.Price;
            pizzaTypeFromDb.ToppingOne = pizzaType.ToppingOne;
            pizzaTypeFromDb.ToppingTwo = pizzaType.ToppingTwo;
            pizzaTypeFromDb.ToppingThree = pizzaType.ToppingThree;
            pizzaTypeFromDb.ToppingFour = pizzaType.ToppingFour;
            pizzaTypeFromDb.ToppingFive = pizzaType.ToppingFive;
            pizzaTypeFromDb.ToppingSix = pizzaType.ToppingSix;
            pizzaTypeFromDb.ToppingSeven = pizzaType.ToppingSeven;
            pizzaTypeFromDb.ToppingEight = pizzaType.ToppingEight;
            pizzaTypeFromDb.CategoryId = pizzaType.CategoryId;
            pizzaTypeFromDb.ToppingTypeId = pizzaType.ToppingTypeId;
            pizzaTypeFromDb.PizzaCrustTypeId = pizzaType.PizzaCrustTypeId;
            pizzaTypeFromDb.PizzaCrustFlavorId = pizzaType.PizzaCrustFlavorId;
            pizzaTypeFromDb.PizzaSizeId = pizzaType.PizzaSizeId;

            if (pizzaType.Image != null)
            {
                pizzaTypeFromDb.Image = pizzaType.Image;
            }
            
            _db.SaveChanges();
        }
    }
}
