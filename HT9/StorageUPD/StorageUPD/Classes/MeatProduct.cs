using System;
using System.Collections.Generic;
using System.Text;

namespace StorageUPD
{
    enum Sort
    {
        Greatest = 0,
        First = 1,
        Second = 2
    }

    enum Type
    {
        Lamb,   //Баранина
        Veal,   //Телятина
        Pork,   //Свинина
        Chicken //Курятина
    }

    class MeatProduct : Product
    {
        public MeatProduct(string _name, int _weight, double _price, int _expirationDate, DateTime _creationTime, Sort _sort, Type _type) :
            base(_name, _weight, _price, _expirationDate, _creationTime)
        {
            this.SortOfTheProduct = _sort;
            this.TypeOfTheProduct = _type;
        }

        public MeatProduct() : base() { this.SortOfTheProduct = Sort.Second; this.TypeOfTheProduct = Type.Chicken; }

        public override void Parse(string dataForParse)
        {
            string[] initialisationUnits = dataForParse.Split();

            try
            {
                base.Parse(initialisationUnits[0] + ' ' + initialisationUnits[1] + ' ' + initialisationUnits[2] + ' ' +
                    initialisationUnits[3] + ' ' + initialisationUnits[4]);
            }
            catch(Exception ex)
            {
                throw;// new Exception($"Impossible to initialise {this.GetType()} object - invalid string for parse");
            }

            try
            {
                this.SortOfTheProduct = (Sort)Enum.Parse(typeof(Sort), initialisationUnits[5]);
            }
            catch (Exception)
            {
                throw new Exception($"Impossible to initialise {this.GetType()} object - invalid 'sort parameter");
            }
            try
            {
                this.TypeOfTheProduct = (Type)Enum.Parse(typeof(Type), initialisationUnits[6]);
            }
            catch (Exception)
            {
                throw new Exception($"Impossible to initialise {this.GetType()} object - invalid 'sort parameter");
            }


        }


        private Sort sortOfTheProduct;
        public Sort SortOfTheProduct
        {
            get { return sortOfTheProduct; }
            protected set
            {
                try
                {
                    sortOfTheProduct = value;
                }
                catch (System.Exception e)
                {
                    Console.WriteLine("Impossible to use this Sort.");
                    Console.WriteLine(e.Message);
                }
            }
        }


        private Type typeOfTheProduct;
        public Type TypeOfTheProduct
        {
            get { return typeOfTheProduct; }
            protected set
            {
                try
                {
                    typeOfTheProduct = value;
                }
                catch (System.Exception e)
                {
                    Console.WriteLine("Impossible to use this Sort.");
                    Console.WriteLine(e.Message);
                }
            }
        }

        
        public override void ChangePrice(double Percentage, (int, int, int) Coefs)
        {
            base.ChangePrice(Percentage, Coefs);

            if (SortOfTheProduct == Sort.Greatest)
            {
                base.ChangePrice(Coefs.Item1, Coefs);
            }
            else if (SortOfTheProduct == Sort.First)
            {
                base.ChangePrice(Coefs.Item2, Coefs);
            }
            else if (SortOfTheProduct == Sort.Second)
            {
                base.ChangePrice(Coefs.Item3, Coefs);
            }
        }


        public override int GetHashCode()
        {
            return Name.GetHashCode() + Convert.ToInt32(Weight) +
                   Convert.ToInt32(Price) + Convert.ToInt32(ExpirationDate) +
                   (int)SortOfTheProduct + (int)typeOfTheProduct + CreationTime.Day;
        }

        public override bool Equals(Object obj)
        {
            if (this.GetType() == obj.GetType())
            {
                var Second = (MeatProduct)obj;
                return this.Name == Second.Name &&
                        this.Price == Second.Price &&
                        this.Weight == Second.Weight &&
                        this.SortOfTheProduct == Second.SortOfTheProduct &&
                        this.TypeOfTheProduct == Second.TypeOfTheProduct;
            }

            return false;
        }

        public override string ToString()
        {
            return $"Name: \"{this.Name}\", Weight: {this.Weight}, Price: {this.Price}, " +
                   $"Sort: \"{this.SortOfTheProduct}\", Type: \"{this.TypeOfTheProduct}\"";
        }

        public new MeatProduct Copy()
        {
            return (MeatProduct)this.MemberwiseClone();
        }
    }
}
