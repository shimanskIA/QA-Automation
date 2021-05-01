using System;
using System.Collections.Generic;
using System.Text;

namespace HW5
{
    class BasicTriangleHandler : TriangleHandler
    {
        public override void HandleTriangleRequest(double side1, double side2, double side3)
        {
            if (side1 + side2 < side3 && side1 + side3 < side2 && side2 + side3 < side1)
            {
                BasicTriangleFactory basic_triangle_factory = new BasicTriangleFactory();
                OutputTriangle = basic_triangle_factory.CreateTriangle(side1, side2, side3);
            }
            else if (Successor != null)
            {
                Successor.HandleTriangleRequest(side1, side2, side3);
            }
        }
    }
}
