using System;
using MyCoffee.Entities;
using MyCoffee.Data;

namespace MyCoffee.Controllers
{
    public class ProductViewer : MyCoffeeConsole
    {
        //Naming convention ok

        //SUMMARY :
        //This class covers functions used to display a single product.
        //All product information are listed.
        //Returns to the previous menu when done.

        public ProductViewer()
        {
            //Echo("Aucun produit à afficher");
            //AskKeyPress();
        }

        public ProductViewer(int productId)
        {
            Clear();
            ProductsRepository productsRepository = new ProductsRepository();
            var product = productsRepository.GetProductById(productId);
            if (product == null)
            {
                Echo("Aucun produit trouvé.\n");
            } else
            {
                ShowProductProfile(product);
            }
            //AskKeyPress();
        }

        public ProductViewer(Product product)
        {
            Clear();
            ShowProductProfile(product);
            //AskKeyPress();
        }

        public void ShowProductProfile(Product product)
        {
            string productDetails = "Nom : " + product.Name;
            productDetails += "\n\nId : " + product.Id;
            var mockCategoryRepository = new MockCategoryRepository();
            string categoryLabel = mockCategoryRepository.GetCategoryLabel(product.CategoryId);
            productDetails += "\n\nCatégorie : " + categoryLabel;
            productDetails += "\n\nDescription : " + product.Description;
            productDetails += "\n\nPrix : " + product.Price.ToString() + "€\n";

            Echo(productDetails);
        }

        protected override void DecisionTree(string command, bool displayMenu)
        {
        }
    }
}
