using System;

namespace thirdTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Matrix m1 = new Matrix(_rows: 5, _cols: 2);
            m1.RandomInitialise();

            for (int i = 0; i < m1.Rows; i++)
            {
                for (int j = 0; j < m1.Cols; j++)
                {
                    Console.Write(m1[i, j] + "   ");
                }

                Console.WriteLine();
            }

            foreach (var element in m1)
            {
                Console.Write(element + "  ");
            }


        }
    }
}
