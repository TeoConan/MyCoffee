using System;
using System.Collections.Generic;
using System.Text;

namespace MyCoffee.Entities
{
    public class CustomerOrder
    {
        public int Id { get; }
        public int CustomerId { get; set; }
        private float TotalPrice { get; set; }

        public int TimeCreate { private set; get; }
        public int TimeUpdate { private set; get; }
        public int TimeDelete { private set; get; }

        public void calculateTotalPrice()
        {
            TotalPrice = 0;
        }
    }
}