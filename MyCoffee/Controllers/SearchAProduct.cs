using System;
using MyCoffee.Entities;
using MyCoffee.Data;
using System.Collections.Generic;

namespace MyCoffee.Controllers
{
    public class SearchAProduct : MyCoffeeConsole
    {
        //Naming convention ok

        public string Input { get; set; }

        public SearchAProduct()
        {
        }

        public void SearchProducts()
        {
            Clear();
            Echo("Entrez un id ou un nom de produit : ");
            Input = Console.ReadLine();
            int id;
            List <Product> products;

            if (int.TryParse(Input, out id))
            {
                var productViewer = new ProductViewer(id);
                AskKeyPress();
            } else
            {
                ProductsRepository productsRepository = new ProductsRepository();
                products = productsRepository.GetProductsByName(Input);

                if (products.Count == 0)
                {
                    Echo("Aucun produit trouvé.");
                    AskKeyPress();
                } else
                {
                    var productBrowser = new ProductBrowser();
                    productBrowser.BrowseListOfProducts(products);
                }
            }

        }

        public Product SelectAProduct()
        {
            Clear();
            Echo("Entrez un id ou un nom de produit : ");
            Input = Console.ReadLine();
            int id;
            List<Product> products;

            if (int.TryParse(Input, out id))
            {
                var productViewer = new ProductViewer(id);
                AskKeyPress();
                var productRepository = new ProductsRepository();
                return productRepository.GetProductById(id);
            }
            else
            {
                ProductsRepository productsRepository = new ProductsRepository();
                products = productsRepository.GetProductsByName(Input);

                if (products.Count == 0)
                {
                    Echo("Aucun produit trouvé.");
                    AskKeyPress();
                    return null;
                }
                else
                {
                    var productBrowser = new ProductBrowser();
                    return productBrowser.SelectFromListOfProducts(products);
                }
            }
        }

        protected override void DecisionTree(string input, bool displayMenu)
        {
        }
    }
}
