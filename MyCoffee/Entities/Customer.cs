using MyCoffee.Data;
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

        public int Id { get; set; }
        public string Name { get; set; }
        public List<CustomerOrder> Orders { get; set; }
        public int TimeCreate { set; get; }
        public int TimeUpdate { set; get; }
        public int TimeDelete { set; get; }


        public static bool AddCustomer(Customer customer)
        {
            using (var dboContext = new MCDBContext())
            {
                dboContext.Customer.Add(customer);
                return (dboContext.SaveChanges() > 0);
            }

            return false;
        }

        public static List<Customer> GetAllCustomer()
        {
            List<Customer> listCustomers = new List<Customer>();

            using (var dboContext = new MCDBContext())
            {
                var DbList = dboContext.Customer;

                foreach (Customer Customer in DbList)
                {
                    listCustomers.Add(Customer);
                }
            }

            return listCustomers;

        }
    }
}
