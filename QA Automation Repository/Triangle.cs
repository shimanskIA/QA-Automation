using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace HW5
{
    abstract class Triangle
    {
        public double Side1 { get; set; }
        public double Side2 { get; set; }
        public double Side3 { get; set; }
        private Color _color;
        public string GetColor { get { return _color.ToString(); } }
        public Color SetColor { set { _color = value; } }

        public Triangle(double side1, double side2, double side3)
        {
            Side1 = side1;
            Side2 = side2;
            Side3 = side3;
        }

        public abstract double CalculateArea();
    }
}
