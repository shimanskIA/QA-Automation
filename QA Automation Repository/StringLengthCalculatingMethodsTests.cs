using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task1;

namespace MSTestsForTask1
{
    [TestClass]
    public class StringLengthCalculatingMethodsTests
    {
        [TestMethod]
        [DataRow(5, "aaaaa", 0)]
        [DataRow(4, "aaaaa", 1)]
        [DataRow(0, "aaaaa", 1)]
        [DataRow(0, "aA1@/*-&%$_?><[]+!~#;^()=", 25)]
        [DataRow(0, "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ", 52)]
        [DataRow(0, "aaabcaaaa", 1)]
        [DataRow(0, "abcabcaaaa", 3)]
        [DataRow(0, null, 0)]
        [DataRow(0, "", 0)]

        public void FindLongestStringStartingFromAnElementNumberTest(int startSymbolNumber, string inputString, int result)
        {
            Assert.AreEqual(result, Helper.FindLongestStringLengthStartingFormAnElementNumber(startSymbolNumber, inputString));
        }

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
