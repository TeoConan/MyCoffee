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
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            _summary = "";
            _summary += "1) Documentation\n";
            _summary += "2) Lister les produits\n";
            _summary += "3) Passer une commande\n";
            _summary += "4) Voir les dates courtes\n";
            _summary += "5) Lister par catégorie\n";
            _summary += "6) Ajouter un produit\n";
            _summary += "7) DEBUG - Ajouter produit test\n";
            _summary += "8) Test\n";
            _summary += "9) DEBUG - Afficher le produit 5\n";
            _summary += "10) DEBUG - Rechercher un produit par id ou nom\n";
            _summary += "11) DEBUG - Afficher tous les produits\n";
            _summary += "12) DEBUG - Passer une commande\n";

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
                    generateData();
                    DisplayMainMenu();
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
                    DebugListAllProducts();
                    break;

                case "12":
                    CreateAnOrder();
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
            AskKeyPress();
        }


        private void generateData()
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

        public void DebugListAllProducts()
        {
            MockProductRepository mockProductRepository = new MockProductRepository();
            List<Product> products = mockProductRepository.getAllProducts();

            ProductBrowser productBrowser = new ProductBrowser();
            productBrowser.BrowseListOfProducts(products);
        }

        public void CreateAnOrder()
        {

        }
    }
}
