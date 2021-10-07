using System;
using System.Collections.Generic;
using System.Text;

namespace HomeTask2.classes
{
    class Dairy_products : Product
    {
        private int expirationDate;

        public Dairy_products(string _name, int _weight, double _price, int _expirationDate, DateTime _creationTime) :
            base(_name, _weight, _price, _expirationDate, _creationTime){}

        public Dairy_products() :base(){ }

        public override void Parse(string dataForParse) 
        {
            string[] initialisationUnits = dataForParse.Split();

            try
            {
                base.Parse(initialisationUnits[0] + ' ' + initialisationUnits[1] + ' ' + initialisationUnits[2] + ' ' +
                    initialisationUnits[3] + ' ' + initialisationUnits[4]);
            }
            catch 
            {
                throw;// new Exception($"Impossible to initialise {this.GetType()} object - invalid string for parse");
            }
        }

        public override void ChangePrice(double Percentage, (int, int, int) Coefs)
        {
            base.ChangePrice(Percentage, Coefs);

            if (ExpirationDate < 7)
            {
                base.ChangePrice(Coefs.Item1, Coefs);
            }
            else if (ExpirationDate < 14 && ExpirationDate >= 7)
            {
                base.ChangePrice(Coefs.Item2, Coefs);
            }
            else if (ExpirationDate >= 14)
            {
                base.ChangePrice(Coefs.Item3, Coefs);
            }
        }

        public override bool Equals(Object obj)
        {
            if (this.GetType() == obj.GetType())
            {
                var Second = (Dairy_products)obj;
                return this.Name == Second.Name &&
                        this.Price == Second.Price &&
                        this.Weight == Second.Weight &&
                        this.ExpirationDate == Second.ExpirationDate;
            }

            return false;
        }

        public override string ToString()
        {
            return $"Name: \"{this.Name}\", Weight: {this.Weight}, Price:{this.Price}\n" +
                   $"Expiration date: {this.ExpirationDate}";
        }

        public new Dairy_products Copy()
        {
            return (Dairy_products)this.MemberwiseClone();
        }

    }
}
