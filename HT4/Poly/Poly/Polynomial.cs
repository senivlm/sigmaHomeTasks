using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Poly
{
    class Polynomial
    {
        private double[] koefs = null;

        private int m;
        public int M
        {
            get { return m; }
            private set { m = value; }
        }

        public Polynomial(string initString) 
        {
            this.Parse(initString);
        }

        public Polynomial(int _m) 
        {
            this.M = _m;
            koefs = new double[M];
        }

        public Polynomial Multiply(Polynomial p2)
        {
            Polynomial result = new Polynomial(this.M + p2.M);

            for (int i = 0; i < M; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    result.koefs[i + j] += koefs[i] * p2.koefs[j];
                }
            }


            return result;
        }

        public Polynomial Minus(Polynomial p2)
        {
            Polynomial result;

            if (this.M >= p2.M)
            {
                result = new Polynomial(this.M);
            }
            else
            {
                result = new Polynomial(p2.M);
            }


            for (int i = 0; i < this.M; i++)
            {
                result.koefs[i] += this.koefs[i];
            }
            for (int i = 0; i < p2.M; i++)
            {
                result.koefs[i] -= p2.koefs[i];
            }

            return result;
        }


        public Polynomial Add(Polynomial p2)
        {
            Polynomial result;

            if (this.M >= p2.M)
            {
                result = new Polynomial(this.M);
            }
            else
            {
                result = new Polynomial(p2.M);
            }


            for (int i = 0; i < this.M; i++)
            {
                result.koefs[i] += this.koefs[i];
            }
            for (int i = 0; i < p2.M; i++)
            {
                result.koefs[i] += p2.koefs[i];
            }

            return result;
        }


        public double this[int index] 
        {
            get 
            {
                return koefs[index];
            }

            set 
            {
                if (index < 0)
                {
                    throw new IndexOutOfRangeException();
                }

                if (value != 0)
                {
                    if (index >= M)
                    {
                        double[] temp = new double[index + 1];

                        for (int i = 0; i < koefs.Length; i++)
                        {
                            temp[i] = koefs[i];
                        }

                        koefs = temp;
                        M = index + 1;
                    }

                    koefs[index] = value;
                }
                else 
                {
                    if (index < M)
                    {
                        koefs[index] = value;
                    }
                }
            }
        }



        public double GetValue(double val)
        {
            double result = 0;

            for (int i = 0; i < koefs.Length; i++)
            {
                result += koefs[i] * Math.Pow(val, i);
            }

            return result;
        }


        public void Parse(string inputStr) 
        {
            string[] polyElements = inputStr.Split("+", StringSplitOptions.RemoveEmptyEntries);
            try
            {
                M = Convert.ToInt32(polyElements[polyElements.Length - 1].Split("^")[1]);
            }
            catch (Exception)
            {
                throw new Exception("Impossible to initialise polynom with this parameters");
            }

            koefs = new double[++M];
            try
            {
                for (int i = 0; i < polyElements.Length; i++)
                {
                    koefs[Convert.ToInt32(polyElements[i].Split("^")[1])] = Convert.ToDouble(polyElements[i].Split("*")[0]);
                }
            }
            catch 
            {
                throw new Exception("Invalid parameter in file - impossible to convert");
            }
        }
    }
}