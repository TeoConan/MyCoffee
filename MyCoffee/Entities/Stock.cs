using MyCoffee.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyCoffee.Entities
{
    public class Stock
    {
        //Naming convention ok

        [Key]
        public int Id { get; private set; }
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public int Expiry { get; set; }
        public int TimeCreate { private set; get; }
        public int TimeUpdate { private set; get; }
        public int TimeDelete { private set; get; }

        public static bool AddStock(Stock stock)
        {
            using (var dboContext = new MCDBContext())
            {
                dboContext.Stock.Add(stock);
                return (dboContext.SaveChanges() > 0);
            }

            return false;
        }

        public static List<Stock> GetAllStock()
        {
            List<Stock> listStocks = new List<Stock>();

            using (var dboContext = new MCDBContext())
            {
                var dbList = dboContext.Stock;

                foreach (Stock Stock in dbList)
                {
                    listStocks.Add(Stock);
                }
            }

            return listStocks;

        }
    }
}
