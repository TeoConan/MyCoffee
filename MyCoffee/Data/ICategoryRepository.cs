using MyCoffee.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyCoffee.Data
{
    //Naming convention ok

    public interface ICategoryRepository
    {
        string GetCategoryLabel(int id);
    }
}
