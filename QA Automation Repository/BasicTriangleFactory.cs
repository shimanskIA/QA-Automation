using System;
using System.Collections.Generic;
using System.Text;

namespace HW5
{
    // factory for basic triangles
    class BasicTriangleFactory : TriangleFactory
    {
        public override Triangle CreateTriangle(Point point1, Point point2, Point point3)
        {
            return new BasicTriangle(point1, point2, point3);
        }
    }
}
