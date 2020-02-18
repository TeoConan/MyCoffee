using MyCoffee.Data;
using MyCoffee.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyCoffee.Controllers
{
    class Explorer : MyCoffeeConsole
    {
        //Naming convention ok

        private List<string> Categories { get; set; }
        private List<Product> Products { get; set; }
        public Explorer()
        {
            //Récupération des catégories sous forme d'une liste
            Array arr = Enum.GetValues(typeof(ProductCategory));
            Categories = new List<string>(arr.Length);
            for (int i = 0; i < arr.Length; i++)
            {
                Categories.Add(arr.GetValue(i).ToString());
            }

            ShowCategory();
        }

        public void AskProductSelection()
        {

        }

        public void Display()
        {

        }

        private void ShowCategory()
        {
            Clear();
            for (int i = 0; i < Categories.Count; i++)
            {
                Echo(" " + i + ") " + Categories[i]);
            }
        }

        protected override void DecisionTree(string command, bool displayMenu)
        {
            throw new NotImplementedException();
        }
    }
}
