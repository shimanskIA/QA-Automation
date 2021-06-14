using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task3;

namespace MSTestsForTask3
{
    [TestClass]
    public class HelperMethodesTests
    {
        [TestMethod]
        [DataRow(100, 2, "1100100")]
        [DataRow(0, 2, "0")]
        [DataRow(2, 3, "2")]
        [DataRow(255, 2, "11111111")]
        [DataRow(256, 2, "100000000")]
        [DataRow(256, 1, "There's no sense in choosing notation less than 1 or you've chosen negative number")]
        [DataRow(256, -10, "There's no sense in choosing notation less than 1 or you've chosen negative number")]
        [DataRow(-100, 2, "There's no sense in choosing notation less than 1 or you've chosen negative number")]
        public void ConvertFrom10Test(int number, int notation, string result)
        {
            Assert.AreEqual(result, Helpers.ConvertFrom10(number, notation));
        }
    }
}
