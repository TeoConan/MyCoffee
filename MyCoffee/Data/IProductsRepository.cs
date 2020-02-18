using System;
using System.Collections.Generic;
using MyCoffee.Entities;

namespace MyCoffee.Data
{
    //Naming convention ok

    public interface IProductsRepository
    {
		List<Product> GetAllProducts();

        List<Product> GetProductsByName(string name);

		List<Product> GetProductsByCategory(int categoryId);

		Product GetProductById(int id);
    }
}
