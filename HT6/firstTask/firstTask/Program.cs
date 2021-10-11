using System;

namespace firstTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Polinomial p1 = new Polinomial("2*x^0+4*x^2+5*x^3+2*x^5");
            Polinomial p2 = new Polinomial("2*x^0+4*x^2+5*x^3+8*x^5");

            Polinomial p3 = p1 * p2;
            //p3 = 5;


            Console.WriteLine(p3.GetValue(1));

        }
    }
}
