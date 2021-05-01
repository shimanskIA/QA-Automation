using System;

namespace HW5
{
    class Program
    {
        static void Main(string[] args)
        {
            TriangleBuilder tb = new TriangleBuilder();
            double S = tb.CreateTriangle(2, 3, 4).CalculateArea();
            Console.WriteLine(S);
        }
    }
}
