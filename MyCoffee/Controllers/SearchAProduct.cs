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
            var mockProductRepository = new MockProductRepository();
            Input = Console.ReadLine();
            int id;
            Product product;

            if (int.TryParse(Input, out id))
            {
                var productViewer = new ProductViewer(id);
            } else
            {
                product = mockProductRepository.getProductByName(Input);
                var productViewer = new ProductViewer(product);
            }

        }

        protected override void DecisionTree(string command, bool DisplayMenu)
        {
        }
    }
}
