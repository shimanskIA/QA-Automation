using System;

namespace HW4
{
    class Program
    {
        static void Main(string[] args)
        {
            Matrix<int> matrix1 = new Matrix<int>(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }, 4);
            Matrix<double> matrix3 = new Matrix<double>(new[] { 1.0, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }, 4);
            Matrix<double> matrix4 = new Matrix<double>(new[] { 1.00000001, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }, 4);
            bool eq = matrix3.Equals(matrix4);
            Console.WriteLine(eq);
            Console.WriteLine();
            string array_view = matrix1.GetMatrixView();
            Console.WriteLine(array_view);
            Console.WriteLine();

            while (true)
            {
                try
                {
                    int row = Convert.ToInt32(Console.ReadLine());
                    int column = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine(matrix1[row, column]);
                    break;
                }
                catch
                {

                }
            }

            Console.WriteLine(matrix1[1, 0]);
            Console.WriteLine();

            while (true)
            {
                try
                {
                    int row = Convert.ToInt32(Console.ReadLine());
                    int column = Convert.ToInt32(Console.ReadLine());
                    int count = Convert.ToInt32(Console.ReadLine());
                    matrix1[row, column] = count;
                    break;
                }
                catch
                {

                }
            }

            matrix1[1, 2] = 25;
            array_view = matrix1.GetMatrixView();
            Console.WriteLine(array_view);
            Console.WriteLine();
            DiagonalMatrix<int> matrix2 = new DiagonalMatrix<int>(new [] { 1, 1, 1, 2, 5, 7 });
            array_view = matrix2.GetMatrixView();
            Console.WriteLine(array_view);
            Console.WriteLine();

            while (true)
            {
                try
                {
                    int row = Convert.ToInt32(Console.ReadLine());
                    int column = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine(matrix2[row, column]);
                    break;
                }
                catch
                {

                }
            }

            Console.WriteLine(matrix2[1, 1]);
            Console.WriteLine(matrix2[1, 4]);
            Console.WriteLine();

            while (true)
            {
                try
                {
                    int row = Convert.ToInt32(Console.ReadLine());
                    int column = Convert.ToInt32(Console.ReadLine());
                    int count = Convert.ToInt32(Console.ReadLine());
                    matrix2[row, column] = count;
                    break;
                }
                catch
                {

                }
            }

            matrix2[2, 2] = 25;
            array_view = matrix2.GetMatrixView();
            Console.WriteLine(array_view);
            Console.WriteLine();
            int[] temp1 = matrix1.GetMatrix();
            int[] temp2 = matrix2.GetMatrix();
            Console.WriteLine();
            foreach (var element in temp1)
            {
                Console.Write("{0, 5}", element);
            }
            Console.WriteLine();
            foreach (var element in temp2)
            {
                Console.Write("{0, 5}", element);
            }
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
