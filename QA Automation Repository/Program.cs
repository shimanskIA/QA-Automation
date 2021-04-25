using System;

namespace HW3
{
    class Program
    {
        static void Main(string[] args)
        {
            CarPark carPark = new CarPark();
            carPark.AddElementToTheCarPark(new Car("Mercedes", 3.5, "2x2", 200, 5), 0);
            carPark.AddElementToTheCarPark(new Car("BMW", 2, "2x2", 170, 4), 1);
            carPark.AddElementToTheCarPark(new Car("Lada", 1.2, "2x2", 150, 7), 2);
            carPark.AddElementToTheCarPark(new Bus("Mercedes", 6, "2x4", 150, 75, 1), 3);
            carPark.AddElementToTheCarPark(new Bus("Maz", 8, "2x6", 140, 55, 3), 4);
            carPark.AddElementToTheCarPark(new Motorbike("Yamaha", 0.7, "1x1", 220, 5.45), 5);
            carPark.AddElementToTheCarPark(new Motorbike("Suzuki", 1.2, "1x1", 280, 3.4), 6);
            carPark.AddElementToTheCarPark(new Lorry("MAN", 5.5, "2x6", 160, 10000000000), 7);
            carPark.GetFullInfo();
        }
    }
}
