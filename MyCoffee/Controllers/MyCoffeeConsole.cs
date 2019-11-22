using System;
namespace MyCoffee.Controllers
{
    public abstract class MyCoffeeConsole
    {
        public void Echo(string text)
        {
            Console.WriteLine(text);
        }

        public void Clear()
        {
            Console.Clear();
        }
    }
}
