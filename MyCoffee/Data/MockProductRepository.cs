using System;
using System.Collections.Generic;
using MyCoffee.Entities;
using System.Linq;

namespace MyCoffee.Data
{
    public class MockProductRepository : IProductsRepository
    {
        private List<Product> _products = new List<Product>
        {
            new Product { Id = 1, CategoryId = 2, Name = "Panini Chelou", Description = "Contenu étrange de sucré-salé", Price = 5 },
            new Product { Id = 2, CategoryId = 2, Name = "Panini Mieux", Description = "Peu import, c'est meilleur", Price = 5 },
            new Product { Id = 3, CategoryId = 1, Name = "Croissant", Description = "C'est juste un croissant", Price = 1.05F }
        };

        public MockProductRepository()
        {
        }

        public IEnumerable<Product> getAllProducts()
        {
            if (_products == null)
            {
                throw new Exception("Aucun produit trouvé");
            }
            return _products;
        }

        public IEnumerable<Product> getProductsByCategory(int categoryId)
        {

            var products = _products.FindAll((product) => product.CategoryId == categoryId);
            if (products == null)
            {
                throw new Exception("Aucun produit trouvé");
            }
            return products;
        }

        public Product getProductByName(string name)
        {
            var product = _products.First((product) => product.Name.Contains(name));
            if (product == null)
            {
                throw new Exception("Aucun produit trouvé");
            }
            return product;
        }

        public Product getProductByid(int id)
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
