using MyCoffee.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyCoffee.Entities
{
    public class CustomerOrder
    {
        [Key]
        public int Id { get; private set; }
        private float TotalPrice { get; set; }

        public int TimeCreate { private set; get; }
        public int TimeUpdate { private set; get; }
        public int TimeDelete { private set; get; }

        public void calculateTotalPrice()
        {
            TotalPrice = 0;
        }

           public static bool AddCustomerOrder(CustomerOrder customerOrder)
    {
        using (var dboContext = new MCDBContext())
        {
            dboContext.CustomerOrder.Add(customerOrder);
            return (dboContext.SaveChanges() > 0);
        }

        return false;
    }

    public static List<CustomerOrder> GetAllCustomerOrder()
    {
        List<CustomerOrder> listCustomerOrders = new List<CustomerOrder>();

        using (var dboContext = new MCDBContext())
        {
            var DbList = dboContext.CustomerOrder;

            foreach (CustomerOrder CustomerOrder in DbList)
            {
                listCustomerOrders.Add(CustomerOrder);
            }
        }

        return listCustomerOrders;

    }
    }
}