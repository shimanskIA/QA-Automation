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

        public override string GetMatrixView() // matrix output to main in the sqare form
        {
            StringBuilder str = new StringBuilder();
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    if (i == j)
                    {
                        str.Append(String.Format("{0, 4}", Array[i])); 
                    }
                    else
                    {
                        str.Append(String.Format("{0, 4}", 0));
                    }
                }
                str.Append("\n");
            }
            return str.ToString();
        }

        public override T[] GetMatrix() // methode for output of copies of array elements to main in linear form
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

        // methode to compare two objects
        public override bool Equals(object some_object)
        {
            if (some_object is DiagonalMatrix<T>)
            {
                var some_diagonal_matrix = some_object as DiagonalMatrix<double>;
                var this_matrix = this as DiagonalMatrix<double>;
                if (some_diagonal_matrix.Array.Length == Array.Length)
                {
                    for (int i = 0; i < Array.Length; i++)
                    {
                        if (Math.Abs(this_matrix.Array[i] - some_diagonal_matrix.Array[i]) > 1e-10)
                        {
                            return false;
                        }
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        // methode that return a hash code of the object
        public override int GetHashCode()
        {
            return Array.GetHashCode();
        }

    }
}
