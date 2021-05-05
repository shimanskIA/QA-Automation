using System;
using System.Collections.Generic;
using System.Text;

namespace HW5
{
    class IsoscelesTriangle : Triangle, ISideValidation
    {
        public double PairSide { get; set; } // in centimeters
        public double SingleSide { get; set; } // in centimeters
        public IsoscelesTriangle(Point point1, Point point2, Point point3) : base(point1, point2, point3)
        {
            double side1 = point1.CountDistance(point2); // counting length of side 1
            double side2 = point1.CountDistance(point3); // ...
            double side3 = point2.CountDistance(point3); // ...
            if (Validate(side1, side2, side3))
            {
                Color = Colors.Blue;
                SideProcessor(side1, side2, side3);
            }
            else
            {
                throw new Exception("You are trying to create not a isosceles triangle");
            }
        }

        // counting an area of triangle via S = (a * h) / 2;
        public override double CalculateArea()
        {
            double h = Math.Sqrt(PairSide * PairSide - (SingleSide / 2) * (SingleSide / 2));
            return (SingleSide * h) / 2;
        }

        // methode to check if a triangle is isosceles
        public bool Validate(double side1, double side2, double side3)
        {
            return Math.Abs(side3 - side1) < 1e-10 || Math.Abs(side3 - side2) < 1e-10 || Math.Abs(side2 - side1) < 1e-10; // using 1e-10 as epsilon
        }

        // methode to process the length of the sides
        private void SideProcessor(double side1, double side2, double side3)
        {
            if (Math.Abs(side3 - side1) < 1e-10)
            {
                PairSide = side3;
                SingleSide = side2;
            }
            else if (Math.Abs(side3 - side2) < 1e-10)
            {
                PairSide = side3;
                SingleSide = side1;
            }
            else if (Math.Abs(side2 - side1) < 1e-10)
            {
                PairSide = side2;
                SingleSide = side3;
            }
        }
    }
}
