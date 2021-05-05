﻿using System;
using System.Collections.Generic;
using System.Text;

namespace HW5
{
    class BasicTriangleBuilder : TriangleBuilder
    {
        // description of an element in chain
        public override Triangle HandleTriangleRequest(Point point1, Point point2, Point point3)
        {
            return new BasicTriangle(point1, point2, point3); // creating new triangle
        }
    }
}
