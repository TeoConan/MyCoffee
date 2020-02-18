using System;
using System.Collections.Generic;
using System.Linq;
using MyCoffee.Entities;

namespace MyCoffee.Data
{
    public class ProductsRepository
    {
        public bool AddProduct(Product product)
        {
            using (var dboContext = new MCDBContext())
            {
                dboContext.Product.Add(product);
                return (dboContext.SaveChanges() > 0);
            }

            return false;
        }

        public List<Product> GetAllProducts()
        {
            List<Product> listProducts = new List<Product>();

            using (var dboContext = new MCDBContext())
            {
                var DbList = dboContext.Product;

                foreach (Product product in DbList)
                {
                    listProducts.Add(product);
                }
            }

            return listProducts;

        }

        public Product getProductById(int id)
        {
            var listProducts = this.GetAllProducts();
            var product = listProducts.Find(product => product.Id == id);
            if (product == null)
            {
                return null;
            }
            return product;
        }

        public Product getProductByName(string name)
        {
            var listProducts = this.GetAllProducts();

            var product = listProducts.Find(product => product.Name.ToLower().Contains(name.ToLower()));

            return product;
        }

        public List<Product> getProductsByName(string name)
        {
            var listProducts = this.GetAllProducts();

            var products = listProducts.FindAll((product) => product.Name.ToLower().Contains(name.ToLower()));

            return products;
        }

        public Product getLastProduct()
        {
            var listProducts = this.GetAllProducts();

            var product = listProducts.Last();
            return product;
        }

    }
}