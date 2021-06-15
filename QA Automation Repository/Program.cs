using System;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            if (Helpers.Validate(args[0], args[1]))
            {
                Console.WriteLine(Helpers.ConvertFrom10(UInt32.Parse(args[0]), UInt32.Parse(args[1])));
            }
        }
    }
}
