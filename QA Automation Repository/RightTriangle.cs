using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace HW5
{
    // class describes a right triangle
    class RightTriangle : Triangle, ISideValidation
    {
        public double Leg1 { get; set; } // in centimeters
        public double Leg2 { get; set; } // in centimeters
        public double Hypotenuse { get; set; } // in centimeters
        public RightTriangle(Point point1, Point point2, Point point3) : base(point1, point2, point3)
        {
            double side1 = point1.CountDistance(point2); // counting length of side1
            double side2 = point1.CountDistance(point3); // ...
            double side3 = point2.CountDistance(point3); // ...
            
            if (Validate(side1, side2, side3))
            {
                Color = Colors.Green;
                SideProcessor(side1, side2, side3);
            }
            else
            {
                throw new Exception("You are trying to create not a right triangle");
            }
        }

        // counting area of triangle via S = (a * b) / 2
        public override double CalculateArea()
        {
            return (Leg1 * Leg2) / 2;
        }

        // methode to check if a triangle is right
        public bool Validate(double side1, double side2, double side3)
        {
            double[] sides = { side1, side2, side3 };

            var sortedSides = from side in sides                    // sorting array
                              orderby side ascending
                              select side;

            return Math.Abs(sides[2] * sides[2] - sides[1] * sides[1] - sides[0] * sides[0]) < 1e-10; // using 1e-10 as epsilon
        }

        // methode to process the length of the sides
        private void SideProcessor(double side1, double side2, double side3)
        {
            Hypotenuse = Math.Max(Math.Max(side1, side2), Math.Max(side2, side3));
            Leg1 = Math.Min(Math.Min(side1, side2), Math.Min(side2, side3));
            Leg2 = Math.Sqrt(Hypotenuse * Hypotenuse - Leg1 * Leg1);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
