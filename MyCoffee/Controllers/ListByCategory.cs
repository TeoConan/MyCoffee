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
            Echo("2) Viennoiserie");
            Echo("3) Retour au menu principal");

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
                case "3":
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
            Echo("Liste des produits de la catégorie : " + category + "\n");

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
            Summary();
            WaitForCommand();
        }
    }
}
