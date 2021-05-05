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

        public double CountDistance(Point point)
        {
            return Math.Sqrt((X - point.X) * (X - point.X) + (Y - point.Y) * (Y - point.Y));
        }

        // methode to compare two objects
        public override bool Equals(object some_point)
        {
            if (some_point is Point)
            {
                var some_abstract_point = some_point as Point;
                if (some_abstract_point.X - X < 1e-10 && some_abstract_point.Y - Y < 1e-10)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        // methode that return a hash code of the object
        public override int GetHashCode()
        {
            return (X, Y).GetHashCode();
        }
    }
}
