using System;
using System.Collections.Generic;
using System.Text;

namespace MyCoffee.Entities
{
    public class Stock
    {
        public int Id { get; }
        public int Quantity { get; set; }
        public int ProductId { get; set; }

    }
}
