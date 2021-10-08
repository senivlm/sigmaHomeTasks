using System;

namespace firstTask
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] res = TextChange.FromFile(@"F:\my_study\sigma\p5\fast\fast\bin\Debug\netcoreapp3.1\fl1.txt");
            foreach (var str in res)
            {
                Console.WriteLine(str);
            }
        }
    }
}
