using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace HW5
{
    class IsoscelesTriangle : Triangle
    {
        public double PairSide { get; set; } // in centimeters
        public double SingleSide { get; set; } // in centimeters
        public IsoscelesTriangle(Point point1, Point point2, Point point3) : base(point1, point2, point3)
        {
            double side1 = Math.Sqrt((point1.X - point2.X) * (point1.X - point2.X) + (point1.Y - point2.Y) * (point1.Y - point2.Y)); // counting length of side 1
            double side2 = Math.Sqrt((point1.X - point3.X) * (point1.X - point3.X) + (point1.Y - point3.Y) * (point1.Y - point3.Y)); // ...
            double side3 = Math.Sqrt((point2.X - point3.X) * (point2.X - point3.X) + (point2.Y - point3.Y) * (point2.Y - point3.Y)); // ...
            if (Math.Abs(side3 - side1) < 1e-10 || Math.Abs(side3 - side2) < 1e-10 || Math.Abs(side2 - side1) < 1e-10)
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
                SetColor = Color.Blue;
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
    }
}
