using System;

namespace HW5
{
    class Program
    {
        static void Main(string[] args)
        {
            // creating of the chain of responsibilities
            TriangleBuilder h1 = new RightTriangleBuilder();
            TriangleBuilder h2 = new EquilateralTriangleBuilder();
            TriangleBuilder h3 = new IsoscelesTriangleBuilder();
            TriangleBuilder h4 = new BasicTriangleBuilder();
            h1.Successor = h2;
            h2.Successor = h3;
            h3.Successor = h4;
            // start of processing
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
                    some_triangle = h1.HandleTriangleRequest(new Point(x1, y1), new Point(x2, y2), new Point(x3, y3));
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
