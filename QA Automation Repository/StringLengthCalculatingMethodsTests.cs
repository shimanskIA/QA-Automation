using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task1;

namespace MSTestsForTask1
{
    [TestClass]
    public class StringLengthCalculatingMethodsTests
    {
        [TestMethod]
        [DataRow("aaaaaaaaa", 1)]
        [DataRow("aaaaabaaa", 2)]
        [DataRow("aA1@/*-&%$_?><[]+!~#;^()=", 25)]
        [DataRow("abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ", 52)]
        [DataRow(null, 0)]
        [DataRow("", 0)]

        public void FindLongestStringTest(string inputString, int result)
        {
            Assert.AreEqual(result, Helper.FindLongestStringLength(inputString));
        }
    }
}
