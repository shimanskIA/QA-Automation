using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace HW5
{
    class RightTriangle : Triangle
    {
        public RightTriangle(double side1, double side2) : base(side1, side2, Math.Sqrt(side1 * side1 + side2 * side2))
        {
            SetColor = Color.Green;
        }

        public override double CalculateArea()
        {
            return (Side1 * Side2) / 2;
        }
    }
}
