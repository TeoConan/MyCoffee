using System;
using MyCoffee.Data;
using MyCoffee.Entities;

namespace MyCoffee.Controllers
{
    public class SelectByCategory : MyCoffeeConsole
    {
        public string Input { get; set; }
        public SelectByCategory() { }

        public Product SelectProductByCategory()
        {
            _summary = "";
            _summary += "1) Sandwich\n";
            _summary += "2) Viennoiserie\n";
            _summary += "3) Salades\n";
            _summary += "4) Boissons\n";
            _summary += "5) Snacks\n";
            _summary += "6) Lunch boxes\n";
            _summary += "\n[q]uitter\n";


            return DisplayMainMenuWithProduct();
        }

        public Product ListProducts(int categoryId, string category)
        {
            Clear();
            var mockProductRepository = new MockProductRepository();

            var products = mockProductRepository.getProductsByCategory(categoryId);
            Console.WriteLine("Liste des produits de la catégorie : " + category + "\n");

            var productBrowser = new ProductBrowser();
            var result = productBrowser.SelectFromListOfProductsByCategory(products);
            switch (result.Key)
            {
                case "product":
                    return (Product)result.Value;
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

        protected Product DisplayMainMenuWithProduct()
        {
            Clear();
            DisplaySummary();
            return DecisionTreeWithProduct(AskCommand(), true);

        }

        public void WaitForKeyPress()
        {
            AskKeyPress();
        }

        protected Product DecisionTreeWithProduct(string Input, bool DisplayMenu)
        {
            switch (Input.ToLower())
            {
                case "q":
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
                    return DecisionTreeWithProduct(AskCommand(), DisplayMenu);
            }

            if (DisplayMenu)
            {
                return DisplayMainMenuWithProduct();
            }
        }

        protected override void DecisionTree(string Input, bool DisplayMenu)
        {
            throw new NotImplementedException();
        }
    }
}
