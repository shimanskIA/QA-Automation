using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace HW5
{
    abstract class Triangle
    {
        public Point Point1 { get; set; }
        public Point Point2 { get; set; }
        public Point Point3 { get; set; }
        private Color _color;
        public string GetColor { get { return _color.ToString(); } }
        public Color SetColor { set { _color = value; } }

        public Triangle(Point point1, Point point2, Point point3)
        {
            if (Math.Abs((point2.X - point1.X) * (point3.Y - point1.Y) - (point3.X - point1.X) * (point2.Y - point1.Y)) > 1e-10)
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
    }
}
