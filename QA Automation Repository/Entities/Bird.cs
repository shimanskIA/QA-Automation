using System;
using Task5.Helpers;
using Task5.Interfaces;

namespace Task5.Entities
{
    class Bird : IFlyable
    {
        public Coordinate ActualCoordinate { get; set; }
        public BirdSpecies Species { get; set; }
        public bool IsExtincting { get; set; }

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

        public void FlyTo(Coordinate coordinate)
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

        public double GetFlyTime(Coordinate coordinate)
        {
            Random random = new Random();
            double speed = 20 * random.NextDouble();
            return ActualCoordinate.GetDistance(coordinate) / speed;
        }
    }
}
