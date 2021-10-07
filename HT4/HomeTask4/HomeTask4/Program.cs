using System;
using HomeTask2.classes;


namespace HomeTask4
{
    class Program
    {
        static void Main(string[] args)
        {
            Product p1 = new Product();

            //p1.Parse("Moloko 420 29,9014 04.11.2021");
            Dairy_products d1 = new Dairy_products();
            //d1.Parse("Moloko 420 29,90 14 04.11.2021");

            Meat m1 = new Meat();
            //m1.Parse("Ryaba 310 6,98 10 4.10.2021 First Chicken");

            Storage s1 = new Storage();

            //s1.StartSlowInitialisation();
            s1.StartFileInitialisation(@"F:\my_study\sigma\p4\HomeTask4\HomeTask4\bin\Debug\netcoreapp3.1\storageInit.txt");


            s1.GetBadDairyProducts(@"F:\my_study\sigma\p4\HomeTask4\HomeTask4\bin\Debug\netcoreapp3.1\badProd.txt");
        }
    }
}
