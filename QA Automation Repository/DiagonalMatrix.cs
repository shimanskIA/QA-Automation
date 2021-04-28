using System;
using System.Collections.Generic;
using System.Text;

namespace HW4
{
    // class for diagonal matrix
    class DiagonalMatrix<T> : Matrix<T>, IMyCloneable<T>
    {
        public DiagonalMatrix(T[] array) // used empty constructor as base
        {
                Array = new T[array.Length];
                for (int i = 0; i < array.Length; i++)
                {
                    Array[i] = array[i];
                }
                Rows = array.Length;
                Columns = Rows;
        }

        public override T this[int i, int j] // indexators
        {
            get
            {
                if (i == j)
                {
                    if (i < 0 || i >= Rows)
                    {
                        throw new Exception("Indexes must be positive and may not exceed the array bounds");
                    }
                    else
                    {
                        return Array[i]; 
                    }
                }
                else
                {
                    return (T)(object)0; // non-diagonal element
                }
            }

            set
            {
                if (i == j)
                {
                    if (i < 0 || i >= Rows)
                    {
                        throw new Exception("Indexes must be positive and may not exceed the array bounds"); 
                    }
                    else
                    {
                        Array[i] = (T)value;
                    }
                }
                else
                {
                    throw new Exception("It's not allowed to change non-diagonal elements of diagonal matrix");
                }
            }
        }

        public override void PrintMatrix() // matrix output to console
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    if (i == j)
                    {
                        Console.Write("{0, 4}", Array[i]); 
                    }
                    else
                    {
                        Console.Write("{0, 4}", 0);
                    }
                }
                Console.WriteLine("");
            }
        }

        public override T[] GetMatrix() // methode for output of copies of array elements (not into the console)
        {
            return Clone();
        }

        public override T[] Clone() // methode for copying array elements
        {
            T[] copied_array = new T[Array.Length];
            for (int i = 0; i < Rows; i++)
            {
                copied_array[i] = Array[i];
            }
            return copied_array;
        }

    }
}
