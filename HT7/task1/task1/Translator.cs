using System;
using System.Collections.Generic;
using System.Text;

namespace task1
{
    static class Translator
    {
        public static Dictionary<string, string> mainDictionary = new Dictionary<string, string>();


        public static string Translate(string inputText) 
        {
            StringBuilder resultOfTranslation = new StringBuilder();
            string curentSubstring = null;
            int lengthOfWord; 
            int curentChar;


            for (int i = 0; i < inputText.Length; i++)
            {
                if (!Char.IsLetter(inputText[i]))
                {
                    resultOfTranslation.Append(inputText[i]);
                }
                else
                {
                    lengthOfWord = 0;
                    curentChar = i;

                    while (Char.IsLetter(inputText[curentChar]))
                    {
                        lengthOfWord++;
                        curentChar++;

                        if (curentChar == inputText.Length)
                        {
                            break;
                        }
                    }

                    curentSubstring = inputText.Substring(i, lengthOfWord);
                    if (!mainDictionary.ContainsKey(curentSubstring)) 
                    {
                        while (true)
                        {
                            Console.WriteLine($"Enter translation of {curentSubstring}");
                            string userTranslation = Console.ReadLine();

                            Console.WriteLine($"Do you want to translate {curentSubstring} like {userTranslation}?");
                            if (Console.ReadLine().ToLower() == "yes")
                            {
                                mainDictionary.Add(curentSubstring, userTranslation);
                                break;
                            }                            
                        }
                    }

                    resultOfTranslation.Append(mainDictionary[curentSubstring]);
                    i += lengthOfWord - 1;
                }
            }

            return resultOfTranslation.ToString();
        }
    }
}
