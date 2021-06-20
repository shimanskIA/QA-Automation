using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.XmlDiffPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using Task4.Entities.Details;
using Task4.Entities.Vehicles;
using Task4.Helpers;

namespace MSTestsForTask4
{
    [TestClass]
    public class HelperMethodsTests
    {
        private static readonly Car _auto1 = new Car(Manufacturers.BMW,
                new Engine(250, 2.5, EngineTypes.Petrol, 123),
                new Chassis(4, 4000, 321),
                new Transmission("2x2", 6, Manufacturers.BMW),
                4);
        private static readonly Car _auto2 = new Car(Manufacturers.Mitsubishi,
            new Engine(90, 1.1, EngineTypes.Hybrid, 123877),
            new Chassis(4, 4000, 321),
            new Transmission("2x2", 5, Manufacturers.Mitsubishi),
            4);
        private static readonly Bus _bus1 = new Bus(Manufacturers.Mercedes,
            new Engine(385, 6.2, EngineTypes.Diesel, 777),
            new Chassis(6, 2000, 751),
            new Transmission("2x4", 7, Manufacturers.Mercedes),
            48,
            2);
        private static readonly Lorry _lorry1 = new Lorry(Manufacturers.Citroen,
            new Engine(350, 5.45, EngineTypes.Diesel, 500500),
            new Chassis(4, 1200, 123789),
            new Transmission("2x2", 6, Manufacturers.Kia),
            5000);
        private static readonly Scooter _scooter1 = new Scooter(Manufacturers.Ducati,
            new Engine(290, 2.2, EngineTypes.Petrol, 222222),
            new Chassis(2, 250, 123784),
            new Transmission("1x1", 8, Manufacturers.Ferrari),
            5000);
        private static readonly List<Vehicle> _vehiclesForPositiveTest = new List<Vehicle>() { _auto1, _bus1, _lorry1, _scooter1, _auto2 };
        private static readonly List<Vehicle> _vehiclesForNegativeTest = new List<Vehicle>() { _auto1, _scooter1, _auto2 };

        private static readonly string resultFileName = "Vehicles.xml";
        private static readonly string fileForPositiveTestName = "VehiclesPositiveTest.xml";
        private static readonly string fileForNegativeTestName = "VehiclesNegativeTest.xml";

        private void XmlWriterMethodPositiveTestHelper<T>(List<T> objects, string fileName, string resFileName)
        {
            Helper.XmlWriter(objects, fileName);
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(fileName);
            XmlDiff xmlDiff = new XmlDiff(XmlDiffOptions.IgnoreChildOrder | XmlDiffOptions.IgnoreNamespaces | XmlDiffOptions.IgnorePrefixes);
            Assert.IsTrue(xmlDiff.Compare(fileName, resFileName, false));
        }

        [TestMethod]
        [DynamicData(nameof(GetDataXmlWriterMethodPositiveTest), DynamicDataSourceType.Method)]

        public void XmlWriterMethodPositiveTest(List<Vehicle> objects, string fileName, string resFileName)
        {
            XmlWriterMethodPositiveTestHelper(objects, fileName, resFileName);
        }

        public static IEnumerable<object[]> GetDataXmlWriterMethodPositiveTest()
        {
            yield return new object[] { _vehiclesForPositiveTest, fileForPositiveTestName,  resultFileName};
        }

        private void XmlWriterMethodNegativeTestHelper<T>(List<T> objects, string fileName, string resFileName)
        {
            Helper.XmlWriter(objects, fileName);
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(fileName);
            XmlDiff xmlDiff = new XmlDiff(XmlDiffOptions.IgnoreChildOrder | XmlDiffOptions.IgnoreNamespaces | XmlDiffOptions.IgnorePrefixes);
            Assert.IsFalse(xmlDiff.Compare(fileName, resFileName, false));
        }

        [TestMethod]
        [DynamicData(nameof(GetDataXmlWriterMethodNegativeTest), DynamicDataSourceType.Method)]

        public void XmlWriterMethodNegativeTest(List<Vehicle> objects, string fileName, string resFileName)
        {
            XmlWriterMethodNegativeTestHelper(objects, fileName, resFileName);
        }

        public static IEnumerable<object[]> GetDataXmlWriterMethodNegativeTest()
        {
            yield return new object[] { _vehiclesForNegativeTest, fileForNegativeTestName, resultFileName };
        }

        private void XmlReaderMethodPostiveTestHelper<T>(List<T> objects, string fileName)
        {
            Assert.IsTrue(objects.SequenceEqual(Helper.XmlReader<T>(fileName)));
        }

        [TestMethod]
        [DynamicData(nameof(GetDataXmReaderMethodPositiveTest), DynamicDataSourceType.Method)]

        public void XmlReaderMethodPositiveTest(List<Vehicle> objects, string fileName)
        {
            XmlReaderMethodPostiveTestHelper(objects, fileName);
        }

        public static IEnumerable<object[]> GetDataXmReaderMethodPositiveTest()
        {
            yield return new object[] { _vehiclesForPositiveTest, resultFileName };
        }

        private void XmlReaderMethodNegativeTestHelper<T>(List<T> objects, string fileName)
        {
            Assert.IsFalse(objects.SequenceEqual(Helper.XmlReader<T>(fileName)));
        }

        [TestMethod]
        [DynamicData(nameof(GetDataXmReaderMethodNegativeTest), DynamicDataSourceType.Method)]

        public void XmlReaderMethodNegativeTest(List<Vehicle> objects, string fileName)
        {
            XmlReaderMethodNegativeTestHelper(objects, fileName);
        }

        public static IEnumerable<object[]> GetDataXmReaderMethodNegativeTest()
        {
            yield return new object[] { _vehiclesForNegativeTest, resultFileName };
        }
    }
}
