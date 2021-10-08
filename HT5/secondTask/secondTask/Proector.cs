using System;
using System.Collections.Generic;
using System.Text;


namespace secondTask
{
    static class Proector
    {
        public static (int[][], int[][], int[][]) ProectOld(int[][][] model)
        {//this method was written on tuesday and works better for tiny objects
            int m = model.Length;
            int n = model[0].Length;
            int p = model[0][0].Length;


            int[][] proectionXY;
            int[][] proectionYZ;
            int[][] proectionXZ;


            proectionXY = new int[m][];
            for (int i = 0; i < m; i++)
            {
                proectionXY[i] = new int[n];
            }

            proectionYZ = new int[n][];
            for (int i = 0; i < n; i++)
            {
                proectionYZ[i] = new int[p];
            }

            proectionXZ = new int[m][];
            for (int i = 0; i < m; i++)
            {
                proectionXZ[i] = new int[p];
            }


            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    for (int k = 0; k < p; k++)
                    {
                        if (model[i][j][k] == 1)
                        {
                            proectionXY[i][j] = 1;
                            proectionYZ[j][k] = 1;
                            proectionXZ[i][k] = 1;
                        }
                    }
                }
            }

            Console.WriteLine();
            return (proectionXY, proectionYZ, proectionXZ);
        }

        public static (int[][],int[][],int[][]) Proect(int[][][] model) 
        {
            int m = model.Length;
            int n = model[0].Length;
            int p = model[0][0].Length;


            int[][] proectionXY;
            int[][] proectionYZ;
            int[][] proectionXZ;


            proectionXY = new int[m][];
            for (int i = 0; i < m; i++)
            {
                proectionXY[i] = new int[n];
            }

            proectionYZ = new int[n][];
            for (int i = 0; i < n; i++)
            {
                proectionYZ[i] = new int[p];
            }

            proectionXZ = new int[m][];
            for (int i = 0; i <m; i++)
            {
                proectionXZ[i] = new int[p];
            }


            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    for (int k = p - 1; k >= 0; k--) 
                    {
                        if (model[i][j][k] == 1)
                        {
                            proectionXY[i][j] = 1;
                            break;
                        }
                    }
                }
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < p; j++)
                {
                    for (int k = m - 1; k >= 0; k--) 
                    {
                        if (model[k][i][j] == 1)
                        {
                            proectionYZ[i][j] = 1;
                            break;
                        }
                    }
                }
            }

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < p; j++)
                {
                    for (int k = n - 1; k >= 0; k--) 
                    {
                        if (model[i][k][j] == 1)
                        {
                            proectionXZ[i][j] = 1;
                        }
                    }
                }
            }


            Console.WriteLine();
            return (proectionXY, proectionYZ, proectionXZ);
        }

    }
}