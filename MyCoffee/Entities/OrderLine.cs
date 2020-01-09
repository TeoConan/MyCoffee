using MyCoffee.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyCoffee.Entities
{
    public class OrderLine
    {
        [Key]
        public int Id { get; private set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        private float Price { get; }

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
                var DbList = dboContext.OrderLine;

                foreach (OrderLine OrderLine in DbList)
                {
                    listOrderLines.Add(OrderLine);
                }
            }

            return listOrderLines;

        }
    }
}