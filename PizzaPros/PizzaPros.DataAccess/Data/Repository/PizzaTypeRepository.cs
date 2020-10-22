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

        public IEnumerable<SelectListItem> GetToppingListForDropDown()
        {
            return _db.ToppingType.Select(i => new SelectListItem()
            {
                Text = i.Name,
                Value = i.Id.ToString()
            });
        }

        public void Update(PizzaType pizzaType)
        {
            var pizzaTypeFromDb = _db.PizzaType.FirstOrDefault(p => p.Id == pizzaType.Id);

            pizzaTypeFromDb.Name = pizzaType.Name;
            pizzaTypeFromDb.Description = pizzaType.Description;
            pizzaTypeFromDb.Price = pizzaType.Price;
            pizzaTypeFromDb.ToppingOneId = pizzaType.ToppingOneId;
            pizzaTypeFromDb.ToppingTwoId = pizzaType.ToppingTwoId;
            pizzaTypeFromDb.ToppingThreeId = pizzaType.ToppingThreeId;
            pizzaTypeFromDb.ToppingFourId = pizzaType.ToppingFourId;
            pizzaTypeFromDb.ToppingFiveId = pizzaType.ToppingFiveId;
            pizzaTypeFromDb.ToppingSixId = pizzaType.ToppingSixId;
            pizzaTypeFromDb.ToppingSevenId = pizzaType.ToppingSevenId;
            pizzaTypeFromDb.ToppingEightId = pizzaType.ToppingEightId;
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
