using System;
using System.Collections.Generic;
using System.Text;

namespace Task5.Entities
{
    public abstract class FlyingObject
    {
        public Coordinate ActualCoordinate { get; set; } // coordinates are given in kilometers

        public FlyingObject(Coordinate coordinate)
        {
            ActualCoordinate = new Coordinate(coordinate.X, coordinate.Y, coordinate.Z);
        }

        public FlyingObject()
        {
            ActualCoordinate = default;
        }
    }
}
