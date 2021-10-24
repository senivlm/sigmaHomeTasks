using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Text;
namespace task2_set
{
    class Program
    {
        static void Main(string[] args)
        {
            var s1 = new Storage();
            var s2 = new Storage();

            s1.StartFileInitialisation(@"F:\my_study\sigma\p8\task2_set\task2_set\bin\Debug\netcoreapp3.1\storageInit1.txt");
            s2.StartFileInitialisation(@"F:\my_study\sigma\p8\task2_set\task2_set\bin\Debug\netcoreapp3.1\storageInit2.txt");


            foreach (var item in ProductFilter.GetAllSortedProducts(s1, s2, new ProductFilter.ProductComparator.CompareByPrice()))
            {
                Console.WriteLine(item);
            }


            var productComparator = new ProductFilter.ProductComparator.CompareByName();
            ProductFilter.ProductComparatorOption delegateOfComparison = productComparator.Compare;

            foreach (var item in ProductFilter.GetAllSortedProductsDelegate(s1, s2, delegateOfComparison))
            {
                Console.WriteLine(item);
            }


            Console.WriteLine();

        }
    }
}
