using System;
using System.Collections.Generic;
using MyCoffee.Entities;
using System.Linq;

//TODO Changer les noms des méthodes pour mettre des majuscules au début.

namespace MyCoffee.Data
{
    public class MockProductRepository : IProductsRepository
    {
        //Naming convention ok

        private List<Product> _products = new List<Product>
        {
            new Product { Id = 1, CategoryId = 2, Name = "Panini Chelou", Description = "Contenu étrange de sucré-salé", Price = 5 },
            new Product { Id = 2, CategoryId = 2, Name = "Panini Mieux", Description = "Peu import, c'est meilleur", Price = 5 },
            new Product { Id = 3, CategoryId = 1, Name = "Croissant", Description = "C'est juste un croissant", Price = 1.05F },
            new Product { Id = 4, CategoryId = 5, Name = "Brownie", Description = "erverv", Price = 0.99F },
            new Product { Id = 5, CategoryId = 5, Name = "Muffin", Description = "ervzrtb", Price = 1F },
            new Product { Id = 6, CategoryId = 6, Name = "PastaBox Bolo", Description = "dsdfgfngh,fj;gk", Price = 6.60F },
            new Product { Id = 7, CategoryId = 6, Name = "Pizza 4 fromages", Description = "dfbs", Price = 7.90F },
            new Product { Id = 8, CategoryId = 4, Name = "Ice Tea", Description = "qr", Price = 4.55F },
            new Product { Id = 9, CategoryId = 3, Name = "Salade Piedmontaise", Description = "qrdqdb", Price = 8.45F },
            new Product { Id = 10, CategoryId = 5, Name = "Snicker", Description = "qdvqrv", Price = 1.45F },
            new Product { Id = 11, CategoryId = 0, Name = "Café", Description = "qrgrqbn", Price = 99F }
        };

        public MockProductRepository()
        {
        }

        public List<Product> GetAllProducts()
        {
            if (_products == null)
            {
                throw new Exception("Aucun produit trouvé");
            }
            return _products;
        }

        public List<Product> GetProductsByCategory(int categoryId)
        {

            var products = _products.FindAll((product) => product.CategoryId == categoryId);
            if (products == null)
            {
                throw new Exception("Aucun produit trouvé");
            }
            return products;
        }

        public List<Product> GetProductsByName(string name)
        {
            var products = _products.FindAll((product) => product.Name.Contains(name));
            if (products == null)
            {
                throw new Exception("Aucun produit trouvé");
            }
            return products;
        }

        public Product GetProductByName(string name)
        {
            var product = _products.First((product) => product.Name.ToLower().Contains(name.ToLower()));
            if (product == null)
            {
                throw new Exception("Aucun produit trouvé");
            }
            return product;
        }

        public Product GetProductById(int id)
        {
            var product = _products.First((product) => product.Id == id);
            if (product == null)
            {
                throw new Exception("Aucun produit trouvé");
            }
            return product;
        }
    }
}
