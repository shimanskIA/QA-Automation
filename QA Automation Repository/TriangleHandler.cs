using System;
using System.Collections.Generic;
using System.Text;

namespace HW5
{
    abstract class TriangleHandler
    {
        public Triangle OutputTriangle { get; set; }
        public TriangleHandler Successor { get; set; }
        public abstract void HandleTriangleRequest(double side1, double side2, double side3);
    }
}
