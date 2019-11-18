using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCoffee.Data
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
            echo("Bienvenue dans MyCoffe");
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
                    
                    break;

                case "3":
                    Documentation();
                    break;

                case "4":
                    
                    break;

                case "5":
                    break;

                default:
                    WaitCommand();
                    break;
            }
        }

        public void Summary()
        {
            echo("0) Quitter");
            echo("1) Sommaire des commandes");
            echo("2) ");
            echo("3) ");
            echo("4) ");
            echo("5) ");
        }

        public void Documentation()
        {

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
