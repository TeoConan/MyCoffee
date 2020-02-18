using System;
using System.Collections.Generic;
using MyCoffee.Data;
using MyCoffee.Entities;

namespace MyCoffee.Controllers
{
    public class ListByCategory : MyCoffeeConsole
    {
        //Naming convention ok

        public string Input { get; set; }

        public ListByCategory()
        {
            Menu = new List<string>();
            Menu.Add("Sandwich");
            Menu.Add("Viennoiseries");
            Menu.Add("Salades");
            Menu.Add("Boissons");
            Menu.Add("Snacks");
            Menu.Add("Lunch boxes");
            Menu.Add("[q]uitter");

            DisplayMainMenu();
        }

        public void ListProducts(int categoryId, string category)
        {
            Clear();
            var mockProductRepository = new MockProductRepository();

            var products = mockProductRepository.GetProductsByCategory(categoryId);
            Console.WriteLine("Liste des produits de la catégorie : " + category + "\n");

            var productBrowser = new ProductBrowser();
            productBrowser.BrowseListOfProducts(products);

        }

        public void WaitForKeyPress()
        {
            AskKeyPress();
        }

        protected override void DecisionTree(string input, bool displayMenu)
        {
            switch (input.ToLower())
            {
                case "q":
                    return;
                case "1":
                    ListProducts(2, "Sandwiches");
                    break;
                case "2":
                    ListProducts(1, "Viennoiseries");
                    break;
                case "3":
                    ListProducts(3, "Salades");
                    break;
                case "4":
                    ListProducts(4, "Boissons");
                    break;
                case "5":
                    ListProducts(5, "Snacks");
                    break;
                case "6":
                    ListProducts(6, "Lunch boxes");
                    break;
                default:
                    DecisionTree(AskCommand(), displayMenu);
                    break;
            }

            if (displayMenu)
            {
                DisplayMainMenu();
            }
        }
    }
}
