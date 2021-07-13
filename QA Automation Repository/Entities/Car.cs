using System;
using System.Collections.Generic;
using System.Text;

namespace Task10.Entities
{
    class Car
    {
        public string Manufacturer { get; set; }
        
        public string Model { get; set; }

        public double Price { get; set; }

        public Car(string manufacturer, string model, double price)
        {
            Manufacturer = manufacturer;
            Model = model;
            Price = price;
        }
    
    }
}
