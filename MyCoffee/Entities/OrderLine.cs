using System;
using System.Collections.Generic;
using System.Text;

namespace MyCoffee.Entities
{
    public class OrderLine
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        private float Price { get; }
    }
}