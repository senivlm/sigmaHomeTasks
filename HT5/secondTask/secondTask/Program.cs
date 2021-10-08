using System;

namespace secondTask
{
    class Program
    {
        static void Main(string[] args)
        {
            int m, n, p;
            int[][][] model = null;

            m = Convert.ToInt32(Console.ReadLine());
            n = Convert.ToInt32(Console.ReadLine());
            p = Convert.ToInt32(Console.ReadLine());

            m++;n++;p++;


            model = new int[m][][];

            for (int i = 0; i < m; i++)
            {
                model[i] = new int[n][];
                for (int j = 0; j < n; j++)
                {
                    model[i][j] = new int[p];
                }
            }


            model[1][2][2] = 1;
            model[0][1][0] = 1;


            Proector.ProectOld(model);
            Proector.Proect(model);
        }
    }
}
