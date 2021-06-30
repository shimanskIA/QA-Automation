//using System;
using Task4.Enums;
//using Task4.Helpers;
using Task4.Interfaces;

namespace Task4.Entities.Details
{
   // [Serializable]
    public class Transmission : IReadable
    {
        public string TransmissionType { get; set; } // like 2x2 or 2x4 or so
        
        public int AmountOfGears { get; set; }
        
        public ManufacturersForTransmissionsAndVehicles Manufacturer { get; set; }

        public Transmission(string transmissionType, int amountOfGears, ManufacturersForTransmissionsAndVehicles manufacturer)
        {
            TransmissionType = transmissionType;
            AmountOfGears = amountOfGears;
            Manufacturer = manufacturer;
        }

        public Transmission()
        {
            TransmissionType = default;
            AmountOfGears = default;
            Manufacturer = default;
        }

        public string GetInformation()
        {
            return TransmissionType + " transmission with " + AmountOfGears + " gears, pruduced by " + Manufacturer;
        }
    }
}
