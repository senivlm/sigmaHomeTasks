using System;
using System.Collections.Generic;
using System.Text;
using System.IO;


namespace firstTask
{
    static class TextChange
    {
        public static string[] FromFile(string filePath)
        {
            using (StreamReader sr = new StreamReader(filePath, Encoding.UTF8))
            {
                string[] Sentenses = sr.ReadToEnd().Split("\n", StringSplitOptions.RemoveEmptyEntries);
                string[] sentansesResult = new string[Sentenses.Length];

                int lengthOfUsedArray = 0;
                List<int> positions = new List<int>();


                for (int i = 0; i < Sentenses.Length; i++)
                {
                    for (int j = 0; j < Sentenses[i].Length; j++)
                    {
                        if (Sentenses[i][j] == '#')
                        {
                            positions.Add(lengthOfUsedArray + j);
                        }
                    }

                    lengthOfUsedArray += Sentenses[i].Length;
                }


                int lengthOfCurrentSubarray = 0;
                StringBuilder curentSubstring = new StringBuilder();
                int leftSharpPosition = positions[(positions.Count) / 2];


                for (int i = 0; i < Sentenses.Length; i++)
                {
                    for (int j = 0; j < Sentenses[i].Length; j++)
                    {
                        if (Sentenses[i][j] != '#')
                        {
                            curentSubstring.Append(Sentenses[i][j]);
                        }
                        else if ((j + lengthOfCurrentSubarray) < leftSharpPosition)
                        {
                            curentSubstring.Append('<');
                        }
                        else
                        {
                            curentSubstring.Append('>');
                        }
                    }

                    lengthOfCurrentSubarray += Sentenses[i].Length;
                    sentansesResult[i] = curentSubstring.ToString();
                    curentSubstring.Clear();
                }

                return sentansesResult;
            }
        }
    }
}
