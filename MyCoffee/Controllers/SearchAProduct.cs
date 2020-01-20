using System;
using MyCoffee.Entities;
using MyCoffee.Data;
using System.Collections.Generic;

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
            List <Product> products;

            if (int.TryParse(Input, out id))
            {
               /* var productBrowser = new ProductBrowser(id);
                AskKeyPress();*/
            } else
            {
                ProductsRepository productsRepository = new ProductsRepository();
                products = productsRepository.getProductsByName(Input);

                if (products.Count == 0)
                {
                    Echo("Aucun produit trouvé.");
                    AskKeyPress();
                } else
                {
                    var productBrowser = new ProductBrowser();
                    productBrowser.BrowseListOfProducts(products);
                    AskKeyPress();
                }
            }

        }

        protected override void DecisionTree(string Input, bool DisplayMenu)
        {
        }
    }
}
