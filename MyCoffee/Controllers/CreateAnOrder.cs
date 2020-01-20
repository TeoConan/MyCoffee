using System;
using MyCoffee.Entities;
using MyCoffee.Data;
using System.Collections.Generic;

namespace MyCoffee.Controllers
{
    public class CreateAnOrder : MyCoffeeConsole
    {
        public List<Product> Cart { get; set; }

        public CreateAnOrder()
        {
            Cart = new List<Product>();
            _summary = "1) Ajouter un produit par nom ou id\n";
            _summary += "2) Ajouter un produit par catégorie\n";
            _summary += "3) Retirer un produit\n";
            _summary += "4) Valider la commande\n";
            _summary += "5) Annuler la commande\n";
            
            DisplayMainMenu();
        }

        public void SelectAProduct()
        {
            var searchAProduct = new SearchAProduct();
            var product = searchAProduct.SelectAProduct();
            if (product != null)
            {
                Cart.Add(product);
            }
            
            DisplayMainMenu();

        }

        public void SelectAProductByCategory()
        {
            var selectByCategory = new SelectByCategory();
            var product = selectByCategory.SelectProductByCategory();

            if (product != null)
            {
                Cart.Add(product);
            }

            DisplayMainMenu();
        }

        protected override void DisplayMainMenu()
        {
            Clear();
            if (Cart != null)
            {
                if (Cart.Count >= 1)
                {
                    DisplayCart();
                }
            }
           
            DisplaySummary();
            DecisionTree(AskCommand(), true);
        }

        protected override void DecisionTree(string Input, bool DisplayMenu)
        {
            switch(Input)
            {
                case "1":
                    SelectAProduct();
                    break;
                case "2":
                    SelectAProductByCategory();
                    break;
                case "3":

                    break;
                case "4":

                    break;
                case "5":

                    break;
                default:
                    DecisionTree(AskCommand(), DisplayMenu);
                    break;
            }

        }

        public void DisplayCart()
        {
            Echo("Contenu du panier :");
            foreach (Product product in Cart)
            {
                Echo ("- " + product.Name);
            }
            Echo("\n");
        }
    }
}
