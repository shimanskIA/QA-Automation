using System;
using System.Collections.Generic;
using System.Text;

namespace HW6
{
    public class CarDealer
    {
        public List<Car> Cars { get; }

        public CarDealer (List<Car> cars)
        {
            Cars = new List<Car>(cars);
        }

        // methode to get average parameters of cars
        public double GetAverage(Func<Car, double> calculate)
        {
            double sum = 0;
            foreach (var car in Cars)
            {
                sum += calculate(car);
            }
            return sum;
        }

        // methode to get count of cars that have some parameters
        public int GetCount(Predicate<Car> compare)
        {
            int temp_count = 0;
            {
                foreach (var car in Cars)
                {
                    if (compare(car))
                    {
                        temp_count++;
                    }
                }
                return temp_count;
            }
        }
    }
}
