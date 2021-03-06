using MyCoffee.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyCoffee.Entities
{
    public class OrderLine
    {
        //Naming convention ok

        [Key]
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set;  }

        public int TimeCreate { private set; get; }
        public int TimeUpdate { private set; get; }
        public int TimeDelete { private set; get; }

        public static bool AddOrderLine(OrderLine orderLine)
        {
            using (var dboContext = new MCDBContext())
            {
                dboContext.OrderLine.Add(orderLine);
                return (dboContext.SaveChanges() > 0);
            }

            return false;
        }

        public static List<OrderLine> GetAllOrderLine()
        {
            List<OrderLine> listOrderLines = new List<OrderLine>();

            using (var dboContext = new MCDBContext())
            {
                var dbList = dboContext.OrderLine;

                foreach (OrderLine OrderLine in dbList)
                {
                    listOrderLines.Add(OrderLine);
                }
            }

            return listOrderLines;

        }
    }
}