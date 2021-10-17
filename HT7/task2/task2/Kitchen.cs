using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Globalization;

namespace task2
{
    class Kitchen
    {
        private Dictionary<string, double> priceBook;
        private Dictionary<string, double> ingredientsRequired;

        public Kitchen() 
        {
            priceBook = new Dictionary<string, double>();
            ingredientsRequired = new Dictionary<string, double>();
        }

        public void GetPrices(string pricesFilePath) 
        {
            try
            {
                using (StreamReader sr = new StreamReader(pricesFilePath))
                {
                    string[] ingredients = sr.ReadToEnd().Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

                    for (int i = 0; i < ingredients.Length; i++)
                    {
                        string ingredient = ingredients[i].Split()[0];
                        double price = Convert.ToDouble(ingredients[i].Split()[1]);

                        this.priceBook.Add(ingredient, price);
                    }
                }
            }
            catch (DirectoryNotFoundException)
            {
                throw new DirectoryNotFoundException("Impossible to open file in Kitchen.GetPrices method");
            }
            catch (FormatException) 
            {
                throw new FormatException("Invalid price data in file (Exception occured in Kitchen.GetPrices method)");
            }
}

        public string GetListOfProducts(string ingredientsFilePath) 
        {
            using (StreamReader sr = new StreamReader(ingredientsFilePath))
            {
                string[] lines = sr.ReadToEnd().Split(new char[] { '\n','\r' }, StringSplitOptions.RemoveEmptyEntries);
                string[] elementsOfLine = null;

                for (int i = 0; i < lines.Length; i++)
                {
                    elementsOfLine = lines[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    if (elementsOfLine.Length == 1)
                    {
                        continue;
                    }

                    if (!ingredientsRequired.ContainsKey(elementsOfLine[0]))
                    {
                        ingredientsRequired.Add(elementsOfLine[0], 0);
                    }
                    try
                    {
                        ingredientsRequired[elementsOfLine[0]] += Convert.ToDouble(elementsOfLine[1], new CultureInfo("en-US"));
                    }
                    catch 
                    {
                        throw new InvalidCastException("CONVETRION Exception in Kitchen.GetListOfProducts method");
                    }
                }
            }


            StringBuilder result = new StringBuilder();

            try
            {
                foreach (string key in ingredientsRequired.Keys)
                {
                    result.Append($"{key} {Math.Round(ingredientsRequired[key], 2)} {Math.Round(ingredientsRequired[key] * priceBook[key], 2)}\n");
                }
            }
            catch (KeyNotFoundException)
            {
                throw new KeyNotFoundException("No such product in prices dictionary");
            }

            return result.ToString();
        }

    }
}
