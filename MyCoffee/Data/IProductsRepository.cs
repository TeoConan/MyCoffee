using System;
using System.Collections.Generic;
using MyCoffee.Entities;

namespace MyCoffee.Data
{
    public interface IProductsRepository
    {
		IEnumerable<Product> getAllProducts();

        IEnumerable<Product> getProductsByName(string name);

		IEnumerable<Product> getProductsByCategory(int categoryId);

		Product getProductByid(int id);
    }
}
