using System;
using System.Collections.Generic;

namespace task1
{Чудово!
    class Program
    {
        public static int SortProductsByPrice(object first, object second) 
        {
            Product p1 =  first as Product;
            Product p2 = second as Product;

            if (p1 == null || p2 == null)
            {
                throw new Exception("Invalid input parameters for 'SortProductsByPrice' method -> parameters should be products");
            }


            if (p1.Price > p2.Price) 
            {
                return 1;
            }
            else if (p1.Price < p2.Price)
            {
                return -1;
            }
            else
            {
                return 0;
            }            
        }

        public static int SortProductsByWeight(object first, object second)
        {
            Product p1 = first as Product;
            Product p2 = second as Product;

            if (p1 == null || p2 == null)
            {
                throw new Exception("Invalid input parameters for 'SortProductsByPrice' method -> parameters should be products");
            }


            if (p1.Weight > p2.Weight)
            {
                return 1;
            }
            else if (p1.Weight < p2.Weight)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        static void Main(string[] args)
        {
            List<Product> productsList = new List<Product>();
            productsList.Add(new Product("Ryaba", 310, 6.98, 10, new DateTime(2021, 10, 4)));
            productsList.Add(new Product("Milk", 420, 29.90, 14, new DateTime(2021, 10, 7)));
            productsList.Add(new Product("Juice", 620, 25.73, 22, new DateTime(2021, 9, 24)));
            productsList.Add(new Product("Sausage", 543, 90.3, 20, new DateTime(2021, 1, 5)));



            Product[] productsArray = productsList.ToArray();
            SpecialisedSort.Sort(productsArray, SortProductsByWeight);
            foreach (var product in productsArray)
            {
                Console.WriteLine(product);
            }

            Console.WriteLine();

            SpecialisedSort.Sort(productsArray, SortProductsByPrice);
            foreach (var product in productsArray)
            {
                Console.WriteLine(product);
            }

        }
    }
}
