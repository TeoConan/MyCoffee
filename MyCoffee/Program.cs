using MyCoffee.Data;
using MyCoffee.Entities;
using System;
using MyCoffee.Data;

namespace MyCoffee
{
    class Program
    {
        static void Main(string[] args)
        {
            TestAddObject();
            //var console = new UserConsole();
        }

        public static void TestAddObject()
        {
            Console.WriteLine("Try to add a new entry in database SQLite");

            using (var dboContext = new MCDBContext())
            {
                var product = new Product() {
                    Name = "Panini Noccialata",
                    Price = 23.05f,
                    Description = "Lorem ipsum dolor sit amet",
                    CategoryId = 0
                };

                dboContext.Product.Add(product);
                dboContext.SaveChanges();
            }

            Console.WriteLine("End");
        }
    }
}
