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
                k1.SetPrices(@"F:\my_study\sigma\p7\task2\task2\bin\Debug\netcoreapp3.1\Prices.txt");
                k1.SetRequiredProducts(@"F:\my_study\sigma\p7\task2\task2\bin\Debug\netcoreapp3.1\Menu.txt");

                ;
                Console.WriteLine(Kitchen.CalculateRequirments(k1));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
