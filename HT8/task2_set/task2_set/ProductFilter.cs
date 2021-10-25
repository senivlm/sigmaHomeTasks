using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace task2_set
{
    static class ProductFilter
    {
        public static class ProductComparator
        {
            public class CompareByPrice : IComparer<Product>
            {
                public int Compare([AllowNull] Product x, [AllowNull] Product y)
                {
                    if (x.Price > y.Price)
                    {
                        return 1;
                    }
                    else if (x.Price < y.Price)
                    {
                        return -1;
                    }
                    else
                    {
                        return 0;
                    }
                }
            }

            public class CompareByName : IComparer<Product>
            {
                public int Compare([AllowNull] Product x, [AllowNull] Product y)
                {
                    return x.Name.CompareTo(y.Name);
                }
            }
        }


        public delegate int ProductComparatorOption([AllowNull] Product x, [AllowNull] Product y);

        public class ReturnComparer : IComparer<Product>
        {
            private ProductComparatorOption ComparionOption = null;

            public ReturnComparer(ProductComparatorOption _option)
            {
                ComparionOption = _option;
            }

            public int Compare([AllowNull] Product x, [AllowNull] Product y)
            {
                return ComparionOption(x, y);
            }
        }


        #region SortedSetWithComparerRegion
        public static List<Product> GetCommonSortedProducts(Storage storage1, Storage storage2, IComparer<Product> comparer)
        {Поясніть, як працює цей конструктор з користувацьким класом
            var productsOfFirstStorage = new SortedSet<Product>(storage1, comparer);
            var productsOfSecondStorage = new SortedSet<Product>(storage2, comparer);

            productsOfFirstStorage.IntersectWith(productsOfSecondStorage);
            List<Product> commonProducts = new List<Product>(productsOfFirstStorage.Count);

            foreach (Product product in productsOfFirstStorage)
            {
                commonProducts.Add(product);
            }


            return commonProducts;
        }

        public static List<Product> GetUniqueSortedProductsOfStorage(Storage storage1, Storage storage2, IComparer<Product> comparer)
        {
            var productsOfFirstStorage = new SortedSet<Product>(storage1, comparer);
            var productsOfSecondStorage = new SortedSet<Product>(storage2, comparer);

            productsOfFirstStorage.ExceptWith(productsOfSecondStorage);
            List<Product> uniqueProductsOfStorage = new List<Product>(productsOfFirstStorage.Count);

            foreach (Product product in productsOfFirstStorage)
            {
                uniqueProductsOfStorage.Add(product);
            }


            return uniqueProductsOfStorage;
        }

        public static List<Product> GetAllSortedProducts(Storage storage1, Storage storage2, IComparer<Product> comparer)
        {
            var productsOfFirstStorage = new SortedSet<Product>(storage1, comparer);
            var productsOfSecondStorage = new SortedSet<Product>(storage2, comparer);

            productsOfFirstStorage.UnionWith(productsOfSecondStorage);
            List<Product> allProducts = new List<Product>(productsOfFirstStorage.Count);

            foreach (Product product in productsOfFirstStorage)
            {
                allProducts.Add(product);
            }


            return allProducts;
        }

        #endregion

        #region SortedSetWithDelegateRegion
        public static List<Product> GetCommonSortedProductsDelegate(Storage storage1, Storage storage2, ProductComparatorOption deleg)
        {
            var productsOfFirstStorage = new SortedSet<Product>(storage1, new ReturnComparer(deleg));
            var productsOfSecondStorage = new SortedSet<Product>(storage2, new ReturnComparer(deleg));

            productsOfFirstStorage.IntersectWith(productsOfSecondStorage);
            List<Product> commonProducts = new List<Product>(productsOfFirstStorage.Count);

            foreach (Product product in productsOfFirstStorage)
            {
                commonProducts.Add(product);
            }


            return commonProducts;
        }

        public static List<Product> GetUniqueSortedProductsOfStorageDelegate(Storage storage1, Storage storage2, ProductComparatorOption deleg)
        {
            var productsOfFirstStorage = new SortedSet<Product>(storage1, new ReturnComparer(deleg));
            var productsOfSecondStorage = new SortedSet<Product>(storage2, new ReturnComparer(deleg));

            productsOfFirstStorage.ExceptWith(productsOfSecondStorage);
            List<Product> uniqueProductsOfStorage = new List<Product>(productsOfFirstStorage.Count);

            foreach (Product product in productsOfFirstStorage)
            {
                uniqueProductsOfStorage.Add(product);
            }


            return uniqueProductsOfStorage;
        }

        public static List<Product> GetAllSortedProductsDelegate(Storage storage1, Storage storage2, ProductComparatorOption deleg)
        {
            var productsOfFirstStorage = new SortedSet<Product>(storage1, new ReturnComparer(deleg));
            var productsOfSecondStorage = new SortedSet<Product>(storage2, new ReturnComparer(deleg));

            productsOfFirstStorage.UnionWith(productsOfSecondStorage);
            List<Product> allProducts = new List<Product>(productsOfFirstStorage.Count);

            foreach (Product product in productsOfFirstStorage)
            {
                allProducts.Add(product);
            }


            return allProducts;
        }

        #endregion

        #region HashSetMethods
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

        public static List<Product> GetAllProducts(Storage storage1, Storage storage2)
        {
            var productsOfFirstStorage = new HashSet<Product>(storage1);
            var productsOfSecondStorage = new HashSet<Product>(storage2);

            productsOfFirstStorage.UnionWith(productsOfSecondStorage);
            List<Product> allProducts = new List<Product>(productsOfFirstStorage.Count);

            foreach (Product product in productsOfFirstStorage)
            {
                allProducts.Add(product);
            }


            return allProducts;
        }
        #endregion
    }
}
