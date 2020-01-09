using MyCoffee.Data;
using MyCoffee.Entities;
using System;
namespace MyCoffee.Controllers
{
    public class Test
    {
        public Test()
        {
            //AddProduct(new Product { Id = 1, CategoryId = 2, Name = "Panini Chelou", Description = "Contenu étrange de sucré-salé", Price = 5 });
            GetProducts();
        }

        public void AddProduct(Product product)
        {
            Console.WriteLine("Try to add a new entry in database SQLite");

            using (var dboContext = new MCDBContext())
            {
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
            Console.ReadLine();

        }
    }
}
