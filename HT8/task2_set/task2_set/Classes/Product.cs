using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace task2_set
{
    public class Product
    {
        public Product(string _name, int _weight, double _price, int _expirationDate, DateTime _creationTime)
        {
            this.Name = _name;
            this.Price = _price;
            this.Weight = _weight;
            this.expirationDate = _expirationDate;
            this.creationTime = _creationTime;
        }

        public Product() : this(_name: "NAME", _weight: 0, _price: 0, _expirationDate: 1, _creationTime: DateTime.Now) { }

        public virtual void Parse(string dataForParse) 
        {
            string[] initialisationUnits = dataForParse.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            if (initialisationUnits.Length != 5)
            {
                throw new Exception($"Impossible to initialise {this.GetType()} object - invalid string for parse");
            }

            this.Name = initialisationUnits[0];

            try
            {
                this.Weight = Convert.ToInt32(initialisationUnits[1]);
            }
            catch (Exception ex)
            {
                throw new Exception($"Impossible to initialise {this.GetType()} object - invalid 'weight' parameter");
            }
            try
            {
                this.Price = Convert.ToDouble(initialisationUnits[2]);
            }
            catch (Exception ex)
            {
                throw new Exception($"Impossible to initialise {this.GetType()} object - invalid 'price' parameter");
            }
            try
            {
                this.ExpirationDate = Convert.ToInt32(initialisationUnits[3]);
            }
            catch (Exception ex)
            {
                throw new Exception($"Impossible to initialise {this.GetType()} object - invalid 'expiration date' parameter");
            }
            try
            {
                this.CreationTime = DateTime.Parse(initialisationUnits[4]);
            }
            catch (Exception ex)
            {
                throw new Exception($"Impossible to initialise {this.GetType()} object - invalid 'creation time' parameter");
            }
        }


        int expirationDate;
        public int ExpirationDate 
        {
            get 
            {
                return expirationDate;
            }
            set 
            {
                if (value > 0)
                {
                    expirationDate = value;
                }
            }
        }


        private DateTime creationTime;
        public DateTime CreationTime
        {
            get { return creationTime; }
            private set { creationTime = value; }
        }


        private string name;
        public string Name
        {
            get { return name; }
            protected set { name = value; }
        }

        //Weight is measured in grams
        public int Weight
        {
            get;
            set;
        }


        private double price;
        public double Price
        {
            get
            {
                return price;
            }
            set
            {
                if (value < 0)
                {
                    price = (-1) * value;
                }
                else
                {
                    price = value;
                }
            }
        }


        public override int GetHashCode()
        {
            return  Name.GetHashCode() + Convert.ToInt32(Weight) + Convert.ToInt32(Price) +
                    ExpirationDate + CreationTime.Day;
        }

        public virtual void ChangePrice(double Percentage, (int, int, int) Koefs)//Koefs - коефіцієнти, які будуть задаватися на складі.
        {            //                                                          У випадку молочних або м'ясних продуктів вони впливатимуть на формування ціни      
                     
                     
            Price *= 1 + (Percentage / 100);
            Price = Math.Round(Price, 2);
        }

        public override bool Equals(Object obj)
        {
            if (this.GetType() == obj.GetType())
            {
                var Second = (Product)obj;
                return this.Name == Second.Name && this.Price == Second.Price && this.Weight == Second.Weight;
            }

            return false;
        }


        public override string ToString()
        {
            return $"Name: \"{this.Name}\", Weight: {this.Weight}, Price: {this.Price}";
        }

        public Product Copy()
        {
            return (Product)this.MemberwiseClone();
        }
    }
}
