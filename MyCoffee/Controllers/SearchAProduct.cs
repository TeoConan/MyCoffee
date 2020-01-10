using System;
using MyCoffee.Entities;
using MyCoffee.Data;

namespace MyCoffee.Controllers
{
    public class SearchAProduct : MyCoffeeConsole
    {
        public string Input { get; set; }

        public SearchAProduct()
        {
            Clear();
            WaitForCommand();
        }

        public void WaitForCommand()
        {
            Echo("Entrez un id ou un nom de produit : ");
            Input = Console.ReadLine();
            int id;
            Product product;

            if (int.TryParse(Input, out id))
            {
                var productViewer = new ProductViewer(id);
                AskKeyPress();
            } else
            {
                product = Product.getProductByName(Input);
                var productViewer = new ProductViewer(product);
                AskKeyPress();
            }

        }

        protected override void DecisionTree(string Input, bool DisplayMenu)
        {
        }
    }
}
