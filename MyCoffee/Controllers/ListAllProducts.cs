using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using MyCoffee.Data;
using MyCoffee.Entities;

namespace MyCoffee.Controllers
{
    public class ListAllProducts : MyCoffeeConsole
    {
        public ListAllProducts()
        {
            Clear();
            DisplayProducts();
            WaitForKeyPress();
        }

        public void DisplayProducts()
        {

            var listProduct = GetProducts();

            Echo("Liste des produits : \n");

            foreach (Product aProduct in listProduct)
            {
                Console.WriteLine($"{aProduct.Id} | {aProduct.Name} | {aProduct.Price}");
            }
            
        }

        public List<Product> GetProducts()
        {
            List<Product> listProducts = new List<Product>();
            Console.WriteLine("Get products in database");

            using (var dboContext = new MCDBContext())
            {
                var DbList = dboContext.Product;

                foreach (Product product in DbList)
                {
                    listProducts.Add(product);
                }
            }

            return listProducts;

        }

        public void WaitForKeyPress()
        {
            Echo("Appuyez sur une touche pour revenir au menu.\n");

            Console.ReadKey();
            Clear();
        }

        protected override void DecisionTree(string Input, bool DisplayMenu)
        {
        }
    }
}
