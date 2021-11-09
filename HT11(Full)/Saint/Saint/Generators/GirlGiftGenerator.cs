using System;
using System.Collections.Generic;
using System.Text;

namespace Saint
{
    class GirlGiftGenerator : AbstractGiftGenerator
    {
        public IFood CreateFood(FoodVariant variant)
        {
            Random rand = new Random();

            return new Food(variant, rand.Next(10, 80), "Food for girl");
        }

        public IToy CreateToy(ToyVariant variant)
        {
            Random rand = new Random();

            return new Toy(variant, rand.Next(10, 80), "Toy for girl");
        }

        public string CreateWish(string wish)
        {
            return $"My dear girl, {wish}";
        }
    }
}
