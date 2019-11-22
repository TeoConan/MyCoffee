using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCoffee.Data;
using MyCoffee.Entities;

namespace MyCoffee.Controllers
{
    class UserConsole
    {
        string input;

        public UserConsole()
        {
            Welcome();
            Summary();
            WaitCommand();

        }

        public void Welcome()
        {
            echo("Bienvenue dans MyCoffee");
        }

        public void WaitCommand()
        {
            echo("Veuillez entrer une commande");
            input = Console.ReadLine();

            switch (input)
            {
                case "0":
                    return;
                    break;

                case "1":
                    clear();
                    Summary();
                    WaitCommand();
                    break;

                case "2":
                    ListProduct();
                    break;

                case "3":
                    MakeOrder();
                    break;

                case "4":
                    SortShortDates();
                    break;

                case "5":
                    WaitCommandListByCategory();
                    break;

                case "6":
                    break;

                default:
                    WaitCommand();
                    break;
            }
        }

        public void Summary()
        {
            Console.Clear();
            echo("1) Documentation");
            echo("2) Lister les produits");
            echo("3) Passer une commande");
            echo("4) Voir les dates courtes");
            echo("5) Lister par catégorie");
            echo("6) Quitter");
        }

        public void SortShortDates()
        {

        }

        public void MakeOrder()
        {

        }

        public void ListProduct()
        {
            Console.Clear();
            var mockProductRepository = new MockProductRepository();

            var products = mockProductRepository.getAllProducts();
            Console.WriteLine("Liste des produits : \n");

            foreach (Product product in products)
            {
                Console.WriteLine(product.Name + "\n");
            }

            ReturnToWaitingCommand();
        }

        public void WaitCommandListByCategory()
        {
            Console.Clear();
            echo("1) Sandwich");
            echo("2) Viennoiserie\n");

            echo("Veuillez entrer une commande");
            input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    ListByCategory(2, "Sandwiches");
                    break;
                case "2":
                    ListByCategory(1, "Viennoiseries");
                    break;
                default:
                    WaitCommandListByCategory();
                    break;

            }
        }

        public void ListByCategory(int categoryId, string category)
        {
            Console.Clear();
            var mockProductRepository = new MockProductRepository();

            var products = mockProductRepository.getProductsByCategory(categoryId);
            Console.WriteLine("Liste des produits de la catégorie : " + category + "\n" );

            foreach (Product product in products)
            {
                Console.WriteLine(product.Name + "\n");
            }

            ReturnToWaitingCommand();
        }

        public void ReturnToWaitingCommand()
        {
            Console.WriteLine("Appuyez sur une touche pour revenir au menu.\n");

            Console.ReadKey();
            Summary();
            WaitCommand();
        }


        private bool AskYesNo()
        {
            bool correctAswer = false;
            bool aswer = false;

            do
            {
                var input = Console.ReadLine();

                if (input.Equals("oui")
                    || input.Equals("o")
                    || input.Equals("y")
                    || input.Equals("yes"))
                {
                    correctAswer = true;
                    aswer = true;
                }

                if (input.Equals("non"))
                {
                    correctAswer = true;
                    aswer = false;
                }


            } while (!correctAswer);

            return aswer;
        }

        private void init()
        {

        }

        private void test()
        {

        }

        private void clear()
        {
            Console.Clear();
        }

        private void echo(string txt)
        {
            Console.WriteLine(txt);
        }
    }
}
