using System;

namespace HW3
{
    class Program
    {
        static void Main(string[] args)
        {
            TransportPark transportPark = new TransportPark();
            transportPark.AddElementToTheTransportPark(new Car("Mercedes", 3.5, "2x2", 200, 5), 0);
            transportPark.AddElementToTheTransportPark(new Car("BMW", 2, "2x2", 170, 4), 1);
            transportPark.AddElementToTheTransportPark(new Car("Lada", 1.2, "2x2", 150, 7), 2);
            transportPark.AddElementToTheTransportPark(new Bus("Mercedes", 6, "2x4", 150, 75, 1), 3);
            transportPark.AddElementToTheTransportPark(new Bus("Maz", 8, "2x6", 140, 55, 3), 4);
            transportPark.AddElementToTheTransportPark(new Motorbike("Yamaha", 0.7, "1x1", 220, 5.45), 5);
            transportPark.AddElementToTheTransportPark(new Motorbike("Suzuki", 1.2, "1x1", 280, 3.4), 6);
            transportPark.AddElementToTheTransportPark(new Lorry("MAN", 5.5, "2x6", 160, 10000000000), 7);
            transportPark.AddElementToTheTransportPark(new Donkey("Ivan", 250), 8);
            transportPark.AddElementToTheTransportPark(new Donkey("Pavel", 100), 9);
            transportPark.GetFullInfo();
        }
    }
}
