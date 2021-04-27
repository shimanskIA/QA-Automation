using System;
using System.Collections.Generic;
using System.Text;

namespace HW4
{
    // class for diagonal matrix
    class DiagonalMatrix : Matrix
    {
        public DiagonalMatrix(double[] array) // used empty constructor as base
        {
                Array = new double[array.Length];
                for (int i = 0; i < array.Length; i++)
                {
                    Array[i] = array[i];
                }
                Rows = array.Length;
                Columns = Rows;
        }

        public override double this[int i, int j] // indexators
        {
            get
            {
                if (i == j)
                {
                    return Array[i];
                }
                else
                {
                    return 0; // non-diagonal element
                }
            }

            set
            {
                if (i == j)
                {
                    Array[i] = (double)value;
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

    }
}
