using System;
using System.Collections.Generic;
using System.Text;

namespace HW5
{
    abstract class TriangleFactory
    {
        public abstract Triangle CreateTriangle(Point point1, Point point2, Point point3);
    }
}
