using System;
using System.Collections.Generic;
using System.Text;

namespace Saint
{
    public interface AbstractGiftGenerator
    {
        IToy CreateToy(ToyVariant variant);
        IFood CreateFood(FoodVariant variant);
        string CreateWish(string wish);
    }
}
