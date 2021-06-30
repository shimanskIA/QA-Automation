using System;
using Task5.Enums;
using Task5.Interfaces;

namespace Task5.Entities
{
    public class Bird : FlyingObject, IFlyable
    {
        private const int _maximalDistance = 1500; // in kilometers
        
        public BirdSpecies Species { get; set; } 

        public bool IsExtincting { get; set; } // whether this species is in a 'red book'

        public double Speed { get; set; } // in km/h

        public Bird(Coordinate coordinate, BirdSpecies species, bool isExtincting, double speed) : base(coordinate)
        {
            Species = species;
            IsExtincting = isExtincting;
            Speed = speed;
        }

        public Bird() : base()
        {
            Species = default;
            IsExtincting = default;
            Speed = default;
        }

        public void FlyTo(Coordinate coordinate) // changes the actual coordinate if distance is less than 1500 km
        {
            if (ActualCoordinate.GetDistance(coordinate) <= _maximalDistance)
            {
                ActualCoordinate.X = coordinate.X;
                ActualCoordinate.Y = coordinate.Y;
                ActualCoordinate.Z = coordinate.Z;
            }
            else
            {
                throw new ArgumentOutOfRangeException("birds are not able to fly more than" + _maximalDistance + "km");
            }
        }

        public double GetFlyTime(Coordinate coordinate) // speed chosen randomly from 0 to 20 km/h
        {
            double distance = ActualCoordinate.GetDistance(coordinate);
            if (distance <= _maximalDistance)
            {
                return ActualCoordinate.GetDistance(coordinate) / Speed;
            }
            else
            {
                throw new ArgumentOutOfRangeException("birds are not able to fly more than" + _maximalDistance +  "km");
            }
        }
    }
}
