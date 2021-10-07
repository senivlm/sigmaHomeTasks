using System;

namespace Poly
{
    class Program
    {
        static void Main(string[] args)
        {
            Polynomial p1 = new Polynomial("2*x^0+4*x^2+5*x^3+2*x^5");
            p1.Parse("2*x^0+4*x^2+5*x^3+8*x^5");
            

            Polynomial p2 = new Polynomial("2*x^0+4*x^2+5*x^3+8*x^5");
            //p2.Parse("2*x^0+4*x^2+5*x^3+8*x^5");
            //p2[8] = 10;
            Polynomial p3 = p1.Multiply(p2);

            //

            //Console.WriteLine(p3.GetValue());
            //p1.Multiply(2);
            Console.WriteLine(p3.GetValue(3));

        }
    }
}