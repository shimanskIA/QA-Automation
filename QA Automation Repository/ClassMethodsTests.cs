using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Task5.Entities;
using Task5.Helpers;
using Task5.Interfaces;

namespace MSTestsForTask5
{
    [TestClass]
    public class ClassMethodsTests
    {
        private static readonly Coordinate _coordinate = new Coordinate(1, 1, 1);
        private static readonly double _speed = new Random().NextDouble() * 20;
        private readonly Bird _bird;
        private readonly Plane _plane;
        private readonly Drone _drone;

        public ClassMethodsTests()
        {
            _bird = new Bird(_coordinate, BirdSpecies.Raven, false, _speed);
            _plane = new Plane(_coordinate, PlaneManufacturers.Boeing, 13000.5, 900.8, 205.6, 4, 19.35);
            _drone = new Drone(_coordinate, 1000, 8000, 1200, 80);
        }

        [TestMethod]
        [DynamicData(nameof(GetDataForCoordinateEqualsPositiveTest), DynamicDataSourceType.Method)]

        public void CoordinateEqualsPositiveTest(Coordinate coordinate)
        {
            Assert.IsTrue(_coordinate.Equals(coordinate));
        }

        public static IEnumerable<object[]> GetDataForCoordinateEqualsPositiveTest()
        {
            yield return new object[] { new Coordinate(1, 1, 1) };
            yield return new object[] { new Coordinate(1.000000000000001, 1.00000000000000000001, 1) };
            yield return new object[] { new Coordinate(1.6 - 0.6, 0.7 + 0.1 + 0.2, 1) };
        }

        [TestMethod]
        [DynamicData(nameof(GetDataForCoordinateEqualsNegativeTest), DynamicDataSourceType.Method)]

        public void CoordinateEqualsNegativeTest(Coordinate coordinate)
        {
            Assert.IsFalse(_coordinate.Equals(coordinate));
        }

        public static IEnumerable<object[]> GetDataForCoordinateEqualsNegativeTest()
        {
            yield return new object[] { new Coordinate(1, 1, 2) };
            yield return new object[] { new Coordinate(5, 5, 5) };
            yield return new object[] { new Coordinate(1.0001, 1, 1) };
            yield return new object[] { new Coordinate(1, 1.0001, 1) };
            yield return new object[] { new Coordinate(1, 1, 1.0001) };
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
        [DynamicData(nameof(GetDataForGetDistanceExceptionTest), DynamicDataSourceType.Method)]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "the square of the argument must not exceed maximal double value")]

        public void GetDistanceExceptionTest(Coordinate coordinate)
        {
            _coordinate.GetDistance(coordinate);
        }

        public static IEnumerable<object[]> GetDataForGetDistanceExceptionTest()
        {
            yield return new object[] { new Coordinate(1e154, 0, 0) };
            yield return new object[] { new Coordinate(0, 1e154, 0) };
            yield return new object[] { new Coordinate(0, 0, 1e154) };
            yield return new object[] { new Coordinate(1e154, 1e154, 1e154) };
            yield return new object[] { new Coordinate(Double.MaxValue, 1, 11) };
        }

        
        [TestMethod]
        [DynamicData(nameof(GetDataForBirdFlyToMethodPositiveTest), DynamicDataSourceType.Method)]

        public void BirdFlyToMethodPositiveTest(Coordinate coordinate)
        {
            _bird.FlyTo(coordinate);
            Assert.IsTrue(_bird.ActualCoordinate.Equals(coordinate));
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
            yield return new object[] { new Coordinate(Double.MaxValue, 1, 1) };
            yield return new object[] { new Coordinate(1, Double.MaxValue, 1) };
            yield return new object[] { new Coordinate(1, 1, Double.MaxValue) };
        }

        [TestMethod]
        [DynamicData(nameof(GetDataForPlaneFlyToMethodPositiveTest), DynamicDataSourceType.Method)]

        public void PlaneFlyToMethodPositiveTest(Coordinate coordinate, Coordinate resultCoordinate)
        {
            _plane.FlyTo(coordinate);
            Assert.IsTrue(_plane.ActualCoordinate.Equals(resultCoordinate));
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
            Assert.IsTrue(_drone.ActualCoordinate.Equals(coordinate));
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
            yield return new object[] { new Coordinate(Double.MaxValue, 1, 1) };
            yield return new object[] { new Coordinate(1, Double.MaxValue, 1) };
            yield return new object[] { new Coordinate(1, 1, Double.MaxValue) };
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
            yield return new object[] { new Bird(_coordinate, BirdSpecies.Raven, false, _speed), new Coordinate(Double.MaxValue, 1, 1) };
            yield return new object[] { new Drone(_coordinate, 2000, 6.5, 950, 45), new Coordinate(1, 1, 952) };
            yield return new object[] { new Drone(_coordinate, 2000, 6.5, 950, 45), new Coordinate(Double.MaxValue, 1, 1) };
            yield return new object[] { new Plane(_coordinate, PlaneManufacturers.Airbus, 11, 950, 220, 4, 33.5), new Coordinate(1, 1, 25002) };
            yield return new object[] { new Plane(_coordinate, PlaneManufacturers.Airbus, 11, 950, 220, 4, 33.5), new Coordinate(Double.MaxValue, 100, 100) };
        }

        private static double GetTimeForPlane(double takeoffSpeed, double maximalSpeed, double distance) // when we imagine that someone else wrote GetFlyTime() method in task5 for plane and i have to test it
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

    }
}
