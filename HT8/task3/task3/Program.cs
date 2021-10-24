using System;

namespace task3
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = StringCollectionManipulate.GetSentanceWithMostNestedBrackets(@"F:\my_study\sigma\p8\task3\task3\bin\Debug\netcoreapp3.1\SentenseCollection.txt");

            Console.WriteLine(s);
            Console.WriteLine();

            foreach (var item in StringCollectionManipulate.SortStringCollection(@"F:\my_study\sigma\p8\task3\task3\bin\Debug\netcoreapp3.1\SentenseCollection.txt"))
            {
                Console.WriteLine(item);
            }
        }
    }
}
