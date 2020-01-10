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
            Console.WriteLine("Chargement...");
            ProductsRepository productsRepository = new ProductsRepository();
            var listProduct = productsRepository.GetAllProducts();

            Clear();
            Echo("Liste des produits : \n");
            Echo("Id | CategoryId | Name | Description | Price | Create | Update | Delete");

            foreach (Product aProduct in listProduct)
            {
                Console.WriteLine($"{aProduct.Id} | {aProduct.CategoryId} | {aProduct.Name} | {aProduct.Description} | {aProduct.Price} | {aProduct.TimeCreate} |  {aProduct.TimeUpdate} | {aProduct.TimeDelete}");
            }
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
