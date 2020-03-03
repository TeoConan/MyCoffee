using System;
using MyCoffee.Entities;
using MyCoffee.Data;

namespace MyCoffee.Controllers
{
    public class StockViewer : MyCoffeeConsole
    {
        public StockViewer()
        {
            //Echo("Aucun stock à afficher");
            //AskKeyPress();
        }

        public StockViewer(string date, int quantity)
        {
            ShowStockProfile(date, quantity);
            //AskKeyPress();
        }

        public void ShowStockProfile(string date, int quantity)
        {
            string stockDetails = "Quantité : " + quantity;
            stockDetails += "\n\nDate d'expiration : " + date;

            Echo(stockDetails);
        }

        protected override void DecisionTree(string input, bool displayMenu)
        {
            throw new NotImplementedException();
        }
    }
}
