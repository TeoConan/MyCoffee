using System;
using MyCoffee.Entities;
using MyCoffee.Data;
using System.Collections.Generic;

namespace MyCoffee.Controllers
{
    public class CreateAnOrder : MyCoffeeConsole
    {
        //Naming convention ok

        public List<Product> Cart { get; set; }

        public CreateAnOrder()
        {
            Cart = new List<Product>();
            Summary = "1) Ajouter un produit par nom ou id\n";
            Summary += "2) Ajouter un produit par catégorie\n";
            Summary += "3) Retirer un produit\n";
            Summary += "4) Valider la commande\n";
            Summary += "5) Annuler la commande\n";
            
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

        public void RemoveFromCart()
        {
            var removeProductFromCart = new RemoveProductFromCart(Cart);
            var id = removeProductFromCart.RemoveAProduct();
            if (id == 0)
            {
                DisplayMainMenu();
            } else
            {
                Cart.RemoveAt(id - 1);
                DisplayMainMenu();
            }
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

        protected override void DecisionTree(string input, bool displayMenu)
        {
            switch(input)
            {
                case "1":
                    SelectAProduct();
                    break;
                case "2":
                    SelectAProductByCategory();
                    break;
                case "3":
                    RemoveFromCart();
                    break;
                case "4":

                    break;
                case "5":

                    break;
                default:
                    DecisionTree(AskCommand(), displayMenu);
                    break;
            }

        }

        public void DisplayCart()
        {
            Echo("Contenu du panier :");
            foreach (Product product in Cart)
            {
                Echo ("- " + product.Name + " | " + product.Price + "€");
            }
            Echo("\n");
        }
    }
}
