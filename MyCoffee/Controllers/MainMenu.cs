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
            _summary += "6) Quitter\n";
            _summary += "7) DEBUG - Ajouter produit test\n";
            _summary += "8) DEBUG - Afficher le produit 5\n";
            _summary += "9) DEBUG - Rechercher un produit par id ou nom\n";
            _summary += "10) DEBUG - Créer un produit\n";

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
                    new ListByCategory();
                    DisplayMainMenu();
                    break;

                case "6":
                    return;
                    break;

                case "7":
                    generateData();
                    break;
                case "8":
                    DebugShowProduct();
                    break;
                case "9":
                    DebugSearchProduct();
                    break;
                case "10":
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
                Product.AddProduct(aProduct);
            }
            
            //CustomerOrder & Customer
            Random random = new Random();
            List<String> customerNames = new List<String>
            {
                "Eva", "Vincent", "Téo", "Alex", "Hugo", "Etienne", "Thomas"
            };
            int numberUsers = random.Next(3, customerNames.Count());
            List<Customer> listCustomers = new List<Customer>();

            Console.WriteLine($"Adding {numberUsers} new users");
            for (int i = 0; i < numberUsers; i++)
            {
                int numberOrder = random.Next(1, 5);
                long timestamp = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();
                int timeCreate = Convert.ToInt32(timestamp);

                List<CustomerOrder> listCustomerOrder = new List<CustomerOrder>();
                
                for (int i2 = 0; i2 < numberOrder; i2++)
                {
                    var customerOrder = new CustomerOrder {
                        Id = i2,
                        TotalPrice = (random.Next(1, 25)),
                        TimeCreate = timeCreate,
                        TimeDelete = 0,
                        TimeUpdate = 0
                    };

                    CustomerOrder.AddCustomerOrder(customerOrder);
                    listCustomerOrder.Add(customerOrder);
                }

                var customer = new Customer
                {
                    Id = i,
                    Name = customerNames[i],
                    TimeCreate = timeCreate,
                    TimeDelete = 0,
                    TimeUpdate = 0
                };

                listCustomers.Add(customer);
            }

            foreach (Customer customer in listCustomers)
            {
                Console.WriteLine($"Adding {customer.Name}");
                Customer.AddCustomer(customer);
            }

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
