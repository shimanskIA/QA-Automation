using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Linq;

namespace HW5
{
    // class describes a right triangle
    class RightTriangle : Triangle
    {
        public double Leg1 { get; set; } // in centimeters
        public double Leg2 { get; set; } // in centimeters
        public double Hypotenuse { get; set; } // in centimeters
        public RightTriangle(Point point1, Point point2, Point point3) : base(point1, point2, point3)
        {
            double side1 = Math.Sqrt((point1.X - point2.X) * (point1.X - point2.X) + (point1.Y - point2.Y) * (point1.Y - point2.Y)); // counting length of side1
            double side2 = Math.Sqrt((point1.X - point3.X) * (point1.X - point3.X) + (point1.Y - point3.Y) * (point1.Y - point3.Y)); // ...
            double side3 = Math.Sqrt((point2.X - point3.X) * (point2.X - point3.X) + (point2.Y - point3.Y) * (point2.Y - point3.Y)); // ...
            double[] sides = { side1, side2, side3 };
            
            var sortedSides = from side in sides                    // sorting array
                              orderby side ascending
                              select side;
            
            if (Math.Abs(sides[2] * sides[2] - sides[1] * sides[1] - sides[0] * sides[0]) < 1e-10)
            {
                SetColor = Color.Green;
                Hypotenuse = sides[2];
                Leg1 = sides[1];
                Leg2 = sides[0];
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
    }
}
