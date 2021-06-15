using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Task3;

namespace MSTestsForTask3
{
    [TestClass]
    public class HelperMethodesTests
    {

        [TestMethod]
        [DataRow((uint)100, (uint)2, "1100100")]
        [DataRow((uint)0, (uint)2, "0")]
        [DataRow((uint)2, (uint)3, "2")]
        [DataRow((uint)255, (uint)2, "11111111")]
        [DataRow((uint)256, (uint)2, "100000000")]
        public void ConvertFrom10Test(uint number, uint notation, string result)
        {
            Assert.AreEqual(result, Helpers.ConvertFrom10(number, notation));
        }

        [TestMethod]
        [DataRow("100", "2")]
        [DataRow("100", "20")]

        public void ValidatepositiveTest(string value1, string value2)
        {
            Assert.IsTrue(Helpers.Validate(value1, value2));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "Input notationt is out of bound (2 : 20)")]
        [DataRow("100", "1")]
        [DataRow("100", "21")]

        public void ValidateArgumentOutOfRangeExceptionTest(string value1, string value2)
        {
            Helpers.Validate(value1, value2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Input symbols are not even a numbers")]
        [DataRow("text", "text")]

        public void ValidateArgumentExceptionTest(string value1, string value2)
        {
            Helpers.Validate(value1, value2);
        }
    }
}
