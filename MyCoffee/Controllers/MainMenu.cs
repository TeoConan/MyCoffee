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
        //Naming convention ok

        public MainMenu()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Menu = new List<string>();
            MenuDebug = new List<string>();

            Menu.Add("Documentation");
            Menu.Add("Lister les produits");
            Menu.Add("Passer une commande");
            Menu.Add("Voir les dates courtes");
            Menu.Add("Lister par catégorie");
            Menu.Add("Ajouter un produit");
            Menu.Add("Rechercher produit");

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
                    Environment.Exit(0);
                    return;

                case "1":
                    Clear();
                    DisplayMainMenu();
                    break;

                case "2":
                    new ListAllProducts();
                    break;

                case "3":
                    CreateAnOrder();
                    break;

                case "4":
                    new SearchShortDates();
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
                    SearchProduct();
                    break;

                case "-1":
                    GenerateData();
                    DisplayMainMenu();
                    break;

                case "-2":
                    DrawColor();
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

            var products = mockProductRepository.GetAllProducts();
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

        private void Test()
        {
            //var explorer = new Explorer();
            var test = new Test();
            AskKeyPress();
        }

        public void DrawColor()
        {
            Style.Red("Je suis rouge");
            Style.Green(" , je suis vert");
            Style.Yellow(" lol chui jaune");
            Style.Cyan(" genre chui cyan là", true);

            AskKeyPress();
        }


        private void GenerateData()
        {
            Clear();

            //Product
            var productsRepository = new ProductsRepository();
            List<Product> listProduct = new List<Product>
            {
                new Product { CategoryId = 2, Name = "Panini Chelou", Description = "Contenu étrange de sucré-salé", Price = 5 },
                new Product { CategoryId = 2, Name = "Panini Mieux", Description = "Peu import, c'est meilleur", Price = 5 },
                new Product { CategoryId = 1, Name = "Croissant", Description = "C'est juste un croissant", Price = 1.05F },
                new Product { CategoryId = 5, Name = "Brownie", Description = "erverv", Price = 0.99F },
                new Product { CategoryId = 5, Name = "Muffin", Description = "ervzrtb", Price = 1F },
                new Product { CategoryId = 6, Name = "PastaBox Bolo", Description = "dsdfgfngh,fj;gk", Price = 6.60F },
                new Product { CategoryId = 6, Name = "Pizza 4 fromages", Description = "dfbs", Price = 7.90F },
                new Product { CategoryId = 4, Name = "Ice Tea", Description = "qr", Price = 4.55F },
                new Product { CategoryId = 3, Name = "Salade Piedmontaise", Description = "qrdqdb", Price = 8.45F },
                new Product { CategoryId = 5, Name = "Snicker", Description = "qdvqrv", Price = 1.45F },
                new Product { CategoryId = 0, Name = "Café", Description = "qrgrqbn", Price = 99F }
            };

            foreach (Product aProduct in listProduct)
            {
                Console.WriteLine($"Adding {aProduct.Name}");
                productsRepository.AddProduct(aProduct);
            }

            //One single customer test

            Customer c1 = new Customer()
            {
                Id = 1,
                Name = "Amir",
                Orders = new List<CustomerOrder> {
                    new CustomerOrder()
                    {
                        Id = 1,
                        TotalPrice = 4f,
                        CustomerId = 1,
                        Lines = new List<OrderLine> {
                            new OrderLine() {
                                Id = 1,
                                ProductId = 1,
                                OrderId = 1,
                                Quantity = 1,
                                Price = 2f
                            },
                        },
                        TimeCreate = 1578665721,
                        TimeUpdate = 0,
                        TimeDelete = 0
                    },
                },
                TimeCreate = 1578665721,
                TimeUpdate = 0,
                TimeDelete = 0,

            };

            CustomerRepository customerRepository = new CustomerRepository();
            customerRepository.AddCustomer(c1);

            Console.WriteLine("End");
            AskKeyPress();
        }

        public void SearchProduct()
        {
            var searchAProduct = new SearchAProduct();
            searchAProduct.SearchProducts();
        }

        public void DebugShowProduct()
        {
            var productViewer = new ProductViewer(5);
            AskKeyPress();
        }

        public void DebugTable()
        {
            Clear();
            PrintTableHeader(true, "Col1", "Col2", "Col3");
            PrintLineCells(true, "Text1", "Text2", "Text3");

            AskKeyPress();
        }

        public void AddProduct()
        {
            var addProduct = new AddProduct();
        }

        public void DebugListAllProducts()
        {
            MockProductRepository mockProductRepository = new MockProductRepository();
            List<Product> products = mockProductRepository.GetAllProducts();

            ProductBrowser productBrowser = new ProductBrowser();
            productBrowser.BrowseListOfProducts(products);
        }

        public void CreateAnOrder()
        {
            var createAnOrder = new CreateAnOrder();
        }
    }
}
