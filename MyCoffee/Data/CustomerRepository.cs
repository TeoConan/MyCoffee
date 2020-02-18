using MyCoffee.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyCoffee.Data
{
    class CustomerRepository
    {
        //Naming convention ok

        public bool AddCustomer(Customer customer)
        {
            using (var dboContext = new MCDBContext())
            {
                dboContext.Customer.Add(customer);
                return (dboContext.SaveChanges() > 0);
            }

            return false;
        }

        public List<Customer> GetAllCustomer()
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
