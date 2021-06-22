using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.XmlDiffPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using Task4.Entities;
using Task4.Entities.Details;
using Task4.Entities.Vehicles;
using Task4.Helpers;
using Task4.Interfaces;

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

        private static readonly XmlDiff xmlDiff = new XmlDiff(XmlDiffOptions.IgnoreChildOrder | XmlDiffOptions.IgnoreNamespaces | XmlDiffOptions.IgnorePrefixes);

        private static readonly string resultFileName = "Vehicles.xml";
        private static readonly string resultFileNameForSaveWithCondition = "Vehicles15.xml";
        private static readonly string resultFileNameForSaveWithCondition2 = "2x2VehicleTypes.xml";
        private static readonly string resultFileNameForSort = "SortedTransmissions.xml";
        private static readonly string resultFileNameForProection = "LorryAndBusEngines.xml";

        private static readonly string resultTextForCarPark = Helper.resultTextForCarPark;

        private static readonly string fileForPositiveTestName = "VehiclesPositiveTest.xml";
        private static readonly string fileForNegativeTestName = "VehiclesNegativeTest.xml";
        private static readonly string fileForPositiveTestWithConditionName = "Vehicles15PositiveTest.xml";
        private static readonly string fileForNegativeTestWithConditionName = "Vehicles15NegativeTest.xml";
        private static readonly string fileForPositiveTestWithCondition2Name = "Vehicles2x2PositiveTest.xml";
        private static readonly string fileForNegativeTestWithCondition2Name = "Vehicles2x2NegativeTest.xml";
        private static readonly string fileForPositiveSortTestName = "SortedVehiclesPositiveTest.xml";
        private static readonly string fileForNegativeSortTestName = "SortedVehiclesNegativeTest.xml";
        private static readonly string fileForPositiveProectionTestName = "VehiclesProectionPositiveTest.xml";
        private static readonly string fileForNegativeProectionTestName = "VehiclesProectionNegativeTest.xml";

        private static readonly Func<Vehicle, bool> chooseMoreThan15 = x => x.VehicleEngine.Volume >= 1.5;
        private static readonly Func<Vehicle, bool> choose2x2Transmission = x => x.VehicleTransmission.TransmissionType == "2x2";
        private static readonly Func<Vehicle, string> transmissionComparer = x => x.VehicleTransmission.TransmissionType;
        private static readonly Func<Vehicle, bool> chooseVehicleType = x => x.GetType().Equals(typeof(Lorry)) || x.GetType().Equals(typeof(Bus));
        private static readonly Func<Vehicle, SerialClass> proectionCondition = x => new SerialClass(x.VehicleEngine.EngineType, x.VehicleEngine.SerialNumber, x.VehicleEngine.Power);

        private static Action<string, string> fileComparePositive = (x, y) => Assert.IsTrue(xmlDiff.Compare(x, y, false));
        private static Action<string, string> fileCompareNegative = (x, y) => Assert.IsFalse(xmlDiff.Compare(x, y, false));
        private static Action<List<Vehicle>, string> listComparePositive = (x, y) => Assert.IsTrue(x.SequenceEqual(_carParkForPositiveTest.ReadFromFile<Vehicle>(y)));
        private static Action<List<Vehicle>, string> listCompareNegative = (x, y) => Assert.IsFalse(x.SequenceEqual(_carParkForPositiveTest.ReadFromFile<Vehicle>(y)));

        [TestMethod]
        [DynamicData(nameof(GetDataSaveToFileMethodPositiveTest), DynamicDataSourceType.Method)]

        public void SaveToFileMethodPositiveTest(CarPark testCarPark, Action<string, string> assert, string fileName, string resFileName)
        {
            testCarPark.SaveToFile(fileName);
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(fileName);
            assert(fileName, resFileName);
        }

        public static IEnumerable<object[]> GetDataSaveToFileMethodPositiveTest()
        {
            yield return new object[] { _carParkForPositiveTest, fileComparePositive, fileForPositiveTestName, resultFileName };
            yield return new object[] { _carParkForNegativeTest, fileCompareNegative, fileForNegativeTestName, resultFileName };
        }

        [TestMethod]
        [DynamicData(nameof(GetDataSaveToFileWithConditionMethodTest), DynamicDataSourceType.Method)]

        public void SaveToFileWithConditionMethodTest(CarPark testCarPark, Action<string, string> action, Func<Vehicle, bool> function, string fileName, string resFileName)
        {
            testCarPark.SaveToFileWithCondition(fileName, function);
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(fileName);
            action(fileName, resFileName);
        }

        public static IEnumerable<object[]> GetDataSaveToFileWithConditionMethodTest()
        {
            yield return new object[] { _carParkForPositiveTest, fileComparePositive, chooseMoreThan15, fileForPositiveTestWithConditionName, resultFileNameForSaveWithCondition };
            yield return new object[] { _carParkForPositiveTest, fileComparePositive, choose2x2Transmission, fileForPositiveTestWithCondition2Name, resultFileNameForSaveWithCondition2 };
            yield return new object[] { _carParkForNegativeTest, fileCompareNegative, chooseMoreThan15, fileForNegativeTestWithConditionName, resultFileNameForSaveWithCondition };
            yield return new object[] { _carParkForNegativeTest, fileCompareNegative, choose2x2Transmission, fileForNegativeTestWithCondition2Name, resultFileNameForSaveWithCondition2 };
        }

        private void ReadFromFileMethodTestHelper<T>(Action<List<T>, string> action, List<T> objects, string fileName)
        {
            action(objects, fileName);
        }

        [TestMethod]
        [DynamicData(nameof(GetDataReadFromFileMethodTest), DynamicDataSourceType.Method)]

        public void ReadFromFileMethodTest(Action<List<Vehicle>, string> action, List<Vehicle> objects, string fileName)
        {
            ReadFromFileMethodTestHelper(action, objects, fileName);
        }

        public static IEnumerable<object[]> GetDataReadFromFileMethodTest()
        {
            yield return new object[] { listComparePositive, _vehiclesForPositiveTest, resultFileName };
            yield return new object[] { listCompareNegative, _vehiclesForNegativeTest, resultFileName };
        }

        private void SaveToFileSortMethodTestHelper<T>(CarPark testCarPark, Action<string, string> action, Func<Vehicle, T> comparer, string fileName, string resFileName)
        {
            testCarPark.SaveToFileSort(fileName, comparer);
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(fileName);
            action(fileName, resFileName);
        }

        [TestMethod]
        [DynamicData(nameof(GetDataSaveToFileSortMethodTest), DynamicDataSourceType.Method)]

        public void SaveToFileSortMethodTest(CarPark testCarPark, Action<string, string> action, Func<Vehicle, string> comparer, string fileName, string resFileName)
        {
            SaveToFileSortMethodTestHelper(testCarPark, action, comparer, fileName, resFileName);
        }

        public static IEnumerable<object[]> GetDataSaveToFileSortMethodTest()
        {
            yield return new object[] { _carParkForPositiveTest, fileComparePositive, transmissionComparer, fileForPositiveSortTestName, resultFileNameForSort };
            yield return new object[] { _carParkForNegativeTest, fileCompareNegative, transmissionComparer, fileForNegativeSortTestName, resultFileNameForSort };
        }

        private void SaveToFileProectionMethodTestHelper<T>(CarPark testCarPark, Action<string, string> action, Func<Vehicle, bool> function, Func<Vehicle, T> condition, string fileName, string resFileName)
        {
            testCarPark.SaveToFileProection(fileName, function, condition);
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(fileName);
            action(fileName, resFileName);
        }

        [TestMethod]
        [DynamicData(nameof(GetDataSaveToFileProectionMethodTest), DynamicDataSourceType.Method)]

        public void SaveToFileProectionMethodTest(CarPark testCarPark, Action<string, string> action, Func<Vehicle, bool> function, Func<Vehicle, SerialClass> condition, string fileName, string resFileName)
        {
            SaveToFileProectionMethodTestHelper(testCarPark, action, function, condition, fileName, resFileName);
        }

        public static IEnumerable<object[]> GetDataSaveToFileProectionMethodTest()
        {
            yield return new object[] { _carParkForPositiveTest, fileComparePositive, chooseVehicleType, proectionCondition, fileForPositiveProectionTestName, resultFileNameForProection };
            yield return new object[] { _carParkForNegativeTest, fileCompareNegative, chooseVehicleType, proectionCondition, fileForNegativeProectionTestName, resultFileNameForProection };
        }

        [TestMethod]
        [DynamicData(nameof(GetDataForGetInformationTest), DynamicDataSourceType.Method)]
        public void GetInformationTest(IReadable readable, string result)
        {
            Assert.AreEqual(result, readable.GetInformation());
        }

        public static IEnumerable<object[]> GetDataForGetInformationTest()
        {
            yield return new object[] { _carParkForPositiveTest, resultTextForCarPark };
        }
    }
}
