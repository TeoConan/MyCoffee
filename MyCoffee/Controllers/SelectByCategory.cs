using System;
using MyCoffee.Data;
using MyCoffee.Entities;
using System.Collections.Generic;

namespace MyCoffee.Controllers
{
    //Naming convention ok

    public class SelectByCategory : MyCoffeeConsole
    {
        public string Input { get; set; }
        public SelectByCategory() { }

        public Product SelectProductByCategory()
        {

            Menu = new List<string>();
            Menu.Add("Sandwiches");
            Menu.Add("Viennoiseries");
            Menu.Add("Salades");
            Menu.Add("Boissons");
            Menu.Add("Snacks");
            Menu.Add("Lunch boxes");
            Menu.Add("[q]uitter");

            return DisplayMainMenuWithProduct(Menu);
        }

        public Product ListProducts(int categoryId, string category)
        {
            Clear();
            var productsRepository = new ProductsRepository();

            var products = productsRepository.GetProductsByCategory(categoryId);
            Console.WriteLine("Liste des produits de la catégorie : " + category + "\n");

            var productBrowser = new ProductBrowser();
            var result = productBrowser.SelectFromListOfProductsByCategory(products);
            switch (result.Key)
            {
                case "product":
                    return (Product) result.Value;
                case "action":
                    switch(result.Value)
                    {
                        case "categories":
                            return SelectProductByCategory();
                        case "quit":
                            return null;
                        default:
                            return null;
                    }
                    break;
                default:
                    Clear();
                    Echo("Une erreur est survenue");
                    AskKeyPress();
                    return DisplayMainMenuWithProduct();
            }
        }

        protected Product DisplayMainMenuWithProduct(params List<string>[] lists)
        {
            Clear();
            DisplaySummary(Menu);
            return DecisionTreeWithProduct(AskCommand(), true);

        }

        public void WaitForKeyPress()
        {
            AskKeyPress();
        }

        protected Product DecisionTreeWithProduct(string input, bool displayMenu)
        {
            switch (input.ToLower())
            {
                case "q":
                case "7":
                    return null;
                case "1":
                    return ListProducts(2, "Sandwiches");
                case "2":
                    return ListProducts(1, "Viennoiseries");
                case "3":
                    return ListProducts(3, "Salades");
                case "4":
                    return ListProducts(4, "Boissons");
                case "5":
                    return ListProducts(5, "Snacks");
                case "6":
                    return ListProducts(6, "Lunch boxes");
                default:
                    return DecisionTreeWithProduct(AskCommand(), displayMenu);
            }

            if (displayMenu)
            {
                return DisplayMainMenuWithProduct();
            }
        }

        protected override void DecisionTree(string input, bool displayMenu)
        {
            throw new NotImplementedException();
        }
    }
}
