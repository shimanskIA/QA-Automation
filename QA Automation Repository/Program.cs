using System;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Helpers.ConvertFrom10(Int32.Parse(args[0]), Int32.Parse(args[1])));
        }
    }
}
