using System;
using System.Collections.Generic;

namespace Saint
{
    class Program
    {
        static void Main(string[] args)
        {
            List<String> wishes = new List<string>() { "good Luck", "marry Christmas", "all the best", "many friends" };
            List<ToyVariant> toysB = new List<ToyVariant>() { ToyVariant.Ball, ToyVariant.Car, ToyVariant.Guitare, ToyVariant.Gun, ToyVariant.Wolf };
            List<ToyVariant> toysG = new List<ToyVariant>() { ToyVariant.Doll, ToyVariant.House, ToyVariant.Rabbit, ToyVariant.Ring };
            List<FoodVariant> foodv = new List<FoodVariant>() { FoodVariant.Apple, FoodVariant.Grapes, FoodVariant.Orange, FoodVariant.Pear, FoodVariant.Pineapple, FoodVariant.Strawberry };

            var s = Nicholas.GetInstance();
            var s1 = Nicholas.GetInstance();//Checking singleton
            s1.builder1 = new BuilderFirstVariant(wishes, toysB, toysG, foodv);
            s1.builder2 = new BuilderSecondVariant(wishes, toysB, toysG, foodv);


            var ch1 = new Child("Marta", Gender.female, 4, 1);
            var ch2 = new Child("Mark", Gender.male, 4, 5);
            var ch3 = new Child("Anton", Gender.male, 4, 3);
            var ch4 = new Child("Mark", Gender.male, 3, 2);

            ch1.ChildGift = s1.GetGift1(ch1.Name, ch1.ChildGender, ch1.GoodDeeds, ch1.BadDeeds);
            ch2.ChildGift = s1.GetGift1(ch2.Name, ch2.ChildGender, ch2.GoodDeeds, ch2.BadDeeds);
            ch3.ChildGift = s1.GetGift1(ch3.Name, ch3.ChildGender, ch3.GoodDeeds, ch3.BadDeeds);
            ch4.ChildGift = s1.GetGift1(ch4.Name, ch4.ChildGender, ch4.GoodDeeds, ch4.BadDeeds);


            Console.WriteLine(ch1.ChildGift);
            Console.WriteLine(ch2.ChildGift);
            Console.WriteLine(ch3.ChildGift);
        }
    }
}
