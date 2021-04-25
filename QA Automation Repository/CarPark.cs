using System;
using System.Collections.Generic;
using System.Text;

namespace HW3
{
    class CarPark
    {
        private Vehicle[] _vehicles; // array with vehicles
        public Vehicle[] Vehicles { get { return _vehicles; } }

        public CarPark()
        {
            _vehicles = new Vehicle[10]; 
        }

        public void GetFullInfo() // method showing infos about all the vehicles in the car park
        {
            foreach (Vehicle vehicle in _vehicles)
            {
                if (vehicle != null)
                {
                    Console.WriteLine(vehicle.GetFullInfo());
                }
            }
        }

        public void AddElementToTheCarPark(Vehicle vehicle, int index) // method adding a copy of element to a car park
        {
            _vehicles[index] = vehicle.Clone();
        }
    }
}
