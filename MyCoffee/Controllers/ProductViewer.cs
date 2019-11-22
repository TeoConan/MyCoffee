using System;
using MyCoffee.Entities;
using MyCoffee.Data;

namespace MyCoffee.Controllers
{
    public class ProductViewer : MyCoffeeConsole
    {
        //SUMMARY :
        //This class covers functions used to display a single product.
        //All product informations are listed.
        //Returns to the previous menu when done.

        public ProductViewer(int productId)
        {
            Clear();
            var mockProductRepository = new MockProductRepository();

            var product = mockProductRepository.getProductById(productId);
            ShowProductProfile(product);
            WaitForKeyPress();
        }

        public ProductViewer(Product product)
        {
            ShowProductProfile(product);
        }

        public void ShowProductProfile(Product product)
        {
            string productDetails = "Nom : " + product.Name;
            productDetails += "\nId : " + product.Id;
            var mockCategoryRepository = new MockCategoryRepository();
            string categoryLabel = mockCategoryRepository.GetCategoryLabel(product.Id);
            productDetails += "\n\nCatégorie : " + categoryLabel;
            productDetails += "\n\nDescription : " + product.Description;
            productDetails += "\n\nPrix : " + product.Price.ToString() + "\n";

            Echo(productDetails);
        }

        public void WaitForKeyPress()
        {
            Echo("Appuyez sur une touche pour revenir au menu.\n");

            Console.ReadKey();
            Clear();
        }
    }
}
