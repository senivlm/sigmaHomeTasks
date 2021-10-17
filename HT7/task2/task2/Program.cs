using System;

namespace task2
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var k1 = new Kitchen();
                k1.GetPrices(@"F:\my_study\sigma\p7\task2\task2\bin\Debug\netcoreapp3.1\Prices.txt");
                Console.WriteLine(k1.GetListOfProducts(@"F:\my_study\sigma\p7\task2\task2\bin\Debug\netcoreapp3.1\Menu.txt"));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
