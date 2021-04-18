using System;

namespace test_excercise
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = 10;
            int[] arr = new int[N];
            for (int i = 0; i < N; i++)
            {
                arr[i] = (int)Math.Pow (2, i);
            }
            Console.WriteLine("Task 1 output: ");
            for (int i = 0; i < N; i++)
            {
                Console.Write(arr[i]);
                Console.Write(' ');
            }
            Console.WriteLine("");
            Console.WriteLine("");

            Random rand = new Random();
            for (int i = 0; i < N; i++)
            {
                arr[i] = rand.Next(1, 100);
            }
            Console.WriteLine("Task 2 output: ");
            Console.WriteLine("Array at first: ");
            for (int i = 0; i < N; i++)
            {
                Console.Write(arr[i]);
                Console.Write(' ');
            }
            int max_index = 0;
            int min_index = 0;
            int max_ = -1000;
            int min_ = 1000;
            for (int i = 0; i < N; i++)
            {
                if (arr[i] > max_)
                {
                    max_ = arr[i];
                    max_index = i;
                }
                if (arr[i] < min_)
                {
                    min_ = arr[i];
                    min_index = i;
                }
            }
            arr[min_index] = max_;
            arr[max_index] = min_;
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Array at last: ");
            for (int i = 0; i < N; i++)
            {
                Console.Write(arr[i]);
                Console.Write(' ');
            }
            Console.WriteLine("");
            Console.WriteLine("");

            for (int i = 0; i < N; i++)
            {
                arr[i] = rand.Next(1, 100);
            }
            Console.WriteLine("Task 3 output: ");
            Console.WriteLine("Array: ");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i]);
                Console.Write(' ');
            }
            double mean = Calculate_Mean_Value(arr);
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Mean value = " + mean);
            Console.WriteLine("");
            Console.WriteLine("");
        }

        static double Calculate_Mean_Value(int[] arr)
        {
            int sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
            }
            double mean = ((double)sum / (double)arr.Length);
            return mean;
        }
    }
}
