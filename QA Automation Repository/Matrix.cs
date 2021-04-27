using System;
using System.Collections.Generic;
using System.Text;

namespace HW4
{
    // class for square matrix
    class Matrix
    {
        public double[] Array { get; protected set; }
        public int Rows { get; protected set; }
        public int Columns { get; protected set; }

        public Matrix(double[] array, int rows)
        {
            if (array.Length % rows == 0)
            {
                Array = new double[array.Length];
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

        public Matrix()
        {

        }

        public virtual double this[int i, int j] // indexators
        {
            get
            {
                return Array[i * (Rows - 1) + j];
            }

            set
            {
                Array[i * (Rows - 1) + j] = (double)value;
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
    }
}
