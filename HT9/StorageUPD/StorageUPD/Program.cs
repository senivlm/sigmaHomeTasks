using System;

namespace StorageUPD
{
    class Program
    {
        static void Main(string[] args)
        {
            var s1 = new Storage();           

            s1.invalidProductInitialisation += LogFileWriteEvent.WriteInLogTXT;
            s1.invalidProductInitialisation += Storage.UserInitialisation;
            s1.getBadDairyProductsEvent += DairyProductsHandlers.WriteInConsole;
            s1.getBadDairyProductsEvent += DairyProductsHandlers.WriteInLogTXT;

            s1.StartFileInitialisation(@"F:\my_study\sigma\p9\StorageUPD\storageInit1.txt");

            //s1.AddProduct(null);
            //s1.CreateProduct();
            //s1.DeleteProductByName("Millk");

            //Console.WriteLine(s1.SearchProduct("Weight", "543"));
            //s1.AddRange(new Product[] { null});
            s1.DeleteBadDairyProducts();

            Console.WriteLine();

            foreach (Product product in s1)
            {
                Console.WriteLine(product);
            }
        }
    }
}
