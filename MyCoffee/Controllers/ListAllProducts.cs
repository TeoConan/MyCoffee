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

            PrintTableHeader(true, "Id", "CategoryId", "Name", "Description", "Price");
            foreach (Product aProduct in listProduct)
            {
                PrintLineCells(true, $"{aProduct.Id}", $"{aProduct.CategoryId}", aProduct.Name, aProduct.Description, $"{aProduct.Price}");
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
