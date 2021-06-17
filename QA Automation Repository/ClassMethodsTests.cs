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
        private readonly Coordinate _coordinate = new Coordinate(1, 1, 1);
        private readonly Bird _bird;
        private readonly Plane _plane;
        private readonly Drone _drone;

        public ClassMethodsTests()
        {
            _bird = new Bird(_coordinate, BirdSpecies.Raven, false);
            _plane = new Plane(_coordinate, PlaneManufacturers.Boeing, 13000.5, 900.8, 4, 19.35);
            _drone = new Drone(_coordinate, 1000, 8000, 1200);
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

        /*[TestMethod]
        [DynamicData(nameof(GetDataForBirdGetFlyTimeTest), DynamicDataSourceType.Method)]

        public void BirdGetFlyTimePositiveTest(IFlyable flyableObject, Coordinate coordinate, double resultTime)
        {
            Assert.IsTrue(flyableObject.GetFlyTime(coordinate) - resultTime < 1e-10);
        }

        public static IEnumerable<object[]> GetDataForBirdGetFlyTimeTest()
        {
            yield return new object[] { _bird, };
        }*/

    }
}
