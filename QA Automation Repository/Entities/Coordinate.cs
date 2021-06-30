using System;

namespace Task5.Entities
{
    public class Coordinate
    {
        private double _x;

        public double X
        { 
            get
            {
                return _x;
            }

            set
            {
                if (value >= 0 && value < 1e150)
                {
                    _x = value;
                }
                else
                {
                    throw new ArgumentException("coordinates can not have negative or too big (>=1e154) values");
                }
            }
        }


        private double _y;

        public double Y
        {
            get
            {
                return _y;
            }

            set
            {
                if (value >= 0 && value < 1e150)
                {
                    _y = value;
                }
                else
                {
                    throw new ArgumentException("coordinates can not have negative or too big (>=1e154) values");
                }
            }
        }

        private double _z;

        public double Z
        {
            get
            {
                return _z;
            }

            set
            {
                if (value >= 0 && value < 1e150)
                {
                    _z = value;
                }
                else
                {
                    throw new ArgumentException("coordinates can not have negative or too big (>=1e154) values");
                }
            }
        }

        public Coordinate(double x, double y, double z)
        {
            if (x >= 0 && x < 1e150 && y >= 0 && y < 1e150 && z >= 0 && z < 1e150)
            {
                X = x;
                Y = y;
                Z = z;
            }
            else
            {
                throw new ArgumentException("coordinates can not have negative or too big (>=1e154) values");
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
