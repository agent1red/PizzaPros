using Microsoft.AspNetCore.Mvc.Rendering;
using PizzaPros.DataAccess.Data.Repository.IRepository;
using PizzaPros.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PizzaPros.DataAccess.Data.Repository
{
    public class ToppingTypeRepository : Repository<ToppingType>, IToppingTypeRepository
    {
        private readonly ApplicationDbContext _db;

        public ToppingTypeRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetToppingTypeListForDropDown()
        {
            return _db.ToppingType.Select(i => new SelectListItem()
            {
                Text = i.Name,
                Value = i.Id.ToString()
            });
        }

        public void Update(ToppingType toppingType)
        {
            var objFromDb = _db.ToppingType.FirstOrDefault(s => s.Id == toppingType.Id);

            objFromDb.Name = toppingType.Name;
            

            _db.SaveChanges();
        }
    }
}
