using System;
using System.Collections.Generic;
using MyCoffee.Data;
using MyCoffee.Entities;

namespace MyCoffee.Controllers
{
    public class AddProduct : MyCoffeeConsole
    {
        //Naming convention ok

        public AddProduct()
        {
            Clear();
            int categoryId = AskForCategory();
            Clear();
            string name = AskForName();
            Clear();
            string description = AskCommand("Description (optionnelle):");
            Clear();
            float price = AskForFloat("Entrez le prix (avec une virgule) :");

            var product = new Product { CategoryId = categoryId, Name = name, Description = description, Price = price };

            ProductsRepository productsRepository = new ProductsRepository();
            StocksRepository stockRepository = new StocksRepository();
            bool isProductValidated = ValidateProduct(product);

            if (isProductValidated)
            {
                Clear();
                Echo("Ajout du produit en base...");

                try
                {
                    productsRepository.AddProduct(product);

                } catch (Exception e)
                {
                    Style.SelectColor(ConsoleColor.Red);
                    Echo("Impossible d'ajouter le produit en base");
                    //TODO Message d'erreur ?
                    Echo("Message d'erreur");
                    Echo(e.Message);
                    Style.SelectColor(ConsoleColor.White);
                    AskKeyPress();
                    return;
                }

                Style.Green("Le produit a bien été créé.", true);

            } else
            {
                Clear();
                Style.Yellow("La création de produit a été annulée.", true);
                AskKeyPress();
            }

            var listProduct = productsRepository.getLastProduct();
            
            var stock = new Stock { Quantity = 20, ProductId = listProduct.Id, Expiry = 1578665721 };
            stockRepository.AddStock(stock);
            AskKeyPress();
        }

        public string AskForName()
        {
            var entryValidated = false;
            string command = "";

            while (!entryValidated)
            {
                command = AskCommand("Nom : ");
                if (command.Length < 3)
                {
                    Echo("\nLe nom du produit doit faire au moins 3 caractères");
                } else
                {
                    entryValidated = true;
                }
            }

            return command;
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
                }

            }

            return result;
        }

        public int AskForCategory()
        {
            int command = 0;

            var mockCategoryRepository = new MockCategoryRepository();
            var categories = mockCategoryRepository.GetAllCategories();

            Echo("CATEGORIES\n----------");
            foreach (var category in categories)
            {
                Echo(category.Id + ") " + category.Name);
            }

            var entryValidated = false;

            while (!entryValidated)
            {
                command = AskForInteger("\nEntrez l'id de la catégorie souhaitée");
                if ( mockCategoryRepository.DoesCategoryExist(command))
                {
                    entryValidated = true;
                }

                Echo("\nImpossible de trouver une catégorie correspondant à l'id mentionné.");
            }

            return command;
        }

        public bool ValidateProduct(Product product)
        {

            var producViewer = new ProductViewer(product);
            Echo("\n-------------------");
            Echo("\nConfirmez vous l'enregistrement de ce produit ? [oui/non]");

            return AskYesNo();

        }

        protected override void DecisionTree(string input, bool displayMenu)
        {
        }
    }
}
