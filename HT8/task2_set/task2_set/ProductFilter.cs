using System;
using System.Collections.Generic;
using System.Text;

namespace task2_set
{
    static class ProductFilter
    {
        public static List<Product> GetCommonProducts(Storage storage1, Storage storage2) 
        {
            var productsOfFirstStorage = new HashSet<Product>(storage1);
            var productsOfSecondStorage = new HashSet<Product>(storage2);

            productsOfFirstStorage.IntersectWith(productsOfSecondStorage);
            List<Product> commonProducts = new List<Product>(productsOfFirstStorage.Count);

            foreach (Product product in productsOfFirstStorage)
            {
                commonProducts.Add(product);
            }


            return commonProducts;
        }

        public static List<Product> GetUniqueProductsOfStorage(Storage storage1, Storage storage2)
        {
            var productsOfFirstStorage = new HashSet<Product>(storage1);
            var productsOfSecondStorage = new HashSet<Product>(storage2);

            productsOfFirstStorage.ExceptWith(productsOfSecondStorage);
            List<Product> uniqueProductsOfStorage = new List<Product>(productsOfFirstStorage.Count);

            foreach (Product product in productsOfFirstStorage)
            {
                uniqueProductsOfStorage.Add(product);
            }


            return uniqueProductsOfStorage;
        }

        public static List<Product> GetUniqueProducts(Storage storage1, Storage storage2)
        {
            var productsOfFirstStorage = new HashSet<Product>(storage1);
            var productsOfSecondStorage = new HashSet<Product>(storage2);

            productsOfFirstStorage.UnionWith(productsOfSecondStorage);
            List<Product> uniqueProducts = new List<Product>(productsOfFirstStorage.Count);

            foreach (Product product in productsOfFirstStorage)
            {
                uniqueProducts.Add(product);
            }


            return uniqueProducts;
        }

    }
}
