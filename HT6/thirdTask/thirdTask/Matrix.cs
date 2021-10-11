using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;


namespace thirdTask
{
    class Matrix : IEnumerable
    {
        private int cols;
        public int Cols
        {
            get { return cols; }
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException("Invalid cols count");
                }

                cols = value;
            }
        }

        private int rows;
        public int Rows
        {
            get { return rows; }
            private set 
            {
                if (value < 1)
                {
                    throw new ArgumentException("Invalid rows count");
                }

                rows = value;
            }
        }

        int[][] data = null; 


        public Matrix(int _rows = 1, int _cols = 1) 
        {
            Rows = _rows;
            Cols = _cols;

            data = new int[this.Rows][];
            for (int i = 0; i < this.Rows; i++)
            {
                data[i] = new int[this.Cols];
            }
        }


        public int this[int r, int c]
        {
            get
            {
                try
                {
                    return data[r][c];
                }
                catch (IndexOutOfRangeException IOORexception)
                {
                    Console.WriteLine("ERROR occured\nImpossible to access this element");
                }

                return 0;
            }
            set
            {
                try
                {
                    data[r][c] = value;
                }
                catch (IndexOutOfRangeException IOORexception)
                {
                    Console.WriteLine("ERROR occured\nImpossible to access this element");
                }
            }
        }

        public void RandomInitialise() 
        {
            Random randNumberGenerator = new Random();

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    data[i][j] = randNumberGenerator.Next(0, 10);
                }
            }
        }

        public IEnumerator GetEnumerator()
        {
            return new ReverseEnumerator(data);
        }


        class ReverseEnumerator : IEnumerator<int>
        {
            private int row;
            private int col;
            private int[][] data = null;

            public ReverseEnumerator(int[][] _data) 
            {
                data = _data;

                row = data.Length - 1;
                col = data[0].Length;
            }

            public int Current => data[row][col];

            object IEnumerator.Current => data[row][col];

            public void Dispose() {}

            public bool MoveNext()
            {
                --col;
                if (col < 0)
                {
                    col = data[0].Length - 1;
                    row--;

                    //Console.WriteLine();
                }

                return row >= 0;
            }

            public void Reset()
            {
                row = data.Length - 1;
                col = data[0].Length;
            }
        }

    }
}

