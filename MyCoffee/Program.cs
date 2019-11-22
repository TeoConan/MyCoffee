using MyCoffee.Data;
using MyCoffee.Entities;
using System;
using MyCoffee.Controllers;
using System.Linq;

namespace MyCoffee
{
    class Program
    {
        static void Main(string[] args)
        {
            //var console = new UserConsole();
            TestAddObject();
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

                var listProduct = dboContext.Product;

                foreach (Product aProduct in listProduct)
                Console.WriteLine($"{aProduct.Id} | {aProduct.Name} | {aProduct.Price}");

                dboContext.Product.Add(product);
                dboContext.SaveChanges();
            }

            Console.WriteLine("End");
        }
    }
}
