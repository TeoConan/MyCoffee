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

    }
}