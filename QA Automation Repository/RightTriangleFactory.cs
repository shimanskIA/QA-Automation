using System;
using System.Collections.Generic;
using System.Text;

namespace HW5
{
    // factory for right triangles
    class RightTriangleFactory : TriangleFactory
    {
        public override Triangle CreateTriangle(Point point1, Point point2, Point point3) 
        {
            return new RightTriangle(point1, point2, point3); // creating new triangle
        }
    }
}
