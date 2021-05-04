using System;
using System.Collections.Generic;
using System.Text;

namespace HW5
{
    // enumeration with colors
    enum Colors
    {
        Red,
        Green,
        Blue,
        Yellow,
        Black,
        Orange,
        Purple,
        White
    }

    abstract class Triangle : IPointValidation
    {
        public Point Point1 { get; set; }
        public Point Point2 { get; set; }
        public Point Point3 { get; set; }
        public Colors Color { get; protected set; }

        public Triangle(Point point1, Point point2, Point point3)
        {
            if (Validate(point1, point2, point3))
            {
                Point1 = point1;
                Point2 = point2;
                Point3 = point3;
            }
            else
            {
                throw new Exception("The points lie on the same line");
            }
        }

        public abstract double CalculateArea();

        // methode to check if three point are not on the same line
        public bool Validate(Point point1, Point point2, Point point3)
        {
            return Math.Abs((point2.X - point1.X) * (point3.Y - point1.Y) - (point3.X - point1.X) * (point2.Y - point1.Y)) > 1e-10; // using 1e-10 as epsilon
        }
    }
}
