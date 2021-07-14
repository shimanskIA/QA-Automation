using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Task11;

namespace MSTestsForTask11
{
    [TestClass]
    public class StringLengthCalculatingMethodsTests
    {
        private static readonly Func<int, string, char> _getNextSymbol = StringHelper.GetNextSymbol;
        private static readonly Func<int, string, char> _getNextNumber = StringHelper.GetNextNumber;

        [TestMethod]
        [DataRow("aaaaaaaaa", 1)]
        [DataRow("aaaaabaaa", 2)]
        [DataRow("aA1@/*-&%$_?><[]+!~#;^()=", 25)]
        [DataRow("abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ", 52)]
        [DataRow(null, 0)]
        [DataRow("", 0)]

        public void FindLongestStringPositiveTest(string inputString, int result)
        {
            Assert.IsTrue(StringHelper.FindLongestStringLength(inputString) == result);
        }

        [TestMethod]
        [DataRow("aaaaaaaaa", 9)]
        [DataRow("aaaaabaaa", 5)]
        [DataRow("aA1@/*-&%$_?><[]+!~#;^()=", 1)]
        [DataRow("abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ", 1)]
        [DataRow(null, 1)]
        [DataRow("", 1)]

        public void FindLongestStringNegativeTest(string inputString, int result)
        {
            Assert.IsFalse(StringHelper.FindLongestStringLength(inputString) == result);
        }

        [TestMethod]
        [DynamicData(nameof(GetDataForFindLongestStringLengthWithSameElementsPositiveTest), DynamicDataSourceType.Method)]

        public void FindLongestStringLengthWithSameElementsPositiveTest(string inputString, int result, Func<int, string, char> getNext)
        {
            Assert.IsTrue(StringHelper.FindLongestStringLengthWithTheSameElements(inputString, getNext) == result);
        }

        public static IEnumerable<object[]> GetDataForFindLongestStringLengthWithSameElementsPositiveTest()
        {
            yield return new object[] { "abcdddd5555ggggrededwsuuuuuuudshjds", 7, _getNextSymbol };
            yield return new object[] { "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ", 1, _getNextSymbol };
            yield return new object[] { "0123456789", 0, _getNextSymbol };
            yield return new object[] { "1@/*-&%$_?><[]+!~#;^()=", 0, _getNextSymbol };
            yield return new object[] { "aaaa", 4, _getNextSymbol };
            yield return new object[] { "zzzz", 4, _getNextSymbol };
            yield return new object[] { "AAAA", 4, _getNextSymbol };
            yield return new object[] { "ZZZZ", 4, _getNextSymbol };
            yield return new object[] { "abcdddd5555ggggrededwsuuuuuuudshjds", 4, _getNextNumber };
            yield return new object[] { "01234567890123456789", 1, _getNextNumber };
            yield return new object[] { "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ", 0, _getNextNumber };
            yield return new object[] { "aA@/*-&%$_?><[]+!~#;^()=", 0, _getNextNumber };
            yield return new object[] { "0000", 4, _getNextNumber };
            yield return new object[] { "9999", 4, _getNextNumber };
        }

        [TestMethod]
        [DynamicData(nameof(GetDataForFindLongestStringLengthWithSameElementsNegativeTest), DynamicDataSourceType.Method)]

        public void FindLongestStringLengthWithSameElementsNegativeTest(string inputString, int result, Func<int, string, char> getNext)
        {
            Assert.IsFalse(StringHelper.FindLongestStringLengthWithTheSameElements(inputString, getNext) == result);
        }

        public static IEnumerable<object[]> GetDataForFindLongestStringLengthWithSameElementsNegativeTest()
        {
            yield return new object[] { "abcdddd5555ggggrededwsuuuuuuudshjds", 6, _getNextSymbol };
            yield return new object[] { "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ", 52, _getNextSymbol };
            yield return new object[] { "0123456789", 10, _getNextSymbol };
            yield return new object[] { "1@/*-&%$_?><[]+!~#;^()=", 1, _getNextSymbol };
            yield return new object[] { "aaaa", 0, _getNextSymbol };
            yield return new object[] { "zzzz", 0, _getNextSymbol };
            yield return new object[] { "AAAA", 0, _getNextSymbol };
            yield return new object[] { "ZZZZ", 0, _getNextSymbol };
            yield return new object[] { "@@@@", 4, _getNextSymbol };
            yield return new object[] { "[[[[", 4, _getNextSymbol };
            yield return new object[] { "''''", 4, _getNextSymbol };
            yield return new object[] { "{{{{", 4, _getNextSymbol };
            yield return new object[] { "abcdddd5555ggggrededwsuuuuuuudshjds", 5, _getNextNumber };
            yield return new object[] { "01234567890123456789", 2, _getNextNumber };
            yield return new object[] { "01234567890123456789", 20, _getNextNumber };
            yield return new object[] { "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ", 52, _getNextNumber };
            yield return new object[] { "aA@/*-&%$_?><[]+!~#;^()=", 2, _getNextNumber };
            yield return new object[] { "0000", 0, _getNextNumber };
            yield return new object[] { "9999", 0, _getNextNumber };
            yield return new object[] { "::::", 4, _getNextNumber };
            yield return new object[] { "////", 4, _getNextNumber };
        }

    }
}
