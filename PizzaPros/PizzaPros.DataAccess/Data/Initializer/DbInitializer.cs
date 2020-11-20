using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PizzaPros.Models;
using PizzaPros.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PizzaPros.DataAccess.Data.Initializer
{
    public class DbInitializer : IDbInitializer
    {

        private readonly ApplicationDbContext _db;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DbInitializer(ApplicationDbContext db, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _roleManager = roleManager;
            _userManager = userManager;
        }


        public void Initialize()
        {
            try
            {
                if (_db.Database.GetPendingMigrations().Count() > 0)
                {
                    _db.Database.Migrate();
                }
            }
            catch (Exception ex)
            {
            }

            if (_db.Roles.Any(r => r.Name == SD.ManagerRole)) return;

            _roleManager.CreateAsync(new IdentityRole(SD.ManagerRole)).GetAwaiter().GetResult();
            _roleManager.CreateAsync(new IdentityRole(SD.FrontDeskRole)).GetAwaiter().GetResult();
            _roleManager.CreateAsync(new IdentityRole(SD.PizzaMakerRole)).GetAwaiter().GetResult();
            _roleManager.CreateAsync(new IdentityRole(SD.DeliverDriverRole)).GetAwaiter().GetResult();
            _roleManager.CreateAsync(new IdentityRole(SD.CustomerRole)).GetAwaiter().GetResult();


            _userManager.CreateAsync(new ApplicationUser
            {
                UserName = "admin@gmail.com",
                Email = "admin@gmail.com",
                EmailConfirmed = true,
                FirstName = "Kevin",
                LastName = "Hudson",
                PhoneNumber = "4253863342"
            }, "Admin123*").GetAwaiter().GetResult();

            ApplicationUser user = _db.ApplicationUser.Where
                (u => u.Email == "admin@gmail.com").FirstOrDefault();

            _userManager.AddToRoleAsync(user, SD.ManagerRole).GetAwaiter().GetResult();
        }
    }
}
