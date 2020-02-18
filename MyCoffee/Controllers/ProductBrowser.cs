using System;
using System.Collections.Generic;
using MyCoffee.Entities;

namespace MyCoffee.Controllers
{
    public class ProductBrowser : MyCoffeeConsole
    {
        //Naming convention ok

        public ProductBrowser()
        {
        }

        public void BrowseListOfProducts(List<Product> products)
        {
            ProductViewer productViewer = new ProductViewer();

            int cursor = 0;
            string entry;

            int cursorMinimum = 0;
            int cursorMaximum = products.Count - 1;

            bool isBrowsing = true;

            while (isBrowsing)
            {
                Clear();
                productViewer.ShowProductProfile(products[cursor]);
                Echo("----------------");
                Echo("Produit " + (cursor + 1) + "/" + (cursorMaximum + 1));
                Echo("[p]récédent, [s]uivant, [q]uitter\n");

                entry = AskCommand();

                switch (entry.ToLower())
                {
                    case "p":
                    case "précédent":
                        if (cursorMinimum < cursor)
                        {
                            cursor = cursor - 1;
                        }
                        break;

                    case "s":
                    case "suivant":
                        if (cursor < cursorMaximum)
                        {
                            cursor = cursor + 1;
                        }
                        break;

                    case "q":
                        isBrowsing = false;
                        break;

                }
            }
        }

        public Product SelectFromListOfProducts(List<Product> products)
        {
            ProductViewer productViewer = new ProductViewer();

            int cursor = 0;
            string entry;

            int cursorMinimum = 0;
            int cursorMaximum = products.Count - 1;

            while (true)
            {
                Clear();
                productViewer.ShowProductProfile(products[cursor]);
                Echo("----------------");
                Echo("Produit " + (cursor + 1) + "/" + (cursorMaximum + 1));
                Echo("[p]récédent, [s]uivant, [c]hoisir, [q]uitter\n");

                entry = AskCommand();

                switch (entry)
                {
                    case "p":
                    case "précédent":
                        if (cursorMinimum < cursor)
                        {
                            cursor = cursor - 1;
                        }
                        break;

                    case "s":
                    case "suivant":
                        if (cursor < cursorMaximum)
                        {
                            cursor = cursor + 1;
                        }
                        break;

                    case "c":
                    case "choisir":
                        return products[cursor];

                    case "q":
                        return null;

                }
            }
        }

        public KeyValuePair <string, object> SelectFromListOfProductsByCategory(List<Product> products)
        {
            ProductViewer productViewer = new ProductViewer();

            int cursor = 0;
            string entry;

            int cursorMinimum = 0;
            int cursorMaximum = products.Count - 1;

            while (true)
            {
                Clear();
                productViewer.ShowProductProfile(products[cursor]);
                Echo("----------------");
                Echo("Produit " + (cursor + 1) + "/" + (cursorMaximum + 1));
                Echo("[p]récédent, [s]uivant, [c]hoisir, [r]evenir aux catégories, [q]uitter\n");

                entry = AskCommand();

                switch (entry.ToLower())
                {
                    case "p":
                    case "précédent":
                        if (cursorMinimum < cursor)
                        {
                            cursor = cursor - 1;
                        }
                        break;

                    case "s":
                    case "suivant":
                        if (cursor < cursorMaximum)
                        {
                            cursor = cursor + 1;
                        }
                        break;

                    case "c":
                    case "choisir":
                        return new KeyValuePair<string, object>("product", products[cursor]);
                    case "r":
                        return new KeyValuePair<string, object>("action", "categories");                                  

                    case "q":
                        return new KeyValuePair<string, object>("action", "quit");
                }
            }
        }

        protected override void DecisionTree(string input, bool displayMenu)
        {
            throw new NotImplementedException();
        }
    }
}
