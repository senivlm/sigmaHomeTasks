using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace task3
{
    static class StringCollectionManipulate 
    {
        public static string GetSentanceWithMostNestedBrackets(string filePath) 
        {
            StreamReader streamReader = null;
            try
            {
                streamReader = new StreamReader(filePath);
            }
            catch
            {
                Console.WriteLine("Impossible to open file");
                return null;
            }


            string resultSentance = "";
            StringBuilder currentSentance = new StringBuilder("");
            bool setNewSentance = false;

            int maxAmountOfBrackets = 0;
            int currentAmountOfBrackets = 0;

            string currentLine = streamReader.ReadLine();
            while (currentLine != null)
            {
                foreach (char letter in currentLine) 
                {
                    if (letter == '.')
                    {
                        currentSentance.Append(letter);
                        if (setNewSentance)
                        {
                            resultSentance = currentSentance.ToString();
                        }

                        currentSentance.Clear();
                        currentSentance.Append("");
                        setNewSentance = false;
                    }
                    else if (letter == '(')
                    {
                        currentAmountOfBrackets++;
                        currentSentance.Append(letter);
                    }
                    else if (letter == ')')
                    {
                        if (currentAmountOfBrackets > maxAmountOfBrackets) 
                        {
                            setNewSentance = true;
                            maxAmountOfBrackets = currentAmountOfBrackets;
                        }

                        currentSentance.Append(letter);
                        currentAmountOfBrackets--;
                    }
                    else
                    {
                        currentSentance.Append(letter);
                    }
                }

                currentLine = streamReader.ReadLine();
            }


            streamReader.Close();

            return resultSentance;
        }

        public static List<string> SortStringCollection(string filePath)
        {
            StreamReader streamReader = null;
            try
            {
                streamReader = new StreamReader(filePath);
            }
            catch
            {
                Console.WriteLine("Impossible to open file");
                return null;
            }


            var listOfStrings = new List<string>();

            StringBuilder currentSentance = new StringBuilder();
            string line = streamReader.ReadLine();
            while (line != null)
            {
                foreach (char letter in line)
                {
                    currentSentance.Append(letter);

                    if (letter == '.')
                    {
                        listOfStrings.Add(currentSentance.ToString());
                        currentSentance.Clear();
                    }
                }

                line = streamReader.ReadLine();
            }
            



            streamReader.Close();
            listOfStrings.Sort((s1, s2) => s1.Length.CompareTo(s2.Length));
            return listOfStrings;
        }
    }
}
