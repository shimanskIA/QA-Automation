using System;

namespace HW5
{
    class Program
    {
        static void Main(string[] args)
        {
            TriangleBuilder tb = new TriangleBuilder();
            Triangle some_triangle;
            while (true)
            {
                double x1 = Convert.ToDouble(Console.ReadLine());
                double y1 = Convert.ToDouble(Console.ReadLine());
                double x2 = Convert.ToDouble(Console.ReadLine());
                double y2 = Convert.ToDouble(Console.ReadLine());
                double x3 = Convert.ToDouble(Console.ReadLine());
                double y3 = Convert.ToDouble(Console.ReadLine());
                try
                {
                    some_triangle = tb.CreateTriangle(new Point(x1, y1), new Point(x2, y2), new Point(x3, y3));
                    break;
                }
                catch
                {
                    
                }
            }
            double S = some_triangle.CalculateArea();
            Console.WriteLine("That's a " + some_triangle.GetType().ToString() + " with an area of " + Math.Round(S, 5) + " cm2");
        }
    }
}
