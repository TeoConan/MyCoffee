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
                    ListAllProducts();
                    ReturnToSummary();
                    break;

                case "3":
                    //MakeOrder();
                    break;

                case "4":
                    //SortShortDates();
                    break;

                case "5":
                    ListProductByCategory();
                    ReturnToSummary();
                    break;

                case "6":
                    break;

                case "7":
                    test();
                    break;
                case "8":
                    DebugShowProduct();
                    ReturnToSummary();
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
            Echo("8) Afficher le produit 5");
        }

        public void ReturnToSummary()
        {
            Clear();
            Summary();
            WaitForCommand();
        }

        public void ListAllProducts()
        {
            var lisAllProducts = new ListAllProducts();
        }

        public void ListProductByCategory()
        {
            var listByCategory = new ListByCategory();
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

        public void DebugShowProduct()
        {
            var productViewer = new ProductViewer(5);
        }
    }
}
