using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.XmlDiffPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Task4.Entities;
using Task4.Entities.Details;
using Task4.Entities.Vehicles;
using Task4.Helpers;

namespace MSTestsForTask4
{
    [TestClass]
    public class CarParkMethodsTests
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
        private static readonly CarPark _carParkForPositiveTest = new CarPark(_vehiclesForPositiveTest);
        private static readonly CarPark _carParkForNegativeTest = new CarPark(_vehiclesForNegativeTest);

        private static readonly string resultFileName = "Vehicles.xml";
        private static readonly string resultFileNameForSaveWithCondition = "Vehicles15.xml";
        private static readonly string fileForPositiveTestName = "VehiclesPositiveTest.xml";
        private static readonly string fileForNegativeTestName = "VehiclesNegativeTest.xml";
        private static readonly string fileForPositiveTestWithConditionName = "Vehicles15PositiveTest.xml";
        private static readonly string fileForNegativeTestWithConditionName = "Vehicles15NegativeTest.xml";

        private static readonly Func<Vehicle, bool> chooseMoreThan15 = x => x.VehicleEngine.Volume >= 1.5;

        [TestMethod]
        [DynamicData(nameof(GetDataSaveToFileMethodPositiveTest), DynamicDataSourceType.Method)]

        public void SaveToFileMethodPositiveTest(string fileName, string resFileName)
        {
            _carParkForPositiveTest.SaveToFile(fileName);
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(fileName);
            XmlDiff xmlDiff = new XmlDiff(XmlDiffOptions.IgnoreChildOrder | XmlDiffOptions.IgnoreNamespaces | XmlDiffOptions.IgnorePrefixes);
            Assert.IsTrue(xmlDiff.Compare(fileName, resFileName, false));
        }

        public static IEnumerable<object[]> GetDataSaveToFileMethodPositiveTest()
        {
            yield return new object[] { fileForPositiveTestName, resultFileName };
        }

        [TestMethod]
        [DynamicData(nameof(GetDataSaveToFileMethodNegativeTest), DynamicDataSourceType.Method)]

        public void SaveToFileMethodNegativeTest(string fileName, string resFileName)
        {
            _carParkForNegativeTest.SaveToFile(fileName);
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(fileName);
            XmlDiff xmlDiff = new XmlDiff(XmlDiffOptions.IgnoreChildOrder | XmlDiffOptions.IgnoreNamespaces | XmlDiffOptions.IgnorePrefixes);
            Assert.IsFalse(xmlDiff.Compare(fileName, resFileName, false));
        }

        public static IEnumerable<object[]> GetDataSaveToFileMethodNegativeTest()
        {
            yield return new object[] { fileForNegativeTestName, resultFileName };
        }

        [TestMethod]
        [DynamicData(nameof(GetDataSaveToFileWithConditionMethodPositiveTest), DynamicDataSourceType.Method)]

        public void SaveToFileWithConditionMethodPositiveTest(Func<Vehicle, bool> function, string fileName, string resFileName)
        {
            _carParkForPositiveTest.SaveToFileWithCondition(fileName, function);
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(fileName);
            XmlDiff xmlDiff = new XmlDiff(XmlDiffOptions.IgnoreChildOrder | XmlDiffOptions.IgnoreNamespaces | XmlDiffOptions.IgnorePrefixes);
            Assert.IsTrue(xmlDiff.Compare(fileName, resFileName, false));
        }

        public static IEnumerable<object[]> GetDataSaveToFileWithConditionMethodPositiveTest()
        {
            yield return new object[] { chooseMoreThan15, fileForPositiveTestWithConditionName, resultFileNameForSaveWithCondition };
        }

        [TestMethod]
        [DynamicData(nameof(GetDataSaveToFileWithConditionMethodNegativeTest), DynamicDataSourceType.Method)]

        public void SaveToFileWithConditionMethodNegativeTest(Func<Vehicle, bool> function, string fileName, string resFileName)
        {
            _carParkForNegativeTest.SaveToFileWithCondition(fileName, function);
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(fileName);
            XmlDiff xmlDiff = new XmlDiff(XmlDiffOptions.IgnoreChildOrder | XmlDiffOptions.IgnoreNamespaces | XmlDiffOptions.IgnorePrefixes);
            Assert.IsFalse(xmlDiff.Compare(fileName, resFileName, false));
        }

        public static IEnumerable<object[]> GetDataSaveToFileWithConditionMethodNegativeTest()
        {
            yield return new object[] { chooseMoreThan15, fileForNegativeTestWithConditionName, resultFileNameForSaveWithCondition };
        }

        private void ReadFromFileMethodPostiveTestHelper<T>(List<T> objects, string fileName)
        {
            Assert.IsTrue(objects.SequenceEqual(_carParkForPositiveTest.ReadFromFile<T>(fileName)));
        }

        [TestMethod]
        [DynamicData(nameof(GetDataReadFromFileMethodPositiveTest), DynamicDataSourceType.Method)]

        public void ReadFromFileMethodPositiveTest(List<Vehicle> objects, string fileName)
        {
            ReadFromFileMethodPostiveTestHelper(objects, fileName);
        }

        public static IEnumerable<object[]> GetDataReadFromFileMethodPositiveTest()
        {
            yield return new object[] { _vehiclesForPositiveTest, resultFileName };
        }

        private void ReadFromFileMethodNegativeTestHelper<T>(List<T> objects, string fileName)
        {
            Assert.IsFalse(objects.SequenceEqual(_carParkForPositiveTest.ReadFromFile<T>(fileName)));
        }

        [TestMethod]
        [DynamicData(nameof(GetDataReadFromFileMethodNegativeTest), DynamicDataSourceType.Method)]

        public void ReadFromFileMethodNegativeTest(List<Vehicle> objects, string fileName)
        {
            ReadFromFileMethodNegativeTestHelper(objects, fileName);
        }

        public static IEnumerable<object[]> GetDataReadFromFileMethodNegativeTest()
        {
            yield return new object[] { _vehiclesForNegativeTest, resultFileName };
        }
    }
}
