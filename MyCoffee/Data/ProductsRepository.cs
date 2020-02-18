using System;
using System.Collections.Generic;
using MyCoffee.Entities;

namespace MyCoffee.Data
{
    public class ProductsRepository
    {
        //Naming convention ok

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
                var dbList = dboContext.Product;

                foreach (Product product in dbList)
                {
                    listProducts.Add(product);
                }
            }

            return listProducts;

        }

        public Product GetProductById(int id)
        {
            var listProducts = this.GetAllProducts();
            var product = listProducts.Find(product => product.Id == id);
            if (product == null)
            {
                return null;
            }
            return product;
        }

        public Product GetProductByName(string name)
        {
            var listProducts = this.GetAllProducts();

            var product = listProducts.Find(product => product.Name.ToLower().Contains(name.ToLower()));

            return product;
        }

        public List<Product> GetProductsByName(string name)
        {
            var listProducts = this.GetAllProducts();

            var products = listProducts.FindAll((product) => product.Name.ToLower().Contains(name.ToLower()));

            return products;
        }

        public List<Product> GetProductsByCategory(int categoryId)
        {
            List<Product> listProducts = new List<Product>();

            using (var dboContext = new MCDBContext())
            {
                var dbList = dboContext.Product;

                foreach (Product product in dbList)
                {
                    if (product.CategoryId == categoryId)
                    {
                        listProducts.Add(product);
                    }
                }
            }

            return listProducts;
        }
    }
}