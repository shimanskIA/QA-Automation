using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace HW5
{
    class EquilateralTriangle : Triangle
    {
        public EquilateralTriangle(double side1) : base(side1, side1, side1)
        {
            SetColor = Color.Red;
        }

        public override double CalculateArea()
        {
            return (Math.Sqrt(3) / 4) * Side1 * Side1;
        }
    }
}
