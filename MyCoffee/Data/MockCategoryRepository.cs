using MyCoffee.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace MyCoffee.Data
{
    public class MockCategoryRepository : ICategoryRepository
    {
        private List<Category> _categories = new List<Category>
        {
            new Category { Id = 0, Name = "Hot drinks" },
            new Category { Id = 1, Name = "Viennoiseries" },
            new Category { Id = 2, Name = "Sandwiches" },
            new Category { Id = 3, Name = "Salads" },
            new Category { Id = 4, Name = "Drinks" },
            new Category { Id = 5, Name = "Snacks" },
            new Category { Id = 6, Name = "Lunch boxes" }
        };

        public string GetCategoryLabel(int id)
        {
            var category = _categories.First((category) => category.Id == id);
            if (category == null)
            {
                return "Catégorie non trouvée.";
            }
            return category.Name;
        }

        public List<Category> GetAllCategories()
        {
            if (_categories == null)
            {
                throw new Exception("Aucune catégorie trouvée.");
            }
            return _categories;
        }
    }
}
