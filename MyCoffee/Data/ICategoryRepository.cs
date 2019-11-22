using MyCoffee.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyCoffee.Data
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> Get();
    }
}
