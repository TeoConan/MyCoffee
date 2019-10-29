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
        //public List<Order> Orders { get; set; }
    }
}
