using MyCoffee.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyCoffee.Entities
{
    public class Customer
    {
        //Naming convention ok

        public Customer()
        {
            //Orders = new List<Order>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public List<CustomerOrder> Orders { get; set; }
        public int TimeCreate { set; get; }
        public int TimeUpdate { set; get; }
        public int TimeDelete { set; get; }

    }
}
