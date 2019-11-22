using MyCoffee.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyCoffee.Data
{
    public class MockCategoryRepository : ICategoryRepository
    {
        public IEnumerable<Category> Get()
        {
            yield return new Category { CategoryId = 0, Value = "Hot drinks" };
            yield return new Category { CategoryId = 1, Value = "Viennoiseries" };
            yield return new Category { CategoryId = 2, Value = "Sandwiches" };
            yield return new Category { CategoryId = 3, Value = "Salads" };
            yield return new Category { CategoryId = 4, Value = "Drinks" };
            yield return new Category { CategoryId = 5, Value = "Snacks" };
            yield return new Category { CategoryId = 6, Value = "Lunch boxes" };
        }
    }
}
