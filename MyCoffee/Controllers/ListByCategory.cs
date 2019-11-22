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
            _summary += "0) Menu principal\n";
            _summary += "1) Sandwich\n";
            _summary += "2) Viennoiserie\n";

            DisplayMainMenu();
        }

        public void ListProducts(int categoryId, string category)
        {
            Clear();
            var mockProductRepository = new MockProductRepository();

            var products = mockProductRepository.getProductsByCategory(categoryId);
            Console.WriteLine("Liste des produits de la catégorie : " + category + "\n");

            foreach (Product product in products)
            {
                Console.WriteLine(product.Name + "\n");
            }
        }

        public void WaitForKeyPress()
        {
            AskKeyPress();
            DisplayMainMenu();
        }

        protected override void DecisionTree(string Input, bool DisplayMenu)
        {
            switch (Input)
            {
                case "0":
                    return;
                    break;
                case "1":
                    ListProducts(2, "Sandwiches");
                    WaitForKeyPress();
                    break;
                case "2":
                    ListProducts(1, "Viennoiseries");
                    WaitForKeyPress();
                    break;
                case "3":
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
