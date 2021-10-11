using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace firstTask
{
    class Polinomial
    {
        private double[] koefs = null;

        private int m;
        public int M
        {
            get { return m; }
            private set { m = value; }
        }



        public Polinomial(string initString)
        {
            this.Parse(initString);
        }

        public Polinomial(int _m)
        {
            this.M = _m;
            koefs = new double[M];
        }





        #region overloadedOperations

        public static Polinomial operator +(Polinomial firstParameter, Polinomial secondParameter) 
        {
            Polinomial result = null;
            bool isFirstParameterBigger = (firstParameter.M >= secondParameter.M);
            int firstParameterLength = firstParameter.M;
            int secondParameterLength = secondParameter.M;


            if (isFirstParameterBigger)
            {
                result = new Polinomial(firstParameterLength);
            }
            else
            {
                result = new Polinomial(secondParameterLength);
            }


            if (isFirstParameterBigger)
            {
                for (int i = 0; i < firstParameterLength; i++)
                {
                    result.koefs[i] += firstParameter.koefs[i];

                    if (i < secondParameterLength)
                    {
                        result.koefs[i] += secondParameter.koefs[i];
                    }
                }
            }
            else
            {
                for (int i = 0; i < secondParameterLength; i++)
                {
                    result.koefs[i] += secondParameter.koefs[i];

                    if (i < firstParameterLength)
                    {
                        result.koefs[i] += firstParameter.koefs[i];
                    }
                }
            }


            return result;
        }



        public static Polinomial operator -(Polinomial firstParameter, Polinomial secondParameter)
        {
            Polinomial result = null;
            bool isFirstParameterBigger = (firstParameter.M >= secondParameter.M);
            int firstParameterLength = firstParameter.M;
            int secondParameterLength = secondParameter.M;


            if (isFirstParameterBigger)
            {
                result = new Polinomial(firstParameterLength);
            }
            else
            {
                result = new Polinomial(secondParameterLength);
            }


            for (int i = 0; i < firstParameterLength; i++)
            {
                result.koefs[i] = firstParameter.koefs[i];
            }
            for (int i = 0; i < secondParameterLength; i++)
            {
                result.koefs[i] -= secondParameter.koefs[i];
            }


            return result;
        }


        public static Polinomial operator *(Polinomial firstParameter, Polinomial secondParameter)
        {
            int firstParameterLength = firstParameter.M;
            int secondParameterLength = secondParameter.M;
            Polinomial result = new Polinomial(firstParameterLength + secondParameterLength - 1);

            for (int i = 0; i < firstParameterLength; i++)
            {
                for (int j = 0; j < secondParameterLength; j++)
                {
                    result.koefs[i + j] += firstParameter.koefs[i] * secondParameter.koefs[j];
                }
            }       


            return result;
        }


        public static implicit operator Polinomial(double number) 
        {
            var result = new Polinomial(1);
            result[0] = number;

            return result;
        }


        #endregion






        #region mathOperaions

        public Polinomial Multiply(Polinomial p2)
        {
            Polinomial result = new Polinomial(this.M + p2.M);

            for (int i = 0; i < M; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    result.koefs[i + j] += koefs[i] * p2.koefs[j];
                }
            }


            return result;
        }

        public Polinomial Minus(Polinomial p2)
        {
            Polinomial result;

            if (this.M >= p2.M)
            {
                result = new Polinomial(this.M);
            }
            else
            {
                result = new Polinomial(p2.M);
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


        public Polinomial Add(Polinomial p2)
        {
            Polinomial result;

            if (this.M >= p2.M)
            {
                result = new Polinomial(this.M);
            }
            else
            {
                result = new Polinomial(p2.M);
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

#endregion

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