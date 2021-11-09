using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;


namespace Saint
{
    abstract class AbstractBuilder 
    {
        protected List<string> wishes = null;
        protected List<ToyVariant> toyVariantsBoys = null;
        protected List<ToyVariant> toyVariantsGirls = null;
        protected List<FoodVariant> foodVariants = null;

        public string wishForChild = null;
        public IToy toyForChild = null;
        public IFood foodForChild = null;


        public AbstractBuilder(List<string> wishes, List<ToyVariant> toyVariantsBoys, List<ToyVariant> toyVariantsGirls, List<FoodVariant> foodVariants)
        {
            this.wishes = wishes;
            this.toyVariantsBoys = toyVariantsBoys;
            this.toyVariantsGirls = toyVariantsGirls;
            this.foodVariants = foodVariants;
        }

        abstract public void PutToy(int goodDeeds, int badDeeds, Gender gender);

        abstract public void PutFood(Gender gender);

        abstract public void PutWish(int goodDeeds, int badDeeds, Gender gender, string name);

        abstract public void Refresh();

        public abstract Gift Build();
    }
}
