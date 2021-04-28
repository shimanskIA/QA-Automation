using System;

namespace HW4
{
    class Program
    {
        static void Main(string[] args)
        {
            Matrix<int> matrix1 = new Matrix<int>(new [] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12}, 4);
            matrix1.PrintMatrix();
            Console.WriteLine();
            Console.WriteLine(matrix1[2, 2]);
            Console.WriteLine(matrix1[1, 0]);
            Console.WriteLine();
            matrix1[1, 1] = 25;
            matrix1[1, 2] = 25;
            matrix1.PrintMatrix();
            Console.WriteLine();
            DiagonalMatrix<int> matrix2 = new DiagonalMatrix<int>(new [] { 1, 1, 1, 2, 5, 7 });
            matrix2.PrintMatrix();
            Console.WriteLine();
            Console.WriteLine(matrix2[3, 3]);
            Console.WriteLine(matrix2[1, 1]);
            Console.WriteLine(matrix2[1, 4]);
            Console.WriteLine();
            matrix2[1, 1] = 25;
            matrix2[2, 2] = 25;
            matrix2.PrintMatrix();
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
