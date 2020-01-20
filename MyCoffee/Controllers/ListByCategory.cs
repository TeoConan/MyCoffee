using System;
using MyCoffee.Data;
using MyCoffee.Entities;

namespace MyCoffee.Controllers
{
    public class ListByCategory : MyCoffeeConsole
    {
        public string Input { get; set; }

        public ListByCategory()
        {
            _summary = "";
            _summary += "1) Sandwich\n";
            _summary += "2) Viennoiserie\n";
            _summary += "3) Salades\n";
            _summary += "4) Boissons\n";
            _summary += "5) Snacks\n";
            _summary += "6) Lunch boxes\n";
            _summary += "\n[q]uitter\n";


            DisplayMainMenu();
        }

        public void ListProducts(int categoryId, string category)
        {
            Clear();
            var mockProductRepository = new MockProductRepository();

            var products = mockProductRepository.getProductsByCategory(categoryId);
            Console.WriteLine("Liste des produits de la catégorie : " + category + "\n");

            var productBrowser = new ProductBrowser();
            productBrowser.BrowseListOfProducts(products);

        }

        public void WaitForKeyPress()
        {
            AskKeyPress();
        }

        protected override void DecisionTree(string Input, bool DisplayMenu)
        {
            switch (Input.ToLower())
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
                    DecisionTree(AskCommand(), DisplayMenu);
                    break;
            }

            if (DisplayMenu)
            {
                DisplayMainMenu();
            }
        }
    }
}
