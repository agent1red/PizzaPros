using Microsoft.AspNetCore.Mvc.Rendering;
using PizzaPros.DataAccess.Data.Repository.IRepository;
using PizzaPros.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PizzaPros.DataAccess.Data.Repository
{
    public class PizzaSizeRepository : Repository<PizzaSize>, IPizzaSizeRepository
    {
        private readonly ApplicationDbContext _db;

        public PizzaSizeRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetPizzaSizeListForDropDown()
        {
            return _db.PizzaSize.Select(i => new SelectListItem()
            {
                //value of list uses int for placement
                Text = i.Size,
                Value = i.Id.ToString(),
            });
        }

        public void Update(PizzaSize pizzaSize)
        {
            var objFromDb = _db.PizzaSize.FirstOrDefault(s => s.Id == pizzaSize.Id);

            objFromDb.Size = pizzaSize.Size;
            
            

            _db.SaveChanges();
        }
    }
}
