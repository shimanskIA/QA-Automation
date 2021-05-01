using System;
using System.Collections.Generic;
using System.Text;

namespace HW5
{
    abstract class TriangleFactory
    {
        public abstract Triangle CreateTriangle(double side1, double side2, double side3);
    }
}
