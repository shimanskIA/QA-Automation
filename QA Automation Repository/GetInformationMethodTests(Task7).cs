using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Task4.Entities.Details;
using Task4.Entities.Vehicles;
using Task4.Enums;
using Task4.Interfaces;

namespace MSTestsForTask4
{
    [TestClass]
    public class GetInformationMethodTests
    {
        private static readonly Engine _engine = new Engine(250, 2.5, EngineTypes.Petrol, 123456);
        private static readonly Chassis _chassis = new Chassis(4, 500.5, 123456);
        private static readonly Transmission _transmission = new Transmission("2x2", 6, ManufacturersForTransmissionsAndVehicles.BMW);
        private static readonly Car _car = new Car(ManufacturersForTransmissionsAndVehicles.BMW, _engine, _chassis, _transmission, 5);
        private static readonly Bus _bus = new Bus(ManufacturersForTransmissionsAndVehicles.Mercedes, _engine, _chassis, _transmission, 45, 2);
        private static readonly Lorry _lorry = new Lorry(ManufacturersForTransmissionsAndVehicles.Mercedes, _engine, _chassis, _transmission, 250.5);
        private static readonly Scooter _scooter = new Scooter(ManufacturersForTransmissionsAndVehicles.BMW, _engine, _chassis, _transmission, 7.25);

        private static readonly string resultTextForEngine = "Petrol engine of 2,5 liters with 250 horse powers and serial number: 123456";
        private static readonly string resultTextForChassis = "chassis with 4 wheels, maximal load of 500,5 kilograms and serial number: 123456";
        private static readonly string resultTextForTransmission = "2x2 transmission with 6 gears, pruduced by BMW";
        private static readonly string resultTextForCar = "A car, produced by BMW with Petrol engine of 2,5 liters with 250 horse powers and serial number: 123456, chassis with 4 wheels, maximal load of 500,5 kilograms and serial number: 123456, 2x2 transmission with 6 gears, pruduced by BMW, that can also carry 5 passengers";
        private static readonly string resultTextForBus = "A bus, produced by Mercedes with Petrol engine of 2,5 liters with 250 horse powers and serial number: 123456, chassis with 4 wheels, maximal load of 500,5 kilograms and serial number: 123456, 2x2 transmission with 6 gears, pruduced by BMW, that can also carry 45 passengers and has 2 ecological level";
        private static readonly string resultTextForLorry = "A lorry, produced by Mercedes with Petrol engine of 2,5 liters with 250 horse powers and serial number: 123456, chassis with 4 wheels, maximal load of 500,5 kilograms and serial number: 123456, 2x2 transmission with 6 gears, pruduced by BMW, that can also carry 250,5 kilogramms";
        private static readonly string resultTextForScooter = "A scooter, produced by BMW with Petrol engine of 2,5 liters with 250 horse powers and serial number: 123456, chassis with 4 wheels, maximal load of 500,5 kilograms and serial number: 123456, 2x2 transmission with 6 gears, pruduced by BMW, that can reach 100 km/h in just 7,25 seconds, wow!";

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
