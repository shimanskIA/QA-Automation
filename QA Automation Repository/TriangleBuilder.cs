using System;
using System.Collections.Generic;
using System.Text;

namespace HW5
{
    // abstract class used for creating a needed type of triangle
    abstract class TriangleBuilder
    {
        public TriangleBuilder Successor { get; set; } // link to the next element of chain
        public abstract Triangle HandleTriangleRequest(Point point1, Point point2, Point point3); // input processing
        
    }
}
