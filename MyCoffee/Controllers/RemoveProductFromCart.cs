using System;
using System.Collections.Generic;
using MyCoffee.Data;
using MyCoffee.Entities;

namespace MyCoffee.Controllers
{
    public class RemoveProductFromCart : MyCoffeeConsole
    {
        public List<Product> Cart { get; set; }
        public int Cursor { get; set; }

        public RemoveProductFromCart(List <Product> cart)
        {
            Cart = cart;
            Cursor = 1;
        }

        public int RemoveAProduct()
        {
            _summary = "Votre panier : \n\n";
            foreach (Product product in Cart)
            {
                _summary += Cursor + ") " + product.Name + "\n";
                Cursor += 1;
            }
            _summary += "\n\n[q]uitter";
            return DisplayMainMenuWithProduct();

        }

        public int DisplayMainMenuWithProduct()
        {
            Clear();
            DisplaySummary();
            return DecisionTreeWithProduct(AskCommand(), true);
        }

        public int DecisionTreeWithProduct(string Input, bool DisplayMenu)
        {
            var entryValidated = false;
            var result = 0;
            entryValidated = int.TryParse(Input, out result);
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
                switch (Input.ToLower())
                {
                    case "q":
                    case "quitter":
                        return 0;
                    default:
                        return DisplayMainMenuWithProduct();
                }                   
                
            }
        }

        protected override void DecisionTree(string Input, bool DisplayMenu)
        {
            throw new NotImplementedException();
        }
    }
}
