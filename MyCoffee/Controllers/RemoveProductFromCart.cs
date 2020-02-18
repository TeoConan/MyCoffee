using System;
using System.Collections.Generic;
using MyCoffee.Data;
using MyCoffee.Entities;

namespace MyCoffee.Controllers
{
    public class RemoveProductFromCart : MyCoffeeConsole
    {
        //Naming convention ok

        public List<Product> Cart { get; set; }
        public int Cursor { get; set; }

        public RemoveProductFromCart(List <Product> cart)
        {
            Cart = cart;
            Cursor = 1;
        }

        public int RemoveAProduct()
        {
            //TODO Summary mal utilisé
            Summary = "Votre panier : \n\n";
            foreach (Product product in Cart)
            {
                Summary += Cursor + ") " + product.Name + "\n";
                Cursor += 1;
            }
            Summary += "\n\n[q]uitter";
            return DisplayMainMenuWithProduct();

        }

        public int DisplayMainMenuWithProduct()
        {
            Clear();
            DisplaySummary();
            return DecisionTreeWithProduct(AskCommand(), true);
        }

        public int DecisionTreeWithProduct(string input, bool displayMenu)
        {
            var entryValidated = false;
            var result = 0;
            entryValidated = int.TryParse(input, out result);
            if (entryValidated)
            {
                if (result <= Cursor)
                {
                    return result;
                } else {
                   return DisplayMainMenuWithProduct();
                }
            } else
            {
                switch (input.ToLower())
                {
                    case "q":
                    case "quitter":
                        return 0;
                    default:
                        return DisplayMainMenuWithProduct();
                }                   
                
            }
        }

        protected override void DecisionTree(string input, bool displayMenu)
        {
            throw new NotImplementedException();
        }
    }
}
