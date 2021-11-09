using System;
using System.Collections.Generic;
using System.Text;

namespace Saint
{
    class BuilderFirstVariant : AbstractBuilder
    {
        public BuilderFirstVariant(List<string> wishes, List<ToyVariant> toyVariantsBoys, List<ToyVariant> toyVariantsGirls, List<FoodVariant> foodVariants) : base(wishes, toyVariantsBoys, toyVariantsGirls, foodVariants) { }

        public override void PutFood(Gender gender)
        {
            AbstractGiftGenerator generator = null;
            Random rand = new Random();

            if (gender == Gender.female)
            {
                generator = new GirlGiftGenerator();
            }
            else
            {
                generator = new BoyGiftGenerator();
            }

            this.foodForChild = generator.CreateFood(foodVariants[rand.Next(0, foodVariants.Count)]);
        }

        public override void PutToy(int goodDeeds, int badDeeds, Gender gender)
        {
            AbstractGiftGenerator generator = null;
            Random rand = new Random();

            if (gender == Gender.female)
            {
                generator = new GirlGiftGenerator();
                if (goodDeeds > badDeeds)
                {
                    this.toyForChild = generator.CreateToy(toyVariantsGirls[rand.Next(0, toyVariantsGirls.Count)]);
                }
                else
                {
                    this.toyForChild = generator.CreateToy(ToyVariant.Stick);
                }
            }
            else
            {
                generator = new BoyGiftGenerator();
                if (goodDeeds > badDeeds)
                {
                    this.toyForChild = generator.CreateToy(toyVariantsBoys[rand.Next(0, toyVariantsBoys.Count)]);
                }
                else
                {
                    this.toyForChild = generator.CreateToy(ToyVariant.Stick);
                }
            }
        }

        public override void PutWish(int goodDeeds, int badDeeds, Gender gender, string name)
        {
            AbstractGiftGenerator generator = null;
            Random rand = new Random();

            if (gender == Gender.female)
            {
                generator = new GirlGiftGenerator();
            }
            else
            {
                generator = new BoyGiftGenerator();
            }


            if (goodDeeds < badDeeds)
            {
                this.wishForChild = generator.CreateWish($"{name}, you should be more polite");
            }
            else
            {
                this.wishForChild = generator.CreateWish($"{name} " + wishes[rand.Next(0, wishes.Count)]);
            }
        }

        public override void Refresh()
        {
            this.toyForChild = null;
            this.wishForChild = null;
            this.foodForChild = null;
        }
        public override Gift Build()
        {
            return new Gift(this);
        }
    }
}
