using System;
using System.Collections.Generic;
using MyCoffee.Entities;

namespace MyCoffee.Data
{
    public interface IProductsRepository
    {
		List<Product> getAllProducts();

        List<Product> getProductsByName(string name);

		List<Product> getProductsByCategory(int categoryId);

		Product getProductById(int id);
    }
}
