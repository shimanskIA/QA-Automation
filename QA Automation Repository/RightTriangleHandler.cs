using System;
using System.Collections.Generic;
using System.Text;

namespace HW5
{
    class RightTriangleHandler : TriangleHandler
    {
        public override void HandleTriangleRequest(double side1, double side2, double side3)
        {
            if (side3 * side3 - side2 * side2 - side1 * side1 < Double.Epsilon)
            {
                RightTriangleFactory right_triangle_factory = new RightTriangleFactory();
                OutputTriangle = right_triangle_factory.CreateTriangle(side1, side2, side3);
            }
            else if (Successor != null)
            {
                Successor.HandleTriangleRequest(side1, side2, side3);
            }
        }
    }
}
