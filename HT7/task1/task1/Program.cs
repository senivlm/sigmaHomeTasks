using System;
using System.Collections.Generic;

namespace task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Translator.mainDictionary.Add("i", "he");
            Translator.mainDictionary.Add("go", "runs");
            Translator.mainDictionary.Add("to", "at");
            Translator.mainDictionary.Add("the", "a");
            Translator.mainDictionary.Add("school", "class");
            Translator.mainDictionary.Add("today", "now");

            string text = "i go to<  the school John today! sometimes. i";

            Console.WriteLine(text);
            Console.WriteLine(Translator.Translate(text));

            //Translator.mainDictionary.Add("I", "boy");
            //Translator.mainDictionary.Add("go", "runs");
            //Translator.mainDictionary.Add("to", "to");
            //Translator.mainDictionary.Add("school", "cinema");

            //Console.WriteLine(Translator.Translate("I go to school.Girl runs to school"));

        }
    }
}
