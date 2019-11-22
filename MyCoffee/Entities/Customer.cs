using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyCoffee.Entities
{
    public class Customer
    {
        public Customer()
        {
            //Orders = new List<Order>();
        }

        public int Id { get; private set; }
        public string Name { get; set; }
        public List<CustomerOrder> Orders { get; set; }
        public int TimeCreate { private set; get; }
        public int TimeUpdate { private set; get; }
        public int TimeDelete { private set; get; }
    }
}
