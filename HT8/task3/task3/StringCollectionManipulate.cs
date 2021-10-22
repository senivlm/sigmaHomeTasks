using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace task3
{
    public delegate int stringSortingOptionDelegate(string s1, string s2);
//IComparer<string>    

    static class StringCollectionManipulate
    {
        public static List<String> GetListOfSentenses(string filePath)
        {
            List<String> stringList = new List<string>();

            try
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    stringList.AddRange(sr.ReadToEnd().Split(new char[] { '.' },
                                                            StringSplitOptions.RemoveEmptyEntries));
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Impossible to read from this file");
                return null;
            }

            return stringList;
        }

        public static string GetNestedBrackets(List<String> inputList)
        {
            string sentenceWithMaxBrackets = null;
            int currentCountOfNestedBrackets = 0;
            int maxCountOfNestedBrackets = 0;


            foreach (string sentence in inputList)
            {
                foreach (char letter in sentence)
                {
                    if (letter == '(')
                    {
                        currentCountOfNestedBrackets++;
                    }
                    else if (letter == ')')
                    {
                        if (currentCountOfNestedBrackets > maxCountOfNestedBrackets)
                        {
                            maxCountOfNestedBrackets = currentCountOfNestedBrackets;
                            sentenceWithMaxBrackets = sentence + '.';
                        }

                        currentCountOfNestedBrackets--;
                    }
                }
            }

            return sentenceWithMaxBrackets;
        }

        public static void SortByLength(List<String> inputList) 
        {
            inputList.Sort((p1, p2) =>
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
            }) ;
        }

        
    }
}
