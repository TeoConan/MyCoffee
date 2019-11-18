using System;
using System.Collections.Generic;
using System.Text;

namespace MyCoffee.Entities
{
    public class Order
    {
        public int Id { get; }
        public int CustomerId { get; set; }
        private float TotalPrice { get; set; }

        public void calculateTotalPrice()
        {
            TotalPrice = 0;
        }
    }
}