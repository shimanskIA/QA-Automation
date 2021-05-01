using System;
using System.Collections.Generic;
using System.Text;

namespace HW5
{
    class EquilateralTriangleFactory : TriangleFactory
    {
        public override Triangle CreateTriangle(double side1, double side2, double side3)
        {
            return new EquilateralTriangle(side1);
        }
    }
}
