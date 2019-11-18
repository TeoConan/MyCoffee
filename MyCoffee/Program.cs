using MyCoffee.Data;
using System;

namespace MyCoffee
{
    class Program
    {
        static void Main(string[] args)
        {
            var console = new UserConsole();
        }

        public void TestAddObject()
        {
            Console.WriteLine("Try to add a new entry in database SQLite");

            using (var dboContext = new MCDBContext())
            {

            }
        }
    }
}
