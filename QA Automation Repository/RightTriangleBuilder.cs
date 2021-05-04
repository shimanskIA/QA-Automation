using System;
using System.Collections.Generic;
using System.Text;

namespace HW5
{
    class RightTriangleBuilder : TriangleBuilder
    {
        // description of an element in chain 
        public override Triangle HandleTriangleRequest(Point point1, Point point2, Point point3)
        {

            try
            {
                return new RightTriangle(point1, point2, point3); // creating new triangle
            }
            catch
            {
                if (Successor != null)
                {
                    return Successor.HandleTriangleRequest(point1, point2, point3);
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
