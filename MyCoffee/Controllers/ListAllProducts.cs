using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using MyCoffee.Data;
using MyCoffee.Entities;

namespace MyCoffee.Controllers
{
    public class ListAllProducts : MyCoffeeConsole
    {
        //Naming convention ok

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

            PrintTableHeader(true, "Id", "CategoryId", "Name", "Description", "Price", "Stock", "Date d'expiration");
            foreach (Product aProduct in listProduct)
            {
                StocksRepository stocksRepository = new StocksRepository();
                var stockOfProduct = stocksRepository.GetStockByProductId(aProduct.Id);
                var dateTime = stocksRepository.ConvertTimeStampToStringDate(stockOfProduct.Expiry);

                PrintLineCells(true, $"{aProduct.Id}", $"{aProduct.CategoryId}", aProduct.Name, aProduct.Description, $"{aProduct.Price}", $"{stockOfProduct.Quantity}", dateTime);
            }
            Echo(PrintLine());
        }

        

        public void WaitForKeyPress()
        {
            Echo("Appuyez sur une touche pour revenir au menu.\n");

            Console.ReadKey();
            Clear();
        }

        protected override void DecisionTree(string input, bool displayMenu)
        {
        }
    }
}
