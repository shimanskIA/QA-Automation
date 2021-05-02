using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace HW5
{
    class EquilateralTriangle : Triangle
    {
        public double Side { get; set; } // in centimeters
        public EquilateralTriangle(Point point1, Point point2, Point point3) : base(point1, point2, point3)
        {
            double side1 = Math.Sqrt((point1.X - point2.X) * (point1.X - point2.X) + (point1.Y - point2.Y) * (point1.Y - point2.Y)); // counting length of side 1
            double side2 = Math.Sqrt((point1.X - point3.X) * (point1.X - point3.X) + (point1.Y - point3.Y) * (point1.Y - point3.Y)); // ...
            double side3 = Math.Sqrt((point2.X - point3.X) * (point2.X - point3.X) + (point2.Y - point3.Y) * (point2.Y - point3.Y)); // ...
            if (Math.Abs(side3 - side1) < 1e-10 && Math.Abs(side3 - side2) < 1e-10) // using 1e-10 as epsilon
            {
                SetColor = Color.Red;
                Side = side3;
            }
            else
            {
                throw new Exception("You are trying to create not a equilateral triangle");
            }
        }

        // counting area of triangle via sqrt(3) / 4 * a ^ 2
        public override double CalculateArea()
        {
            return (Math.Sqrt(3) / 4) * Side * Side;
        }
    }
}
