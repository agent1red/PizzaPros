using Microsoft.AspNetCore.Mvc.Rendering;
using PizzaPros.DataAccess.Data.Repository.IRepository;
using PizzaPros.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PizzaPros.DataAccess.Data.Repository
{
    public class PizzaCrustTypeRepository : Repository<PizzaCrustType>, IPizzaCrustTypeRepository
    {
        private readonly ApplicationDbContext _db;

        public PizzaCrustTypeRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetPizzaCrustTypeListForDropDown()
        {
            return _db.PizzaCrustType.Select(i => new SelectListItem()
            {
                //value of list uses int for palcement
                Text = i.CrustType,
                Value = i.Id.ToString(),
            });
        }

        public void Update(PizzaCrustType pizzaCrustType)
        {
            var objFromDb = _db.PizzaCrustType.FirstOrDefault(s => s.Id == pizzaCrustType.Id);

            objFromDb.CrustType = pizzaCrustType.CrustType;
            objFromDb.CrustTypeDescription = pizzaCrustType.CrustTypeDescription;
            

            _db.SaveChanges();
        }
    }
}
