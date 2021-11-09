using System;
using System.Collections.Generic;
using System.Text;

namespace Saint
{
    class BoyGiftGenerator : AbstractGiftGenerator
    {
        public IFood CreateFood(FoodVariant variant)
        {
            Random rand = new Random();

            return new Food(variant, rand.Next(10, 80), "Food for boy");
        }

        public IToy CreateToy(ToyVariant variant)
        {
            Random rand = new Random();

            return new Toy(variant, rand.Next(10, 80), "Toy for boy");
        }

        public string CreateWish(string wish)
        {
            return $"My dear boy, {wish}";
        }
    }
}
