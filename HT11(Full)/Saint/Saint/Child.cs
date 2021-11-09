using System;
using System.Collections.Generic;
using System.Text;

namespace Saint
{
    class Child
    {
        public string Name { get; private set; }
        public Gender ChildGender { get; private set; }
        public int GoodDeeds { get; private set; }
        public int BadDeeds { get; private set; }
        public Gift ChildGift { get; set; }


        public Child(string name, Gender gender, int goodDeeds, int badDeeds) 
        {
            this.BadDeeds = badDeeds;
            this.GoodDeeds = goodDeeds;
            this.Name = name;
            this.ChildGender = gender;
        }
    }
}
