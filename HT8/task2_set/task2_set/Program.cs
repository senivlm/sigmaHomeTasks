using System;

namespace task2_set
{
    class Program
    {
        static void Main(string[] args)
        {
            //F:\my_study\sigma\p4\forGit\HomeTask4\HomeTask4\bin\Debug\netcoreapp3.1\storageInit1.txt
            //F:\my_study\sigma\p4\forGit\HomeTask4\HomeTask4\bin\Debug\netcoreapp3.1\storageInit2.txt

            var s1 = new Storage();
            var s2 = new Storage();

            s1.StartFileInitialisation(@"F:\my_study\sigma\p4\forGit\HomeTask4\HomeTask4\bin\Debug\netcoreapp3.1\storageInit1.txt");
            s2.StartFileInitialisation(@"F:\my_study\sigma\p4\forGit\HomeTask4\HomeTask4\bin\Debug\netcoreapp3.1\storageInit2.txt");

            foreach (var item in ProductFilter.GetUniqueProducts(s1, s2)) 
            {
                Console.WriteLine(item);
            }



            Console.WriteLine();

        }
    }
}
