using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCoffee.Entities;
using MyCoffee.Data;

namespace MyCoffee.Controllers
{
    class MainMenu : MyCoffeeConsole
    {
        public string Input { get; set; }

        public MainMenu()
        {
            Welcome();
            Summary();
            WaitForCommand();

        }

        public void Welcome()
        {
            Echo("Bienvenue dans MyCoffee");
        }

        public void WaitForCommand()
        {
            Echo("Veuillez entrer une commande");
            Input = Console.ReadLine();

            switch (Input)
            {
                case "0":
                    return;
                    break;

                case "1":
                    Clear();
                    Summary();
                    WaitForCommand();
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
                    ListProductByCategory();
                    break;

                case "6":
                    break;

                case "7":
                    test();
                    break;

                default:
                    WaitForCommand();
                    break;
            }
        }

        public void Summary()
        {
            Echo("1) Documentation");
            Echo("2) Lister les produits");
            Echo("3) Passer une commande");
            Echo("4) Voir les dates courtes");
            Echo("5) Lister par catégorie");
            Echo("6) Quitter");
            Echo("7) Test");
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

        public void ListProductByCategory()
        {
            var listByCategory = new ListByCategory();
        }

        //TODO DISPLACE
        public void WaitForCommandListByCategory()
        {
            //Clear();
            //Echo("1) Sandwich");
            //Echo("2) Viennoiserie\n");

            //Echo("Veuillez entrer une commande");
            //Input = Console.ReadLine();

            //switch (Input)
            //{
            //    case "1":
            //        ListByCategory(2, "Sandwiches");
            //        break;
            //    case "2":
            //        ListByCategory(1, "Viennoiseries");
            //        break;
            //    default:
            //        WaitForCommandListByCategory();
            //        break;

            //}
        }

        //TODO Displace
        public void ListByCategory(int categoryId, string category)
        {
            //Console.Clear();
            //var mockProductRepository = new MockProductRepository();

            //var products = mockProductRepository.getProductsByCategory(categoryId);
            //Console.WriteLine("Liste des produits de la catégorie : " + category + "\n" );

            //foreach (Product product in products)
            //{
            //    Console.WriteLine(product.Name + "\n");
            //}

            //ReturnToWaitingCommand();
        }

        //TODO Displace
        public void ReturnToWaitingCommand()
        {
            //Console.WriteLine("Appuyez sur une touche pour revenir au menu.\n");

            //Console.ReadKey();
            //Summary();
            //WaitForCommand();
        }


        private bool AskYesNo()
        {
            bool correctAnswer = false;
            bool answer = false;

            do
            {
                var Input = Console.ReadLine();

                if (Input.Equals("oui")
                    || Input.Equals("o")
                    || Input.Equals("y")
                    || Input.Equals("yes"))
                {
                    correctAnswer = true;
                    answer = true;
                }

                if (Input.Equals("non"))
                {
                    correctAnswer = true;
                    answer = false;
                }


            } while (!correctAnswer);

            return answer;
        }

        private void init()
        {

        }

        private void test()
        {
            var test = new Test();
        }
    }
}
