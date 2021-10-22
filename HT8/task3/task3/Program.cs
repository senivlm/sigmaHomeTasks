using System;

namespace task3
{
    class Program
    {
        static void Main(string[] args)
        {
            var lst = StringCollectionManipulate.GetListOfSentenses(@"F:\my_study\sigma\p8\task3\task3\bin\Debug\netcoreapp3.1\SentenseCollection.txt");
            //StringCollectionManipulate.GetNestedBrackets(lst);
            //Console.WriteLine(StringCollectionManipulate.GetNestedBrackets(lst));

            stringSortingOptionDelegate sortingOption = (p1, p2) =>
            {
                if (p1.Length > p2.Length)
                {
                    return 1;
                }
                else if (p1.Length < p2.Length)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            };

            StringCollectionManipulate.SortByLength(lst);


            foreach (var item in lst)
            {
                Console.WriteLine(item);
            }
        }
    }
}
