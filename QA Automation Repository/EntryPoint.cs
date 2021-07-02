using System;
using Task3.Helpers;

namespace Task3
{
    class EntryPoint
    {
        static void Main(string[] args)
        {
            if (ValidationHelper.Validate(args[0], args[1]))
            {
                Console.WriteLine(ConvertionHelper.ConvertNumberFrom10NotationToAnyOtherNotation(UInt32.Parse(args[0]), UInt32.Parse(args[1])));
            }
        }
    }
}
