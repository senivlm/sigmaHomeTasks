using System;
using System.Collections.Generic;
using System.Text;

namespace Saint
{
    public interface IFood
    {
        string ToString();
    }

    public class Food : IFood
    {
        public FoodVariant foodVariant { get; private set; }
        public int Price { get; private set; }
        public string Purpose { get; private set; }

        public Food(FoodVariant foodVariant, int Price, string Purpose)
        {
            this.foodVariant = foodVariant;
            this.Price = Price;
            this.Purpose = Purpose;
        }

        public override string ToString()
        {
            return $"Food: {foodVariant}, price: {Price}, purpose: {Purpose}";
        }
    }
}