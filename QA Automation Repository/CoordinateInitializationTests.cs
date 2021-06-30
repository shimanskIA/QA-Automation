using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Task5.Entities;

namespace MSTestsForTask5
{
    [TestClass]

    public class CoordinateInitializationTests
    {
        private Coordinate _coordinate;

        public CoordinateInitializationTests()
        {
            _coordinate = new Coordinate(1, 1, 1);
        }

        [TestMethod]
        [DataRow(1, 1, 1)]
        [DataRow(0, 0, 0)]
        [DataRow(9.999e149, 0, 0)]
        [DataRow(0, 9.999e149, 0)]
        [DataRow(0, 0, 9.999e149)]
        [DataRow(9.999e149, 9.999e149, 9.999e149)]

        public void CoordinateSuccefullCreationTest(double x, double y, double z)
        {
            new Coordinate(x, y, z);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "coordinates can not have negative or too big (>=1e154) values")]

        [DataRow(1, 1, -1)]
        [DataRow(-1, 1, 1)]
        [DataRow(1, -1, 1)]
        [DataRow(-1, -1, -1)]
        [DataRow(1e150, 1, 1)]
        [DataRow(1, 1e150, 1)]
        [DataRow(1, 1, 1e150)]
        [DataRow(1e150, 1e150, 1e150)]

        public void CoordinateCreationExceptionTest(double x, double y, double z)
        {
            new Coordinate(x, y, z);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "coordinates can not have negative or too big (>=1e154) values")]
        [DataRow(1, 1, -1)]
        [DataRow(-1, 1, 1)]
        [DataRow(1, -1, 1)]
        [DataRow(-1, -1, -1)]
        [DataRow(1e150, 1, 1)]
        [DataRow(1, 1e150, 1)]
        [DataRow(1, 1, 1e150)]
        [DataRow(1e150, 1e150, 1e150)]

        public void CoordinateInitializationExceptionTest(double x, double y, double z)
        {
            _coordinate.X = x;
            _coordinate.Y = y;
            _coordinate.Z = z;
        }

        [TestMethod]
        [DataRow(1, 1, 1)]
        [DataRow(0, 0, 0)]
        [DataRow(9.999e149, 0, 0)]
        [DataRow(0, 9.999e149, 0)]
        [DataRow(0, 0, 9.999e149)]
        [DataRow(9.999e149, 9.999e149, 9.999e149)]
        [DataRow(24524, 23748, 4234.6)]

        public void CoordinateSuccefullInitializationTest(double x, double y, double z)
        {
            _coordinate.X = x;
            _coordinate.Y = y;
            _coordinate.Z = z;
        }
    }
}
