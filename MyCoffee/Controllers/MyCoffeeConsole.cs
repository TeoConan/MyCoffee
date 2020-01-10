using System;
using System.Collections.Generic;

namespace MyCoffee.Controllers
{
    public abstract class MyCoffeeConsole
    {
        protected string _summary;
        public string defautlAskCommandMessage { get; set; }
        public string defaultAskKeyPressMessage { get; set; }

        public MyCoffeeConsole()
        {
            defautlAskCommandMessage = "Veuillez entrer une commande";
            defaultAskKeyPressMessage = "Appuyez sur une touche.";
        }

        public void Echo(string text)
        {
            Console.WriteLine(text);
        }

        public void Clear()
        {
            Console.Clear();
        }

        protected void DisplayMainMenu()
        {
            Clear();
            DisplaySummary();
            DecisionTree(AskCommand(), true);
        }

        protected void DisplaySummary()
        {
            Echo(_summary);
        }

        // Command & keys
        protected string AskCommand(string message)
        {
            Echo(message);
            return(Console.ReadLine());

        }

        protected string AskCommand()
        {
            return AskCommand(defautlAskCommandMessage);
        }

        // Le return de AskKeyPress peut être comparé à un string
        protected ConsoleKeyInfo AskKeyPress(string message)
        {
            Console.WriteLine(message);

            return(Console.ReadKey());
        }

        protected ConsoleKeyInfo AskKeyPress()
        {
            return AskKeyPress(defaultAskKeyPressMessage);
        }

        protected bool AskYesNo()
        {
            bool result;
            string userInput;

            while (true)
            {

                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "o":
                    case "y":
                    case "yes":
                    case "oui":
                    case "ok":
                        return true;
                        break;

                    case "n":
                    case "no":
                    case "non":
                    case "nope":
                    case "ko":
                    case "pshiit":
                    case "salade":
                    case "salad":
                        return false;
                        break;

                    default:
                        Echo("C'était une question oui/non.");
                        break;

                }
            }
        }

        abstract protected void DecisionTree(string Input, bool DisplayMenu);
    }
}
