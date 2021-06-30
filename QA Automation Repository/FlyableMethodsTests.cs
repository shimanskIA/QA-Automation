using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Task5.Entities;
using Task5.Enums;
using Task5.Interfaces;

namespace MSTestsForTask5
{
    [TestClass]
    public class FlyableMethodsTests
    {
        private static readonly Coordinate _coordinate = new Coordinate(1, 1, 1);
        private static readonly double _speed = new Random().NextDouble() * 20;
        private readonly Bird _bird;
        private readonly Plane _plane;
        private readonly Drone _drone;

        public FlyableMethodsTests()
        {
            _bird = new Bird(_coordinate, BirdSpecies.Raven, false, _speed);
            _plane = new Plane(_coordinate, PlaneManufacturers.Boeing, 13000.5, 900.8, 205.6, 4, 19.35);
            _drone = new Drone(_coordinate, 1000, 8000, 1200, 80);
        }

        [TestMethod]
        [DynamicData(nameof(GetDataForGetDistanceTest), DynamicDataSourceType.Method)]

        public void GetDistanceTest(Coordinate coordinate, double result)
        {
            Assert.AreEqual(result, _coordinate.GetDistance(coordinate));
        }

        public static IEnumerable<object[]> GetDataForGetDistanceTest()
        {
            yield return new object[] { new Coordinate(0, 0, 0), Math.Sqrt(3) };
            yield return new object[] { new Coordinate(100, 100, 100), Math.Sqrt(29403) };
            yield return new object[] { new Coordinate(5.25, 7.5, 3.1415), Math.Sqrt(64.89852225) };
            yield return new object[] { new Coordinate(1, 1, 1), Math.Sqrt(0) };
        }

        
        [TestMethod]
        [DynamicData(nameof(GetDataForBirdFlyToMethodPositiveTest), DynamicDataSourceType.Method)]

        public void BirdFlyToMethodPositiveTest(Coordinate coordinate)
        {
            _bird.FlyTo(coordinate);
            Assert.IsTrue(AreCoordinatesEqual(_bird.ActualCoordinate, coordinate));
        }

        public static IEnumerable<object[]> GetDataForBirdFlyToMethodPositiveTest()
        {
            yield return new object[] { new Coordinate(10, 10, 10) };
            yield return new object[] { new Coordinate(0, 0, 0) };
            yield return new object[] { new Coordinate(1, 1, 1501) };
        }

        [TestMethod]
        [DynamicData(nameof(GetDataForBirdFlyToMethodExceptionTest), DynamicDataSourceType.Method)]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "birds are not able to fly more than 1500 km")]

        public void BirdFlyToMethodExceptionTest(Coordinate coordinate)
        {
            _bird.FlyTo(coordinate);
        }

        public static IEnumerable<object[]> GetDataForBirdFlyToMethodExceptionTest()
        {
            yield return new object[] { new Coordinate(1, 1, 1502) };
            yield return new object[] { new Coordinate(1, 1, 9.999e149) };
            yield return new object[] { new Coordinate(9.999e149, 1, 1) };
            yield return new object[] { new Coordinate(1, 9.999e149, 1) };
        }

        [TestMethod]
        [DynamicData(nameof(GetDataForPlaneFlyToMethodPositiveTest), DynamicDataSourceType.Method)]

        public void PlaneFlyToMethodPositiveTest(Coordinate coordinate, Coordinate resultCoordinate)
        {
            _plane.FlyTo(coordinate);
            Assert.IsTrue(AreCoordinatesEqual(_plane.ActualCoordinate, resultCoordinate));
        }

        public static IEnumerable<object[]> GetDataForPlaneFlyToMethodPositiveTest()
        {
            yield return new object[] { new Coordinate(10, 10, 10), new Coordinate(10, 10, 10) };
            yield return new object[] { new Coordinate(0, 0, 0), new Coordinate(0, 0, 0) };
            yield return new object[] { new Coordinate(1, 1, 25001), new Coordinate(1, 1, 25001) };
            yield return new object[] { new Coordinate(1000000, 1, 1), new Coordinate(100, 100, 100) };
            yield return new object[] { new Coordinate(1, 1, 25500), new Coordinate(100, 100, 100) };
        }

        [TestMethod]
        [DynamicData(nameof(GetDataForDroneFlyToMethodPositiveTest), DynamicDataSourceType.Method)]

        public void DroneFlyToMethodPositiveTest(Coordinate coordinate)
        {
            _drone.FlyTo(coordinate);
            Assert.IsTrue(AreCoordinatesEqual(_drone.ActualCoordinate, coordinate));
        }

        public static IEnumerable<object[]> GetDataForDroneFlyToMethodPositiveTest()
        {
            yield return new object[] { new Coordinate(10, 10, 10) };
            yield return new object[] { new Coordinate(0, 0, 0) };
            yield return new object[] { new Coordinate(1, 1, 1201) };
        }

        [TestMethod]
        [DynamicData(nameof(GetDataForDroneFlyToMethodExceptionTest), DynamicDataSourceType.Method)]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "drones are not able to fly more than maximal distance")]

        public void DroneFlyToMethodExceptionTest(Coordinate coordinate)
        {
            _drone.FlyTo(coordinate);
        }

        public static IEnumerable<object[]> GetDataForDroneFlyToMethodExceptionTest()
        {
            yield return new object[] { new Coordinate(1, 1, 1202) };
            yield return new object[] { new Coordinate(9.999e149, 1, 1) };
            yield return new object[] { new Coordinate(1, 9.999e149, 1) };
            yield return new object[] { new Coordinate(1, 1, 9.999e149) };
        }

        [TestMethod]
        [DynamicData(nameof(GetDataForGetFlyTimePositiveTest), DynamicDataSourceType.Method)]

        public void GetFlyTimePositiveTest(IFlyable flyableObject, Coordinate coordinate, double resultTime)
        {
            Assert.IsTrue(flyableObject.GetFlyTime(coordinate) - resultTime < 1e-10);
        }

        public static IEnumerable<object[]> GetDataForGetFlyTimePositiveTest()
        {
            yield return new object[] { new Bird(_coordinate, BirdSpecies.Raven, false, _speed) , new Coordinate(100, 100, 100), 171.4730299493 / _speed};
            yield return new object[] { new Bird(_coordinate, BirdSpecies.Raven, false, _speed), new Coordinate(4, 5, 6), 7.0710678119 / _speed };
            yield return new object[] { new Drone(_coordinate, 2000, 6.5, 950, 45), new Coordinate(100, 100, 100), 4.1771784434};
            yield return new object[] { new Drone(_coordinate, 2000, 6.5, 950, 45), new Coordinate(4, 5, 6), 9.4280904158 };
            yield return new object[] { new Plane(_coordinate, PlaneManufacturers.Airbus, 11, 950, 220, 4, 33.5), new Coordinate(100, 100, 100), GetTimeForPlane(220, 950, 171.473299491) };
            yield return new object[] { new Plane(_coordinate, PlaneManufacturers.Airbus, 11, 880, 185, 4, 33.5), new Coordinate(1500, 66, 777), GetTimeForPlane(185, 880, 1689.2015865491) };
        }

        [TestMethod]
        [DynamicData(nameof(GetDataForGetFlyTimeExceptionTest), DynamicDataSourceType.Method)]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "this flyable object is not able to fly more than maximal distance")]

        public void GetFlyTimeExceptionTest(IFlyable flyableObject, Coordinate coordinate)
        {
            flyableObject.GetFlyTime(coordinate);
        }

        public static IEnumerable<object[]> GetDataForGetFlyTimeExceptionTest()
        {
            yield return new object[] { new Bird(_coordinate, BirdSpecies.Raven, false, _speed), new Coordinate(1, 1, 1502) };
            yield return new object[] { new Bird(_coordinate, BirdSpecies.Raven, false, _speed), new Coordinate(9.999e149, 1, 1) };
            yield return new object[] { new Drone(_coordinate, 2000, 6.5, 950, 45), new Coordinate(1, 1, 952) };
            yield return new object[] { new Drone(_coordinate, 2000, 6.5, 950, 45), new Coordinate(9.999e149, 1, 1) };
            yield return new object[] { new Plane(_coordinate, PlaneManufacturers.Airbus, 11, 950, 220, 4, 33.5), new Coordinate(1, 1, 25002) };
            yield return new object[] { new Plane(_coordinate, PlaneManufacturers.Airbus, 11, 950, 220, 4, 33.5), new Coordinate(9.999e149, 100, 100) };
        }

        private static double GetTimeForPlane(double takeoffSpeed, double maximalSpeed, double distance)
        {
            double time = 0.0;
            double speed = takeoffSpeed;
            int amountOf10kmSegments = (int)(distance / 10);
            for (int i = 0; i < amountOf10kmSegments; i++)
            {
                time += 10 / speed;
                if (speed > maximalSpeed - 10)
                {
                    speed = maximalSpeed;
                }
                else
                {
                    speed += 10;
                }
            }
            return time + (distance % 10) * speed;
        }

        private static bool AreCoordinatesEqual(Coordinate inputCoordinate1, Coordinate inputCoordinate2)
        {
            if (Math.Abs(inputCoordinate2.X - inputCoordinate1.X) < 1e-10 &&
                Math.Abs(inputCoordinate2.Y - inputCoordinate1.Y) < 1e-10 &&
                Math.Abs(inputCoordinate2.Z - inputCoordinate1.Z) < 1e-10)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
