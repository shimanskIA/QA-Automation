using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace HW5
{
    class EquilateralTriangle : Triangle, ISideValidation
    {
        public double Side { get; set; } // in centimeters
        public EquilateralTriangle(Point point1, Point point2, Point point3) : base(point1, point2, point3)
        {
            double side1 = point1.CountDistance(point2); // counting length of side 1
            double side2 = point1.CountDistance(point3); // ...
            double side3 = point2.CountDistance(point3); // ...
            if (Validate(side1, side2, side3))
            {
                Color = Colors.Red;
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

        // methode to check if a triangle is equilateral
        public bool Validate(double side1, double side2, double side3)
        {
            return Math.Abs(side3 - side1) < 1e-10 && Math.Abs(side3 - side2) < 1e-10; // using 1e-10 as epsilon
        }
    }
}
