using System;

namespace Task11
{
    class EntryPoint
    {
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                Console.WriteLine(StringHelper.FindLongestStringLength(args[0]));
                Console.WriteLine(StringHelper.FindLongestStringLengthWithTheSameElements(args[0], StringHelper.GetNextSymbol));
                Console.WriteLine(StringHelper.FindLongestStringLengthWithTheSameElements(args[0], StringHelper.GetNextNumber));
            }
            else
            {
                Console.WriteLine(0);
            }
        }
    }
}
