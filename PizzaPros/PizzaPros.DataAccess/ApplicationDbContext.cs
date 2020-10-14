using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PizzaPros.Models;

namespace PizzaPros.DataAccess
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }


        public DbSet<Category> Category { get; set; }
        public DbSet<Toppings> Toppings { get; set; }
        public DbSet<ToppingType> ToppingType { get; set; }



    }
}
