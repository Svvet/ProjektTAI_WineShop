using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WineShop.Models;

namespace WineShop.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
    => options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=aspnet-WineShop-92FF87B7-65BE-45CE-9443-B4C22B1923E4;Trusted_Connection=True;MultipleActiveResultSets=true");
        public ApplicationDbContext() { }
        
        public DbSet<Wine> Wines { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Basket> Baskets { get; set; }
    }
}
