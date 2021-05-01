using System;
using System.Collections.Generic;
using System.Text;

namespace HW5
{
    class IsoscelesTriangleHandler : TriangleHandler
    {
        public override void HandleTriangleRequest(double side1, double side2, double side3)
        {
            if (side1 - side2 < Double.Epsilon)
            {
                IsoscelesTriangleFactory isosceles_triangle_factory = new IsoscelesTriangleFactory();
                OutputTriangle = isosceles_triangle_factory.CreateTriangle(side1, side2, side3);
            }
            else if (Successor != null)
            {
                Successor.HandleTriangleRequest(side1, side2, side3);
            }
        }
    }
}
