using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace HW5
{
    class BasicTriangle : Triangle
    {
        public BasicTriangle(double side1, double side2, double side3) : base(side1, side2, side3)
        {
            SetColor = Color.White;
        }

        public override double CalculateArea()
        {
            double p = (Side1 + Side2 + Side3) / 2;
            return Math.Sqrt(p * (p - Side1) * (p - Side2) * (p - Side3));
        }
    }
}
