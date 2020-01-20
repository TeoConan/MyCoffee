using System;
using System.Collections.Generic;

namespace MyCoffee.Controllers
{
    public abstract class MyCoffeeConsole
    {
        protected string _summary;
        public string defautlAskCommandMessage { get; set; }
        public string defaultAskKeyPressMessage { get; set; }
        public int tableWidth = 80;

        public string PrintLine()
        {
            return(new string('-', tableWidth));
        }

        public string PrintRow(bool alignText, params string[] columns)
        {
            int width = (tableWidth - columns.Length) / columns.Length;
            string row = "|";

            if (alignText)
            {
                foreach (string column in columns)
                {
                    row += AlignText(true, column, width) + "|";
                }
            } else
            {
                foreach (string column in columns)
                {
                    row += (column, width) + "|";
                }
            }
            

            return row;
        }

        public string AlignText(bool center, string text, int width)
        {
            text = text.Length > width ? text.Substring(0, width - 3) + "..." : text;

            if (string.IsNullOrEmpty(text))
            {
                return new string(' ', width);
            }
            else
            {
                if (center)
                {
                    return text.PadRight(width - (width - text.Length) / 2).PadLeft(width);
                } else
                {
                    return text.PadRight(width - (width - text.Length) / 2).PadRight(width);
                }
                
            }
        }

        public string PrintTableHeader(bool print = true, params string[] colums)
        {
            string output = "";
            output += (PrintLine() + "\n");
            output += PrintRow(true, colums) + "\n";
            output += (PrintLine());

            if (print)
            {
                Console.WriteLine(output);
            }

            return output;
        }

        public string PrintLineCells(bool print = true, params string[] cells)
        {
            int width = (tableWidth - cells.Length) / cells.Length;
            string row = "|";
            foreach (string column in cells)
            {
                row += AlignText(false, column, width) + "|";
            }

            if (print)
            {
                Console.WriteLine(row);
            }

            return row;
        }

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

        protected virtual void DisplayMainMenu()
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

                switch (userInput.ToLower())
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
