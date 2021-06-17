using System;
using Task5.Helpers;
using Task5.Interfaces;

namespace Task5.Entities
{
    public class Bird : IFlyable
    {
        public Coordinate ActualCoordinate { get; set; } // coordinates are given in kilometers
        public BirdSpecies Species { get; set; } 
        public bool IsExtincting { get; set; } // whether this species is in a 'red book'

        public Bird(Coordinate coordinate, BirdSpecies species, bool isExtincting)
        {
            ActualCoordinate = coordinate;
            Species = species;
            IsExtincting = isExtincting;
        }

        public Bird()
        {
            ActualCoordinate = default;
            Species = default;
            IsExtincting = default;
        }

        public void FlyTo(Coordinate coordinate) // changes the actual coordinate if distance is less than 1500 km
        {
            if (ActualCoordinate.GetDistance(coordinate) <= 1500)
            {
                ActualCoordinate.X = coordinate.X;
                ActualCoordinate.Y = coordinate.Y;
                ActualCoordinate.Z = coordinate.Z;
            }
            else
            {
                throw new ArgumentOutOfRangeException("birds are not able to fly more than 1500 km");
            }
        }

        public double GetFlyTime(Coordinate coordinate) // speed chosen randomly from 0 to 20 km/h
        {
            Random random = new Random();
            double speed = 20 * random.NextDouble();
            return ActualCoordinate.GetDistance(coordinate) / speed;
        }
    }
}
