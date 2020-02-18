using MyCoffee.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyCoffee.Entities
{
    public class CustomerOrder
    {
        //Naming convention ok

        [Key]
        public int Id { get; set; }
        public float TotalPrice { get; set; }

        public int CustomerId { get; set; }

        public List<OrderLine> Lines { get; set; }

        public int TimeCreate { set; get; }
        public int TimeUpdate { set; get; }
        public int TimeDelete { set; get; }

        public void CalculateTotalPrice()
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