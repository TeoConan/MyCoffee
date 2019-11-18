using System;
using System.Collections.Generic;
using System.Text;

namespace MyCoffee.Entities
{
    public class Customer
    {
        public Customer()
        {
            //Orders = new List<Order>();
        }

        public int CustomerId { get; }
        public string Name { get; set; }
        public float Balance { get; set; }
        public List<CustomerOrder> Orders { get; set; }
        public int TimeCreate { private set; get; }
        public int TimeUpdate { private set; get; }
        public int TimeDelete { private set; get; }
    }
}
