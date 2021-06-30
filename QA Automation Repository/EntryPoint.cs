using System;

namespace Task3
{
    class EntryPoint
    {
        static void Main(string[] args)
        {
            if (Helper.Validate(args[0], args[1]))
            {
                Console.WriteLine(Helper.ConvertNumberFrom10NotationToAnyOtherNotation(UInt32.Parse(args[0]), UInt32.Parse(args[1])));
            }
        }
    }
}
