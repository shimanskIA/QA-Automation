using System;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            int symbolLength = Helpers.FindLongestString(args); // finding the longest substring in which characters are not repeated
            if (symbolLength == 0)
            {
                Console.WriteLine("You've entered more than 1 or less than 1 string"); // in case of wrong input
            }
            else
            {
                Console.WriteLine(symbolLength);
            }
        }
    }
}
