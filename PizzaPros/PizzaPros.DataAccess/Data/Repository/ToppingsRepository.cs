using Microsoft.AspNetCore.Mvc.Rendering;
using PizzaPros.DataAccess.Data.Repository.IRepository;
using PizzaPros.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PizzaPros.DataAccess.Data.Repository
{
    public class ToppingsRepository : Repository<Toppings>, IToppingsRepository
    {
        private readonly ApplicationDbContext _db;

        public ToppingsRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

     

        public void Update(Toppings toppings)
        {
            var toppingsFromDb = _db.Toppings.FirstOrDefault(t => t.Id == toppings.Id);

            toppingsFromDb.Name = toppings.Name;
            toppingsFromDb.ToppingTypeId = toppings.ToppingTypeId;
            _db.SaveChanges();
        }
    }
}
