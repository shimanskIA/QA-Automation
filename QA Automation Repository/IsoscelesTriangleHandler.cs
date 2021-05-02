using System;
using System.Collections.Generic;
using System.Text;

namespace HW5
{
    class IsoscelesTriangleHandler : TriangleHandler
    {
        // description of an element in chain
        public override void HandleTriangleRequest(Point point1, Point point2, Point point3)
        {
            try
            {
                IsoscelesTriangleFactory isosceles_triangle_factory = new IsoscelesTriangleFactory();
                OutputTriangle = isosceles_triangle_factory.CreateTriangle(point1, point2, point3);
            }
            catch
            {
                if (Successor != null)
                {
                    Successor.HandleTriangleRequest(point1, point2, point3);
                }
            }
        }
    }
}
