using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCoffee.Entities;
using MyCoffee.Data;
using MyCoffee.Controllers;

namespace MyCoffee.Controllers
{
    class MainMenu : MyCoffeeConsole
    {

        public MainMenu()
        {
            _summary = "";
            _summary += "1) Documentation\n";
            _summary += "2) Lister les produits\n";
            _summary += "3) Passer une commande\n";
            _summary += "4) Voir les dates courtes\n";
            _summary += "5) Lister par catégorie\n";
            _summary += "6) Ajouter un produit\n";
            _summary += "7) Quitter\n";
            _summary += "8) Test\n";
            _summary += "9) DEBUG - Afficher le produit 5\n";
            _summary += "10) DEBUG - Rechercher un produit par id ou nom\n";
            _summary += "11) DEBUG - Créer un produit\n";

            Welcome();
            DisplayMainMenu();

        }

        public void Welcome()
        {
            Echo("Bienvenue dans MyCoffee");
        }

        

        protected override void DecisionTree(string Input, bool DisplayMenu)
        {
            switch (Input)
            {
                case "0":
                    return;

                case "1":
                    Clear();
                    DisplayMainMenu();
                    break;

                case "2":
                    new ListAllProducts();
                    break;

                case "3":
                    //MakeOrder();
                    break;

                case "4":
                    //SortShortDates();
                    break;

                case "5":
                    ListProductByCategory();
                    DisplayMainMenu();
                    break;

                case "6":
                    AddProduct();
                    DisplayMainMenu();
                    break;

                case "7":
                    return;
                    break;

                case "8":
                    test();
                    break;
                case "9":
                    DebugShowProduct();
                    break;
                case "10":
                    DebugSearchProduct();
                    break;
                case "11":
                    DebugCreateProduct();
                    break;

                default:
                    DecisionTree(AskCommand(), DisplayMenu);
                    break;
            }

            if (DisplayMenu)
            {
                DisplayMainMenu();
            }
        }

        public void ListAllProducts()
        {
            Clear();
            var mockProductRepository = new MockProductRepository();

            var products = mockProductRepository.getAllProducts();
            Echo("Liste des produits : \n");

            foreach (Product product in products)
            {
                Console.WriteLine(product.Name + "\n");
            }

            AskKeyPress("Appuyez sur une touche pour revenir au menu.\n");
            DisplayMainMenu();
        }

        public void ListProductByCategory()
        {
            var listByCategory = new ListByCategory();
        }

        private void test()
        {
            //var explorer = new Explorer();
            var test = new Test();
        }

        public void DebugSearchProduct()
        {
            var searchAProduct = new SearchAProduct();
        }

        public void DebugShowProduct()
        {
            var productViewer = new ProductViewer(5);
            AskKeyPress();
        }

        public void AddProduct()
        {
            var addProduct = new AddProduct();
        }

        public void DebugCreateProduct()
        {
            Clear();
            var id = AskCommand("Id :");

            var mockCategoryRepository = new MockCategoryRepository();
            var categories = mockCategoryRepository.GetAllCategories();

            Echo("\nCATEGORIES\n----------");
            foreach (var category in categories)
            {
                Echo(category.Id + ") " + category.Name);
            }

            var categoryId = AskCommand("\nId de la catégorie : ");
            var name = AskCommand("Nom : ");
            var description = AskCommand("Description :");
            var price = AskCommand("Prix avec une virgule s'il vous plait : ");

            var product = new Product { Id = int.Parse(id), CategoryId = int.Parse(categoryId), Name = name, Description = description, Price = float.Parse(price) };

            var producViewer = new ProductViewer(product);
            Echo("\n-------------------");
            Echo("\n1) Valider l'ajout de produit.");
            Echo("\n2) Annuler l'ajout de produit.\n");

            AskCommand();

            return;
        }
    }
}
