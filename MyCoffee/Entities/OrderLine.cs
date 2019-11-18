using System;
using System.Collections.Generic;
using System.Text;

namespace MyCoffee.Entities
{
    public class OrderLine
    {
        public int Id { get; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        private float Price { get; }

        public int TimeCreate { private set; get; }
        public int TimeUpdate { private set; get; }
        public int TimeDelete { private set; get; }

    }
}