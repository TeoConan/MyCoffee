using System;
using MyCoffee.Data;
using MyCoffee.Entities;

namespace MyCoffee.Controllers
{
    public class AddProduct : MyCoffeeConsole
    {
        public AddProduct()
        {
            Clear();
            int id = AskForInteger("Id :");
            Clear();
            int categoryId = AskForCategory();
            Clear();
            string name = AskCommand("Nom : ");
            Clear();
            string description = AskCommand("Description :");
            Clear();
            float price = AskForFloat("Entrez le prix (avec une virgule) :");

            var product = new Product { Id = id, CategoryId = categoryId, Name = name, Description = description, Price = price };

            bool isProductValidated = ValidateProduct(product);

            if (isProductValidated)
            {
                Clear();
                Echo("Le produit a bien été créé.");
                AskKeyPress();
            } else
            {
                Clear();
                Echo("La création de produit a été annulée.");
                AskKeyPress();
            }

        }

        public int AskForInteger(string message)
        {
            var entryValidated = false;
            string command;
            int result = 0;
            
            while (!entryValidated)
            {
                command = AskCommand(message);
                entryValidated = int.TryParse(command, out result);
                if (!entryValidated)
                {
                    Echo("\nLa valeur entrée doit être un nombre entier");
                    AskKeyPress();
                }

            }

            return result;
        }

        public float AskForFloat(string message)
        {
            var entryValidated = false;
            string command;
            float result = 0;

            while (!entryValidated)
            {
                command = AskCommand(message);
                entryValidated = float.TryParse(command, out result);
                if (!entryValidated)
                {
                    Echo("\nLa valeur entrée doit être un nombre décimal.\n Exemple : 16 ou 25,67.");
                    AskKeyPress();
                }

            }

            return result;
        }

        public int AskForCategory()
        {
            int result = 0;

            var mockCategoryRepository = new MockCategoryRepository();
            var categories = mockCategoryRepository.GetAllCategories();

            Echo("CATEGORIES\n----------");
            foreach (var category in categories)
            {
                Echo(category.Id + ") " + category.Name);
            }

            result = AskForInteger("\nEntrez l'id de la catégorie souhaitée");

            return result;
        }

        public bool ValidateProduct(Product product)
        {
            string entry;
            bool productChecked = false;

            var producViewer = new ProductViewer(product);
            Echo("\n-------------------");
            Echo("\nConfirmez vous l'enregistrement de ce produit ?");

            return AskYesNo();

        }

        protected override void DecisionTree(string Input, bool DisplayMenu)
        {
        }
    }
}
