using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.XmlDiffPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using Task8.Entities.Details;
using Task8.Entities.Vehicles;
using Task8.Enums;
using Task8.Helpers;

namespace MSTestsForTask8
{
    [TestClass]
    public class XmlInteractionMethodsTests
    {
        private static readonly Car _auto1 = new Car(ManufacturersForTransmissionsAndVehicles.BMW,
                new Engine(250, 2.5, EngineTypes.Petrol, 123),
                new Chassis(4, 4000, 321),
                new Transmission("2x2", 6, ManufacturersForTransmissionsAndVehicles.BMW),
                4);
        private static readonly Car _auto2 = new Car(ManufacturersForTransmissionsAndVehicles.Mitsubishi,
            new Engine(90, 1.1, EngineTypes.Hybrid, 123877),
            new Chassis(4, 4000, 321),
            new Transmission("2x2", 5, ManufacturersForTransmissionsAndVehicles.Mitsubishi),
            4);
        private static readonly Bus _bus1 = new Bus(ManufacturersForTransmissionsAndVehicles.Mercedes,
            new Engine(385, 6.2, EngineTypes.Diesel, 777),
            new Chassis(6, 2000, 751),
            new Transmission("2x4", 7, ManufacturersForTransmissionsAndVehicles.Mercedes),
            48,
            2);
        private static readonly Lorry _lorry1 = new Lorry(ManufacturersForTransmissionsAndVehicles.Citroen,
            new Engine(350, 5.45, EngineTypes.Diesel, 500500),
            new Chassis(4, 1200, 123789),
            new Transmission("2x2", 6, ManufacturersForTransmissionsAndVehicles.Kia),
            5000);
        private static readonly Scooter _scooter1 = new Scooter(ManufacturersForTransmissionsAndVehicles.Ducati,
            new Engine(290, 2.2, EngineTypes.Petrol, 222222),
            new Chassis(2, 250, 123784),
            new Transmission("1x1", 8, ManufacturersForTransmissionsAndVehicles.Ferrari),
            5000);

        private static readonly List<Vehicle> _vehiclesForPositiveTest = new List<Vehicle>() { _auto1, _bus1, _lorry1, _scooter1, _auto2 };
        private static readonly List<Vehicle> _vehiclesForNegativeTest = new List<Vehicle>() { _auto1, _scooter1, _auto2 };

        private static readonly XmlDiff xmlDiff = new XmlDiff(XmlDiffOptions.IgnoreChildOrder | XmlDiffOptions.IgnoreNamespaces | XmlDiffOptions.IgnorePrefixes);

        private static readonly string resultFileName = "Vehicles.xml";
        private static readonly string fileForPositiveTestName = "VehiclesPositiveTest2.xml";
        private static readonly string fileForNegativeTestName = "VehiclesNegativeTest2.xml";

        private static Action<string, string> fileComparePositive = (x, y) => Assert.IsTrue(xmlDiff.Compare(x, y, false));
        private static Action<string, string> fileCompareNegative = (x, y) => Assert.IsFalse(xmlDiff.Compare(x, y, false));
        private static Action<List<Vehicle>, string> listComparePositive = (x, y) => Assert.IsTrue(x.SequenceEqual(XmlInteractionHelper.ReadFromXmlFile<Vehicle>(y)));
        private static Action<List<Vehicle>, string> listCompareNegative = (x, y) => Assert.IsFalse(x.SequenceEqual(XmlInteractionHelper.ReadFromXmlFile<Vehicle>(y)));

        private void WriteToXmlFileMethodTestHelper<T>(Action<string, string> action, List<T> objects, string fileName, string resFileName)
        {
            XmlInteractionHelper.WriteToXmlFile(objects, fileName);
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(fileName);
            action(fileName, resFileName);
        }

        [TestMethod]
        [DynamicData(nameof(GetDataWriteToXmlFileMethodTest), DynamicDataSourceType.Method)]

        public void WriteToXmlFileMethodTest(Action<string, string> action, List<Vehicle> objects, string fileName, string resFileName)
        {
            WriteToXmlFileMethodTestHelper(action, objects, fileName, resFileName);
        }

        public static IEnumerable<object[]> GetDataWriteToXmlFileMethodTest()
        {
            yield return new object[] { fileComparePositive, _vehiclesForPositiveTest, fileForPositiveTestName, resultFileName };
            yield return new object[] { fileCompareNegative, _vehiclesForNegativeTest, fileForNegativeTestName, resultFileName };
        }

        private void ReadFromXmlFileMethodTestHelper<T>(Action<List<T>, string> action, List<T> objects, string fileName)
        {
            action(objects, fileName);
        }

        [TestMethod]
        [DynamicData(nameof(GetDataReadFromXmlFileMethodTest), DynamicDataSourceType.Method)]

        public void ReadFromXmlFileMethodTest(Action<List<Vehicle>, string> action, List<Vehicle> objects, string fileName)
        {
            ReadFromXmlFileMethodTestHelper(action, objects, fileName);
        }

        public static IEnumerable<object[]> GetDataReadFromXmlFileMethodTest()
        {
            yield return new object[] { listComparePositive, _vehiclesForPositiveTest, resultFileName };
            yield return new object[] { listCompareNegative, _vehiclesForNegativeTest, resultFileName };
        }
    }
}
