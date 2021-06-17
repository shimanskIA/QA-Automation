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
            if (coordinate.X < 1e154 && coordinate.Y < 1e154 && coordinate.Z < 1e154)
            {
                return Math.Sqrt(Math.Pow((coordinate.X - X), 2) + Math.Pow((coordinate.Y - Y), 2) + Math.Pow((coordinate.Z - Z), 2));
            }
            else
            {
                throw new ArgumentOutOfRangeException("the square of the argument must not exceed maximal double value");
            }
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType().Equals(typeof(Coordinate)))
            {
                if (Math.Abs((obj as Coordinate).X - X) < 1e-10 &&
                    Math.Abs((obj as Coordinate).Y - Y) < 1e-10 &&
                    Math.Abs((obj as Coordinate).Z - Z) < 1e-10)
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
    }
}
