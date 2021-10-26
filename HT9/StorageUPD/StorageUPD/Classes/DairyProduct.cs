using System;
using System.Collections.Generic;
using System.Text;

namespace StorageUPD
{
    class DairyProduct : Product
    {
        private int expirationDate = 0;

        public DairyProduct(string _name, int _weight, double _price, int _expirationDate, DateTime _creationTime) :
            base(_name, _weight, _price, _expirationDate, _creationTime){}

        public DairyProduct() :base(){ }

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


        public override int GetHashCode()
        {
            return Name.GetHashCode() + Convert.ToInt32(Weight) + Convert.ToInt32(Price) + Convert.ToInt32(ExpirationDate) + CreationTime.Day;
        }

        public override bool Equals(Object obj)
        {
            if (this.GetType() == obj.GetType())
            {
                var Second = (DairyProduct)obj;
                return this.Name == Second.Name &&
                        this.Price == Second.Price &&
                        this.Weight == Second.Weight &&
                        this.ExpirationDate == Second.ExpirationDate;
            }

            return false;
        }

        public override string ToString()
        {
            return $"Name: \"{this.Name}\", Weight: {this.Weight}, Price: {this.Price}, " +
                   $"Expiration date: {this.ExpirationDate}";
        }

        public new DairyProduct Copy()
        {
            return (DairyProduct)this.MemberwiseClone();
        }

    }
}
