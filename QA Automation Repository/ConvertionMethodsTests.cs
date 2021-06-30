using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Task3;

namespace MSTestsForTask3
{
    [TestClass]
    public class ConvertionMethodsTests
    {

        [TestMethod]
        [DataRow((uint)100, (uint)2, "1100100")]
        [DataRow((uint)0, (uint)2, "0")]
        [DataRow((uint)2, (uint)3, "2")]
        [DataRow((uint)255, (uint)2, "11111111")]
        [DataRow((uint)256, (uint)2, "100000000")]
        [DataRow((uint)32432743, (uint)16, "1EEE267")]
        public void ConvertFrom10Test(uint number, uint notation, string result)
        {
            Assert.AreEqual(result, Helper.ConvertNumberFrom10NotationToAnyOtherNotation(number, notation));
        }
    }
}
