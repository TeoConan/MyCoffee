using System;
using MyCoffee.Entities;
using MyCoffee.Data;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace MyCoffee.Controllers
{
    public class SearchShortDates : MyCoffeeConsole
    {
        public SearchShortDates()
        {
            Clear();
            
            string dateSearch = AskForDate();
            bool isProductValidated = ValidateProduct(dateSearch);

            if(isProductValidated)
            {
                Clear();
                Echo("Liste des produits dont la date de consommation se terminant avant ou le " + dateSearch + " : \n");
                PrintTableHeader(true, "Id", "Name", "Prix", "Stock", "Date d'expiration");

                StocksRepository stocksRepository = new StocksRepository();
                ProductsRepository productsRepository = new ProductsRepository();

                var stringDateSearch = stocksRepository.ConvertStringDateToTimeStamp(dateSearch);
                var listProducts = productsRepository.GetAllProducts();

                foreach (Product aProduct in listProducts)
                {
                    var stockProduct = stocksRepository.GetStockByProductId(aProduct.Id);
                    var stringExpiry = stocksRepository.ConvertTimeStampToStringDate(stockProduct.Expiry);
                    int result = stringDateSearch.CompareTo(stockProduct.Expiry);

                    if (result >= 0)
                    {
                        PrintLineCells(true, $"{aProduct.Id}", aProduct.Name, $"{aProduct.Price}", $"{stockProduct.Quantity}", stringExpiry);
                    }
                    else
                    {
                    }
                }
                Echo(PrintLine());
                WaitForKeyPress();
            }
        }

        public string AskForDate()
        {
            var entryValidated = false;
            string command = "";

            while (!entryValidated)
            {
                command = AskCommand("[q]uitter pour revenir au menu" + 
                    "\nVeuillez rentrer la date limite de consommation (ex: 11/02/2021):" + 
                    "\n");
                
                Regex regex = new Regex(@"([0-9]{1,2})\/([0-9]{1,2})\/([0-9]{4})$", RegexOptions.IgnorePatternWhitespace);
                Match match = regex.Match(command);

                if (command == "q")
                {
                    Clear();
                    MainMenu mainMenu = new MainMenu();
                }
                else if(!match.Success)
                {
                    Echo("\nLa date n'est pas valide");
                }
                else
                {
                    entryValidated = true;
                }
            }

            return command;
        }

        public bool ValidateProduct(string date)
        {
            Clear();
            Echo("Date saisie: " + date);
            Echo("\n-------------------");
            Echo("\nConfirmez vous la recherche pour cette date ? [oui/non]");

            return AskYesNo();
        }

        public void WaitForKeyPress()
        {
            Echo("Appuyez sur une touche pour revenir au menu.\n");

            Console.ReadKey();
            Clear();
        }

        protected override void DecisionTree(string input, bool displayMenu)
        {
        }
    }
}
