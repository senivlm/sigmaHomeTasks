﻿using System;
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
Чому побуквенно працюєте зі словами, не застосовуючи метод Split?

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
                    Тут має бути цикл!
                    if (!mainDictionary.ContainsKey(curentSubstring)) 
                    {
                        Console.WriteLine($"Enter translation of {curentSubstring}");
                        mainDictionary.Add(curentSubstring,  Console.ReadLine());
                    }

                    resultOfTranslation.Append(mainDictionary[curentSubstring]);
                    i += lengthOfWord - 1;
                }
            }

            return resultOfTranslation.ToString();
        }
    }
}
