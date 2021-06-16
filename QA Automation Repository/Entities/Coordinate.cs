using System;
using Task5.Helpers;

namespace Task5.Entities
{
    public class Coordinate
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public Coordinate(double x, double y, double z)
        {
            if (Helper.Validate(x, y, z))
            {
                X = x;
                Y = y;
                Z = z;
            }
        }

        public Coordinate()
        {
            X = default;
            Y = default;
            Z = default;
        }

        public double GetDistance(Coordinate coordinate)
        {
            return Math.Sqrt(Math.Pow((coordinate.X - X), 2) + Math.Pow((coordinate.Y - Y), 2) + Math.Pow((coordinate.Z - Z), 2));
        }
    }
}
