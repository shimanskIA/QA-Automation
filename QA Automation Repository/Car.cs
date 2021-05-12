using System;
using System.Collections.Generic;
using System.Text;

namespace HW6
{
    public class Car
    {
        public Manufacturers Manufacturer { get; set; }
        public string Model { get; set; }
        public string BodyType { get; set; } // like 2x2, 2x4 ...
        public EngineTypes EngineType { get; set; } // like diesel, petrol ...
        public double EngineVolume { get; set; } // in liters
        public double Price { get; set; } // in us dollars

        public Car (Manufacturers manufacturer, string model, string bodyType, EngineTypes engineType, double engineVolume, double price)
        {
            Manufacturer = manufacturer;
            Model = model;
            BodyType = bodyType;
            EngineType = engineType;
            EngineVolume = engineVolume;
            Price = price;
        }
    }
}
