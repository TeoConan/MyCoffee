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

            _menu = new List<string>();
            _menu.Add("Ajouter un produit par nom ou id");
            _menu.Add("Ajouter un produit par catégorie");
            _menu.Add("Retirer un produit");
            _menu.Add("Valider la commande");
            _menu.Add("Annuler la commande");

            DisplayMainMenu(_menu);
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
           
            DisplaySummary(_menu);
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
                    RemoveFromCart();
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
            float totalPrice = 0.0F;
            Echo("Contenu du panier :");
            foreach (Product product in Cart)
            {
                Echo ("- " + product.Name + " | " + Math.Round(product.Price, 2) + "€");
                totalPrice += product.Price;
            }
           
            Echo("\nTotal du panier : " + Math.Round(totalPrice, 2).ToString() + "€");
            Echo("\n");
        }
    }
}
