using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace HW5
{
    class IsoscelesTriangle : Triangle
    {
        public IsoscelesTriangle(double side1, double side2) : base(side1, side1, side2)
        {
            SetColor = Color.Blue;
        }

        public override double CalculateArea()
        {
            double h = Math.Sqrt(Side1 * Side1 - (Side3 / 2) * (Side3 / 2));
            return (Side3 * h) / 2;
        }
    }
}
