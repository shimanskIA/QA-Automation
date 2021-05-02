using System;
using System.Collections.Generic;
using System.Text;

namespace HW5
{
    // class used for creating a needed type of triangle
    class TriangleBuilder
    {
        
        public Triangle CreateTriangle(Point point1, Point point2, Point point3)
        {
            // creating of the chain of responsibilities
            TriangleHandler h1 = new RightTriangleHandler();
            TriangleHandler h2 = new EquilateralTriangleHandler();
            TriangleHandler h3 = new IsoscelesTriangleHandler();
            TriangleHandler h4 = new BasicTriangleHandler();
            h1.Successor = h2;
            h2.Successor = h3;
            h3.Successor = h4;
            // start of processing
            h1.HandleTriangleRequest(point1, point2, point3);
            List<TriangleHandler> triangle_handler_array = new List<TriangleHandler>() { h1, h2, h3, h4 };
            foreach (TriangleHandler th in triangle_handler_array)
            {
                if (th.OutputTriangle != null)
                {
                    return th.OutputTriangle; // choosing wright element
                }
            }
            return null;
        }
    }
}
