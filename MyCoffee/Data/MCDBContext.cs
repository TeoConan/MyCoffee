using Microsoft.EntityFrameworkCore;
using MyCoffee.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyCoffee.Data
{
    class MCDBContext : DbContext
    {
        private string DBName { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            DBName = "mycoffee";

            optionsBuilder.UseSqlite("Data Source=" + DBName + ".db");
            //optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=mycoffee;Integrated Security=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Product
            var productBuilder = modelBuilder.Entity<Product>();
            productBuilder.HasKey(p => p.Id);
            productBuilder.Property(p => p.Name).IsRequired();
            productBuilder.Property(p => p.Description).IsRequired();
            productBuilder.Property(p => p.Price).IsRequired();
            productBuilder.Property(p => p.CategoryId).IsRequired();

        }

        public DbSet<Customer> Customer { get; set; }
        public DbSet<CustomerOrder> CustomerOrder { get; set; }
        public DbSet<OrderLine> OderLine { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Stock> Stock { get; set; }

    }
}
