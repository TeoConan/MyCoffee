using System;
using System.Collections.Generic;
using MyCoffee.Entities;
using System.Data.SqlClient;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;

namespace MyCoffee.Data
{
    public class StocksRepository
    {
        public bool AddStock(Stock stock)
        {
            using (var dboContext = new MCDBContext())
            {
                dboContext.Stock.Add(stock);
                return (dboContext.SaveChanges() > 0);
            }

            return false;
        }

        public List<Stock> GetAllStocks()
        {
            List<Stock> listStocks = new List<Stock>();

            using (var dboContext = new MCDBContext())
            {
                var dbList = dboContext.Stock;

                foreach (Stock stock in dbList)
                {
                    listStocks.Add(stock);
                }
            }

            return listStocks;
        }

        public Stock GetStockByProductId(int id)
        {
            var listStocks = this.GetAllStocks();
            var stock = listStocks.Find(stock => stock.ProductId == id);
            if (stock == null)
            {
                return null;
            }
            return stock;
        }

        public int ConvertStringDateToTimeStamp(String date)
        {
            ProductsRepository productsRepository = new ProductsRepository();
            Regex regex = new Regex(@"([0-9]{1,2})\/([0-9]{1,2})\/([0-9]{4})$", RegexOptions.IgnorePatternWhitespace);
            Match match = regex.Match(date);

            if (match.Success)
            {
                int day = Convert.ToInt32(match.Groups[1].Value);
                int month = Convert.ToInt32(match.Groups[2].Value);
                int year = Convert.ToInt32(match.Groups[3].Value);

                var transformDate = new DateTime(year, month, day, 0, 0, 0);
                Int32 unixTimestamp = (Int32)(transformDate.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;

                return unixTimestamp;
            }
            else
            {
                return 0;
            }
        }

        public string ConvertTimeStampToStringDate(int date)
        {
            System.DateTime dateTime = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
            dateTime = dateTime.AddSeconds(date);
            string printDate = dateTime.ToShortDateString();

            return printDate;
        }
    }
}
    