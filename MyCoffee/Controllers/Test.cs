using MyCoffee.Data;
using MyCoffee.Entities;
using System;
namespace MyCoffee.Controllers
{
    public class Test
    {
        public Test()
        {
            
        }

        public void AddProduct()
        {
            Console.WriteLine("Try to add a new entry in database SQLite");

            using (var dboContext = new MCDBContext())
            {
                var product = new Product()
                {
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

        public void GetProducts()
        {
            Console.WriteLine("Get products in database");

            using (var dboContext = new MCDBContext())
            {
                var listProduct = dboContext.Product;

                foreach (Product aProduct in listProduct)
                {
                    Console.WriteLine($"{aProduct.Id} | {aProduct.Name} | {aProduct.Price}");
                }
            }

            Console.WriteLine("End");

        }
    }
}
