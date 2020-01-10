using MyCoffee.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyCoffee.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }

        public int TimeCreate { private set; get; }
        public int TimeUpdate { private set; get; }
        public int TimeDelete { private set; get; }

        public Product()
        {

            
        }

        public static bool AddProduct(Product product)
        {
            using (var dboContext = new MCDBContext())
            {
                dboContext.Product.Add(product);
                return (dboContext.SaveChanges() > 0);
            }

            return false;   
        }

        public static List<Product> GetAllProducts()
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

        public static Product getProductById(int id)
        {
            var listProducts = Product.GetAllProducts();
            var product = listProducts.Find(product => product.Id == id);
            if (product == null)
            {
                return null;
            }
            return product;
        }

        public static Product getProductByName(string name)
        {
            var listProducts = Product.GetAllProducts();
            var product = listProducts.Find(product => product.Name.ToLower().Contains(name.ToLower()));
            if (product == null)
            {
                return null;
            }
            return product;
        }
    }
}
