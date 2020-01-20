using System;
using System.Collections.Generic;

namespace MyCoffee.Controllers
{
    public abstract class MyCoffeeConsole
    {
        protected string _summary;
        protected ConsoleStyle style;
        protected List<string> _menu;
        protected List<string> _menuDebug;
        public string defautlAskCommandMessage { get; set; }
        public string defaultAskKeyPressMessage { get; set; }

        public int tableWidth = 100;
        


        public MyCoffeeConsole()
        {
            style = new ConsoleStyle();
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

        protected void DisplayMainMenu(params List<string>[] lists)
        {
            Clear();
            DisplaySummary(_menu, _menuDebug);
            Echo("");
            DecisionTree(AskCommand(), true);
        }

        protected void DisplaySummary(params List<string>[] lists)
        {
            int index = 1;

            foreach (List<string> list in lists)
            {
                if (list == null ) { continue; }

                foreach (string item in list)
                {
                    style.Yellow($"{index}");
                    style.Gray(" - ");
                    style.White(item, true);
                    index++;
                }
                style.Gray(new string('-', 35), true);
            }
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

        public string PrintLine()
        {
            return (new string('-', tableWidth));
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
            }
            else
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
            string output = "";
            text = text.Length > width ? text.Substring(0, width - 3) + "..." : text;

            if (string.IsNullOrEmpty(text))
            {
                return new string(' ', width);
            }
            else
            {
                output = text.PadRight(width - (width - text.Length) / 2);
                if (center)
                {
                    return output.PadLeft(width);
                }
                else
                {
                    return output.PadRight(width);
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


        public class ConsoleStyle
        {
            public void PrintColor(ConsoleColor color, string text, bool backline = true)
            {
                SelectColor(color);

                if (backline)
                {
                    Console.WriteLine(text);
                    SelectColor(ConsoleColor.White);
                }
                 else
                {
                    Console.Write(text);
                }
            }

            public void SelectColor(ConsoleColor color)
            {
                Console.ForegroundColor = color;
            }

            public void Color(ConsoleColor color, string text = null, bool backline = false)
            {
                if (!string.IsNullOrEmpty(text))
                {
                    PrintColor(color, text, backline);
                }
                else
                {
                    SelectColor(color);
                }
            }

            public void Red(string text = null, bool backline = false)
            {
                Color(ConsoleColor.Red, text, backline);
            }

            public void Yellow(string text = null, bool backline = false)
            {
                Color(ConsoleColor.Yellow, text, backline);
            }

            public void Cyan(string text = null, bool backline = false)
            {
                Color(ConsoleColor.Cyan, text, backline);
            }
            public void Gray(string text = null, bool backline = false)
            {
                Color(ConsoleColor.Gray, text, backline);
            }
            public void White(string text = null, bool backline = false)
            {
                Color(ConsoleColor.White, text, backline);
            }
            public void Magenta(string text = null, bool backline = false)
            {
                Color(ConsoleColor.Magenta, text, backline);
            }

            public void Green(string text = null, bool backline = false)
            {
                Color(ConsoleColor.Green, text, backline);
            }
        }

        abstract protected void DecisionTree(string Input, bool DisplayMenu);
    }
}
