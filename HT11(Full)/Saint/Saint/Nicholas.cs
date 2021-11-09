using System;
using System.Collections.Generic;
using System.Text;

namespace Saint
{
    class Nicholas
    {
        private static Nicholas instance = null;

        private Nicholas() 
        { }

        static Nicholas()
        {
            instance = new Nicholas();
        }

        public static Nicholas GetInstance() 
        {
            return instance;
        }

        public AbstractBuilder builder1 { get; set; }
        public AbstractBuilder builder2 { get; set; }


        public Gift GetGift1(string name, Gender gender, int goodDeeds, int badDeeds) 
        {
            builder1.PutFood(gender);
            builder1.PutToy(goodDeeds, badDeeds, gender);
            builder1.PutWish(goodDeeds, badDeeds, gender, name);

            return builder1.Build();
        }

        public Gift GetGift2(string name, Gender gender, int goodDeeds, int badDeeds)
        {
            builder2.PutFood(gender);
            builder2.PutToy(goodDeeds, badDeeds, gender);
            builder2.PutWish(goodDeeds, badDeeds, gender, name);

            return builder2.Build();
        }
    }
}
