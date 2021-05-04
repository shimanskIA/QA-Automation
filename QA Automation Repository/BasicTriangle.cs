using System;
using System.Collections.Generic;
using System.Text;

namespace HW5
{
    class BasicTriangle : Triangle
    {
        public double Side1 { get; set; } // in centimeters
        public double Side2 { get; set; } // in centimeters
        public double Side3 { get; set; } // in centimeters
        public BasicTriangle(Point point1, Point point2, Point point3) : base(point1, point2, point3)
        {
            Side1 = point1.CountDistance(point2); // counting length of side 1 
            Side2 = point1.CountDistance(point3); // ...
            Side3 = point2.CountDistance(point3); // ...
            Color = Colors.White;
        }

        // counting area of triangle via S = sqrt (p(p - a)(p - b)(p - c))
        public override double CalculateArea()
        {
            double p = (Side1 + Side2 + Side3) / 2;
            return Math.Sqrt(p * (p - Side1) * (p - Side2) * (p - Side3));
        }

    }
}
