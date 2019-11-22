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
            Clear();
            Summary();
            WaitForCommand();
            
        }

        public void Summary()
        {
            Echo("1) Sandwich");
            Echo("2) Viennoiserie\n");
        }

        public void WaitForCommand()
        {
            Echo("Veuillez choisir la catégorie : ");
            Input = Console.ReadLine();

            switch (Input)
            {
                case "1":
                    ListProducts(2, "Sandwiches");
                    WaitForKeyPress();
                    break;
                case "2":
                    ListProducts(1, "Viennoiseries");
                    WaitForKeyPress();
                    break;
                default:
                    WaitForCommand();
                    break;

            }
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
            Console.WriteLine("Appuyez sur une touche pour revenir au menu.\n");

            Console.ReadKey();
            Clear();
            Summary();
            WaitForCommand();
        }
    }
}
