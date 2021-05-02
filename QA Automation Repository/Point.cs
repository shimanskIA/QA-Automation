using System;
using System.Collections.Generic;
using System.Text;

namespace HW5
{
    // class describes a geometrical point
    class Point
    {
        public double X { get; set; } // in centimeters
        public double Y { get; set; } // in centimeters

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }
    }
}
