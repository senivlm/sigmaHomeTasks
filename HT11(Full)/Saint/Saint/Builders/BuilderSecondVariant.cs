using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Saint
{
    class BuilderSecondVariant : AbstractBuilder
    {
        public BuilderSecondVariant(List<string> wishes, List<ToyVariant> toyVariantsBoys, List<ToyVariant> toyVariantsGirls, List<FoodVariant> foodVariants) : base(wishes, toyVariantsBoys, toyVariantsGirls, foodVariants)
        {
            giftsIteratorBoys = new GiftsIterator(toyVariantsBoys);
            giftsIteratorGirls = new GiftsIterator(toyVariantsGirls);
        }
        GiftsIterator giftsIteratorBoys = null;
        GiftsIterator giftsIteratorGirls = null;

        public override Gift Build()
        {
            return new Gift(this);
        }

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

                this.toyForChild = generator.CreateToy(giftsIteratorGirls.Current);
                giftsIteratorGirls.MoveNext();
            }
            else
            {
                generator = new BoyGiftGenerator();

                this.toyForChild = generator.CreateToy(giftsIteratorBoys.Current);
                giftsIteratorBoys.MoveNext();
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


            this.wishForChild = generator.CreateWish(wishes[rand.Next(0, wishes.Count)]);
        }

        public override void Refresh()
        {
            this.toyForChild = null;
            this.wishForChild = null;
            this.foodForChild = null;

            this.giftsIteratorBoys.Reset();
            this.giftsIteratorGirls.Reset();
        }


        class GiftsIterator : IEnumerator<ToyVariant>
        {
            private List<ToyVariant> listOfIterator = null;
            private int currentIndex = 0;

            public GiftsIterator(List<ToyVariant> listOfIterator)
            {
                if (listOfIterator == null || listOfIterator.Count == 0)
                {
                    throw new Exception("List of gifts can't be empty");
                }

                this.listOfIterator = listOfIterator;
            }

            public ToyVariant Current => listOfIterator[currentIndex];
            object IEnumerator.Current => listOfIterator[currentIndex];

            public void Dispose()
            {
                //throw new NotImplementedException();
            }

            public bool MoveNext()
            {
                if (++currentIndex > listOfIterator.Count - 1)
                {
                    Reset();
                }

                return true;
            }

            public void Reset()
            {
                currentIndex = 0;
            }
        }
    }
}
