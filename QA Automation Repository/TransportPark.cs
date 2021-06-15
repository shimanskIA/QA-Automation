using System;
using System.Collections.Generic;
using System.Text;

namespace HW3
{
    class TransportPark 
    {
        private IReadable[] _transport; // array with vehicles
        public IReadable[] Transport { get; }

        public TransportPark()
        {
            _transport = new IReadable[10]; 
        }

        public void GetFullInfo() // method showing infos about all the vehicles in the car park
        {
            foreach (IReadable vehicle in _transport)
            {
                if (vehicle != null)
                {
                    Console.WriteLine(vehicle.GetFullInfo());
                }
            }
        }

        public void AddElementToTheTransportPark(IReadable vehicle, int index) // method adding a copy of element to a car park
        {
            if (vehicle is ICloneable)
            {
                _transport[index] = (IReadable)((ICloneable)vehicle).Clone();
            }
        }
    }
}
