using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Task4.Entities.Details;
using Task4.Entities.Vehicles;
using Task4.Helpers;
using Task4.Interfaces;

namespace MSTestsForTask4
{
    [TestClass]
    public class ClassMethodsTests
    {
        // test objects that are going to be input for test methods. these objects are divided into objects to compare, the same objects for positive test and diffrent objects for negative tests
        private static readonly Engine _engine = new Engine(250, 2.5, EngineTypes.Petrol, 123456);
        private static readonly Engine _engineToPositiveCompare = new Engine(250, 5.1 - 2.6, EngineTypes.Petrol, 123456);
        private static readonly Engine _engineToNegativeCompare = new Engine(500, 3.2, EngineTypes.Hybrid, 111111);
        private static readonly Chassis _chassis = new Chassis(4, 500.5, 123456);
        private static readonly Chassis _chassisToPositiveCompare = new Chassis(4, 501.9 - 1.4, 123456);
        private static readonly Chassis _chassisToNegativeCompare = new Chassis(6, 1500, 1111111);
        private static readonly Transmission _transmission = new Transmission("2x2", 6, Manufacturers.BMW);
        private static readonly Transmission _transmissionToPositiveCompare = new Transmission("2x2", 6, Manufacturers.BMW);
        private static readonly Transmission _transmissionToNegativeCompare = new Transmission("2x4", 8, Manufacturers.Mitsubishi);
        private static readonly Car _car = new Car(Manufacturers.BMW, _engine, _chassis, _transmission, 5);
        private static readonly Car _carToPositiveCompare = new Car(Manufacturers.BMW, _engineToPositiveCompare, _chassisToPositiveCompare, _transmissionToPositiveCompare, 5);
        private static readonly Car _carToNegativeCompare = new Car(Manufacturers.Mercedes, _engineToNegativeCompare, _chassisToNegativeCompare, _transmissionToNegativeCompare, 6);
        private static readonly Bus _bus = new Bus(Manufacturers.Mercedes, _engine, _chassis, _transmission, 45, 2);
        private static readonly Bus _busToPositiveCompare = new Bus(Manufacturers.Mercedes, _engineToPositiveCompare, _chassisToPositiveCompare, _transmissionToPositiveCompare, 45, 2);
        private static readonly Bus _busToNegativeCompare = new Bus(Manufacturers.BMW, _engineToNegativeCompare, _chassisToNegativeCompare, _transmissionToNegativeCompare, 50, 3);
        private static readonly Lorry _lorry = new Lorry(Manufacturers.Mercedes, _engine, _chassis, _transmission, 250.5);
        private static readonly Lorry _lorryToPositiveCompare = new Lorry(Manufacturers.Mercedes, _engineToPositiveCompare, _chassisToPositiveCompare, _transmissionToPositiveCompare, 251.6 - 1.1);
        private static readonly Lorry _lorryToNegativeCompare = new Lorry(Manufacturers.BMW, _engineToNegativeCompare, _chassisToNegativeCompare, _transmissionToNegativeCompare, 650.25);
        private static readonly Scooter _scooter = new Scooter(Manufacturers.BMW, _engine, _chassis, _transmission, 7.25);
        private static readonly Scooter _scooterToPositiveCompare = new Scooter(Manufacturers.BMW, _engineToPositiveCompare, _chassisToPositiveCompare, _transmissionToPositiveCompare, 7.31 - 0.06);
        private static readonly Scooter _scooterToNegativeCompare = new Scooter(Manufacturers.BMW, _engineToNegativeCompare, _chassisToNegativeCompare, _transmissionToNegativeCompare, 5.5);
        
        // strings that are correct results of GetInformation() methods for diffrent vehicles and details
        private static readonly string resultTextForEngine = "Petrol engine of 2,5 liters with 250 horse powers and serial number: 123456";
        private static readonly string resultTextForChassis = "chassis with 4 wheels, maximal load of 500,5 kilograms and serial number: 123456";
        private static readonly string resultTextForTransmission = "2x2 transmission with 6 gears, pruduced by BMW";
        private static readonly string resultTextForCar = "A car, produced by BMW with Petrol engine of 2,5 liters with 250 horse powers and serial number: 123456, chassis with 4 wheels, maximal load of 500,5 kilograms and serial number: 123456, 2x2 transmission with 6 gears, pruduced by BMW, that can also carry 5 passengers";
        private static readonly string resultTextForBus = "A bus, produced by Mercedes with Petrol engine of 2,5 liters with 250 horse powers and serial number: 123456, chassis with 4 wheels, maximal load of 500,5 kilograms and serial number: 123456, 2x2 transmission with 6 gears, pruduced by BMW, that can also carry 45 passengers and has 2 ecological level";
        private static readonly string resultTextForLorry = "A lorry, produced by Mercedes with Petrol engine of 2,5 liters with 250 horse powers and serial number: 123456, chassis with 4 wheels, maximal load of 500,5 kilograms and serial number: 123456, 2x2 transmission with 6 gears, pruduced by BMW, that can also carry 250,5 kilogramms";
        private static readonly string resultTextForScooter = "A scooter, produced by BMW with Petrol engine of 2,5 liters with 250 horse powers and serial number: 123456, chassis with 4 wheels, maximal load of 500,5 kilograms and serial number: 123456, 2x2 transmission with 6 gears, pruduced by BMW, that can reach 100 km/h in just 7,25 seconds, wow!";

        [TestMethod]
        [DynamicData(nameof(GetDataForEqualsMethodPositiveTest), DynamicDataSourceType.Method)]
   
        public void EqualsMethodPositiveTest(object obj1, object obj2)
        {
            Assert.IsTrue(obj1.Equals(obj2));
        }

        public static IEnumerable<object[]> GetDataForEqualsMethodPositiveTest()
        {
            yield return new object[] { _engine, _engineToPositiveCompare };
            yield return new object[] { _chassis, _chassisToPositiveCompare };
            yield return new object[] { _transmission, _transmissionToPositiveCompare };
            yield return new object[] { _car, _carToPositiveCompare };
            yield return new object[] { _bus, _busToPositiveCompare };
            yield return new object[] { _lorry, _lorryToPositiveCompare };
            yield return new object[] { _scooter, _scooterToPositiveCompare };
        }

        [TestMethod]
        [DynamicData(nameof(GetDataForEqualsMethodNegativeTest), DynamicDataSourceType.Method)]
        
        public void EqualsMethodNegativeTest(object obj1, object obj2)
        {
            Assert.IsFalse(obj1.Equals(obj2));
        }

        public static IEnumerable<object[]> GetDataForEqualsMethodNegativeTest()
        {
            yield return new object[] { _engine, _engineToNegativeCompare };
            yield return new object[] { _chassis, _chassisToNegativeCompare };
            yield return new object[] { _transmission, _transmissionToNegativeCompare };
            yield return new object[] { _car, _carToNegativeCompare };
            yield return new object[] { _bus, _busToNegativeCompare };
            yield return new object[] { _lorry, _lorryToNegativeCompare };
            yield return new object[] { _scooter, _scooterToNegativeCompare };
        }

        [TestMethod]
        [DynamicData(nameof(GetDataForGetHashCodeMethodPositiveTest), DynamicDataSourceType.Method)]

        public void GetHashCodeMethodPositiveTest(object obj1, object obj2)
        {
            Assert.AreEqual(obj1.GetHashCode(), obj2.GetHashCode());
        }

        public static IEnumerable<object[]> GetDataForGetHashCodeMethodPositiveTest()
        {
            yield return new object[] { _engine, _engineToPositiveCompare };
            yield return new object[] { _chassis, _chassisToPositiveCompare };
            yield return new object[] { _transmission, _transmissionToPositiveCompare };
            yield return new object[] { _car, _carToPositiveCompare };
            yield return new object[] { _bus, _busToPositiveCompare };
            yield return new object[] { _lorry, _lorryToPositiveCompare };
            yield return new object[] { _scooter, _scooterToPositiveCompare };
        }

        [TestMethod]
        [DynamicData(nameof(GetDataForGetHashCodeMethodNegativeTest), DynamicDataSourceType.Method)]

        public void GetHashCodeMethodNegativeTest(object obj1, object obj2)
        {
            Assert.AreNotEqual(obj1.GetHashCode(), obj2.GetHashCode());
        }

        public static IEnumerable<object[]> GetDataForGetHashCodeMethodNegativeTest()
        {
            yield return new object[] { _engine, _engineToNegativeCompare };
            yield return new object[] { _chassis, _chassisToNegativeCompare };
            yield return new object[] { _transmission, _transmissionToNegativeCompare };
            yield return new object[] { _car, _carToNegativeCompare };
            yield return new object[] { _bus, _busToNegativeCompare };
            yield return new object[] { _lorry, _lorryToNegativeCompare };
            yield return new object[] { _scooter, _scooterToNegativeCompare };
        }

        [TestMethod]
        [DynamicData(nameof(GetDataForGetInformationTest), DynamicDataSourceType.Method)]
        public void GetInformationTest(IReadable readable, string result)
        {
            Assert.AreEqual(result, readable.GetInformation());
        }

        public static IEnumerable<object[]> GetDataForGetInformationTest()
        {
            yield return new object[] { _engine, resultTextForEngine};
            yield return new object[] { _chassis, resultTextForChassis};
            yield return new object[] { _transmission, resultTextForTransmission};
            yield return new object[] { _car, resultTextForCar};
            yield return new object[] { _bus, resultTextForBus};
            yield return new object[] { _lorry, resultTextForLorry};
            yield return new object[] { _scooter, resultTextForScooter};
        }
    }
}