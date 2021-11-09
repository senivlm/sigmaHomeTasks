using System;
using System.Collections.Generic;
using System.Text;

namespace Saint
{
    public interface IToy
    {
        string ToString();
    }

    public class Toy : IToy
    {
        public ToyVariant toyVariant { get; private set; }
        public int Price { get; private set; }
        public string Purpose { get; private set; }

        public Toy(ToyVariant toyVariant, int Price, string Purpose)
        {
            this.toyVariant = toyVariant;
            this.Price = Price;
            this.Purpose = Purpose;
        }

        public override string ToString()
        {
            return $"Toy: {toyVariant}, price: {Price}, purpose: {Purpose}";
        }
    }
}
