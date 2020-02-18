using System;
using System.Collections.Generic;

namespace MyCoffee.Controllers
{
    public abstract class MyCoffeeConsole
    {
        //Naming convention ok

        protected string Summary;
        protected ConsoleStyle Style;
        protected List<string> Menu;
        protected List<string> MenuDebug;
        public string DefautlAskCommandMessage { get; set; }
        public string DefaultAskKeyPressMessage { get; set; }

        public int TableWidth = 100;
        


        public MyCoffeeConsole()
        {
            Style = new ConsoleStyle();
            DefautlAskCommandMessage = "Veuillez entrer une commande";
            DefaultAskKeyPressMessage = "Appuyez sur une touche.";
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
            DisplaySummary(Menu, MenuDebug);
            Echo("");
            DecisionTree(AskCommand(), true);
        }

        protected void DisplaySummary(params List<string>[] lists)
        {
            int index = 1;

            foreach (List<string> list in lists)
            {
                if (list == null || list.Count == 0 ) { continue; }

                foreach (string item in list)
                {
                    Style.Yellow($"{index}");
                    Style.Gray(" - ");
                    Style.White(item, true);
                    index++;
                }
                Style.Gray(new string('-', 35), true);
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
            return AskCommand(DefautlAskCommandMessage);
        }

        // Le return de AskKeyPress peut être comparé à un string
        protected ConsoleKeyInfo AskKeyPress(string message)
        {
            Console.WriteLine(message);

            return(Console.ReadKey());
        }

        protected ConsoleKeyInfo AskKeyPress()
        {
            return AskKeyPress(DefaultAskKeyPressMessage);
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
            return (new string('-', TableWidth));
        }

        public string PrintRow(bool alignText, params string[] columns)
        {
            int width = (TableWidth - columns.Length) / columns.Length;
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
            int width = (TableWidth - cells.Length) / cells.Length;
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

        protected virtual void DisplayMainMenu()
        {
            Clear();
            DisplaySummary(Menu, MenuDebug);
            DecisionTree(AskCommand(), true);
        }

        public class ConsoleStyle
        {
            public void PrintColor(ConsoleColor color, string text, bool backLine = true)
            {
                SelectColor(color);

                if (backLine)
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

            public void Color(ConsoleColor color, string text = null, bool backLine = false)
            {
                if (!string.IsNullOrEmpty(text))
                {
                    PrintColor(color, text, backLine);
                }
                else
                {
                    SelectColor(color);
                }
            }

            public void Red(string text = null, bool backLine = false)
            {
                Color(ConsoleColor.Red, text, backLine);
            }

            public void Yellow(string text = null, bool backLine = false)
            {
                Color(ConsoleColor.Yellow, text, backLine);
            }

            public void Cyan(string text = null, bool backLine = false)
            {
                Color(ConsoleColor.Cyan, text, backLine);
            }
            public void Gray(string text = null, bool backLine = false)
            {
                Color(ConsoleColor.Gray, text, backLine);
            }
            public void White(string text = null, bool backLine = false)
            {
                Color(ConsoleColor.White, text, backLine);
            }
            public void Magenta(string text = null, bool backLine = false)
            {
                Color(ConsoleColor.Magenta, text, backLine);
            }

            public void Green(string text = null, bool backLine = false)
            {
                Color(ConsoleColor.Green, text, backLine);
            }
        }

        abstract protected void DecisionTree(string input, bool displayMenu);
    }
}
