using System;
using System.Collections.Generic;
using System.Text;

namespace Task10.Entities
{
    class CarDealer
    {
        public List<Car> Cars { get; set; }

        private static CarDealer _instance;

        private CarDealer()
        {
            Cars = new List<Car>();
        }

        public static CarDealer GetInstance()
        {
            if (_instance == null)
            {
                _instance = new CarDealer();
            }
            return _instance;
        }

        public void AddCar(Car car)
        {
            Cars.Add(car);
        }
    }
}
