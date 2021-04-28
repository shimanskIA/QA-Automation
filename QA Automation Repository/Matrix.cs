using System;
using System.Collections.Generic;
using System.Text;

namespace HW4
{
    // class for square matrix
    class Matrix<T> : IMyCloneable<T>
    {
        public T[] Array { get; protected set; }
        public int Rows { get; protected set; }
        public int Columns { get; protected set; }

        public Matrix(T[] array, int rows)
        {
            if (array.Length % rows == 0)
            {
                Array = new T[array.Length];
                for (int i = 0; i < array.Length; i++)
                {
                    Array[i] = array[i];
                }
                Rows = rows;
                Columns = array.Length / rows;
            }
            else
            {
                throw new Exception("Incorrect input of array parameters");
            }
        }

        protected Matrix()
        {

        }

        public virtual T this[int i, int j] // indexators
        {
            get
            {
                if (i < 0 || j < 0 || i >= Rows || j >= Columns)
                {
                    throw new Exception("Indexes must be positive and may not exceed the array bounds");
                }
                else
                {
                    return Array[i * (Rows - 1) + j];
                }
            }

            set
            {
                if (i < 0 || j < 0 || i >= Rows || j >= Columns)
                {
                    throw new Exception("Indexes must be positive and may not exceed the array bounds");
                }
                else
                {
                    Array[i * (Rows - 1) + j] = (T)value;
                }
            }
        }

        public virtual void PrintMatrix() //matrix output to console
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    Console.Write("{0,5}", Array[i * (Rows - 1) + j]);
                }
                Console.WriteLine("");
            }
        }

        public virtual T[] GetMatrix() // methode for output of copies of array elements (not into the console)
        {
            return Clone();
        }

        public virtual T[] Clone() // methode for copying array elements
        {
            T[] copied_array = new T[Array.Length];
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    copied_array[i * (Rows - 1) + j] = Array[i * (Rows - 1) + j];
                }
            }
            return copied_array;
        }
    }
}
