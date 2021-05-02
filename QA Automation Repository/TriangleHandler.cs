using System;
using System.Collections.Generic;
using System.Text;

namespace HW5
{
    // abstract class for chain of responsibilities pattern
    abstract class TriangleHandler
    {
        public Triangle OutputTriangle { get; set; } // field to use as a return value
        public TriangleHandler Successor { get; set; } // link to the next element of chain
        public abstract void HandleTriangleRequest(Point point1, Point point2, Point point3); // input processing
    }
}
