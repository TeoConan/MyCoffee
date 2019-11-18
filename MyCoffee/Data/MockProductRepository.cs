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
            return null;
        }

        public IEnumerable<Product> getProductsByCategory(int categoryId)
        {
            return null;
        }

        public Product getProductByName(string name)
        {
            throw new NotImplementedException();
        }

        public Product getProductByid(int id)
        {
            throw new NotImplementedException();
        }
    }
}
