using System;

namespace Task1
{
    class EntryPoint
    {
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                Console.WriteLine(Helper.FindLongestStringLength(args[0])); // finding the longest substring in which characters are not repeated
            }
            else
            {
                Console.WriteLine(0);
            }
        }
    }
}
