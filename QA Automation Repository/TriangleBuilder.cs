using System;
using System.Collections.Generic;
using System.Text;

namespace HW5
{
    class TriangleBuilder
    {
        
        public Triangle CreateTriangle(double side1, double side2, double side3)
        {
            TriangleHandler h1 = new RightTriangleHandler();
            TriangleHandler h2 = new IsoscelesTriangleHandler();
            TriangleHandler h3 = new EquilateralTriangleHandler();
            TriangleHandler h4 = new BasicTriangleHandler();
            h1.Successor = h2;
            h2.Successor = h3;
            h3.Successor = h4;
            h1.HandleTriangleRequest(side1, side2, side3);
            List<TriangleHandler> triangle_handler_array = new List<TriangleHandler>() { h1, h2, h3, h4 };
            foreach (TriangleHandler th in triangle_handler_array)
            {
                if (th.OutputTriangle != null)
                {
                    return th.OutputTriangle;
                }
            }
            return new BasicTriangle(0, 0, 0);
        }
    }
}
