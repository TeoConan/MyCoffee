using System;
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
            var mockProductRepository = new MockProductRepository();

            var products = mockProductRepository.getAllProducts();
            Echo("Liste des produits : \n");

            foreach (Product product in products)
            {
                Echo(product.Name + "\n");
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
