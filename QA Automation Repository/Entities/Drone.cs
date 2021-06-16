using System;

namespace Task5.Entities
{
    class Drone
    {
        public Coordinate ActualCoordinate { get; set; }
        public double Price { get; set; }
        public double MaximalHeight { get; set; }
        public double MaximalDistance { get; set; }

        public Drone(Coordinate coordinate, double price, double maximalHeight, double maximalDistance)
        {
            ActualCoordinate = coordinate;
            Price = price;
            MaximalHeight = maximalHeight;
            MaximalDistance = maximalDistance;
        }

        public Drone()
        {
            ActualCoordinate = default;
            Price = default;
            MaximalHeight = default;
            MaximalDistance = default;
        }

        public void FlyTo(Coordinate coordinate)
        {
            if (ActualCoordinate.GetDistance(coordinate) <= MaximalDistance)
            {
                ActualCoordinate.X = coordinate.X;
                ActualCoordinate.Y = coordinate.Y;
                ActualCoordinate.Z = coordinate.Z;
            }
            else
            {
                throw new ArgumentOutOfRangeException("drones are not able to fly more than " + MaximalDistance + " km");
            }
        }

        public double GetFlyTime(Coordinate coordinate)
        {
            if (ActualCoordinate.GetDistance(coordinate) <= MaximalDistance)
            {
                double speed = 50;
                double baseTime = ActualCoordinate.GetDistance(coordinate) / speed;
                int amountOfStops = (int)(baseTime / (1.0 / 6.0));
                return baseTime + amountOfStops * (1.0 / 60.0);
            }
            else
            {
                throw new ArgumentOutOfRangeException("drones are not able to fly more than " + MaximalDistance + " km");
            }
        }
    }
}
