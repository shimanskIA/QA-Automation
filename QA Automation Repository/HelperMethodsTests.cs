using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Task5.Helpers;

namespace MSTestsForTask5
{
    [TestClass]
    public class HelperMethodsTests
    {
        [TestMethod]
        [DataRow(1, 1, 1)]
        [DataRow(0, 0, 0)]
        [DataRow(1.5, 1.5, 2.5)]
        [DataRow(Double.MaxValue, Double.MaxValue, Double.MaxValue)]

        public void ValidateMethodPositiveTest(double x, double y, double z)
        {
            Assert.IsTrue(Helper.Validate(x, y, z));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "coordinates can not have negative values")]
        [DataRow(-1, -1, -1)]
        [DataRow(-1.5, -1.5, -2.5)]
        [DataRow(Double.MinValue, Double.MinValue, Double.MinValue)]


        public void ValidateMethodNegativeTest(double x, double y, double z)
        {
            Assert.IsTrue(Helper.Validate(x, y, z));
        }
    }
}
