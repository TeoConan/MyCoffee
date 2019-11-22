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
    }
}