using System;
using System.Collections.Generic;
using System.Text;

namespace HW5
{
    class BasicTriangleHandler : TriangleHandler
    {
        // description of an element in chain
        public override void HandleTriangleRequest(Point point1, Point point2, Point point3)
        {
            BasicTriangleFactory basic_triangle_factory = new BasicTriangleFactory();
            OutputTriangle = basic_triangle_factory.CreateTriangle(point1, point2, point3);
        }
    }
}
