using Microsoft.EntityFrameworkCore;
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
        }
    }
}
