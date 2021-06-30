using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Task3;

namespace MSTestsForTask3
{
    [TestClass]
    public class ValidationMethodsTests
    {
        [TestMethod]
        [DataRow("100", "2")]
        [DataRow("100", "20")]

        public void ValidatepositiveTest(string inputString1, string inputString2)
        {
            Assert.IsTrue(Helper.Validate(inputString1, inputString2));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "Input notationt is out of bound (2 : 20)")]
        [DataRow("100", "1")]
        [DataRow("100", "21")]

        public void ValidateArgumentOutOfRangeExceptionTest(string inputString1, string inputString2)
        {
            Helper.Validate(inputString1, inputString2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Input symbols are not even a numbers")]
        [DataRow("text", "text")]

        public void ValidateArgumentExceptionTest(string inputString1, string inputString2)
        {
            Helper.Validate(inputString1, inputString2);
        }
    }
}
