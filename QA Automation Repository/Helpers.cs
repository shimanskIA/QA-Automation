using System;
using System.Collections.Generic;
using System.Text;

namespace HW6
{
    public static class Helpers
    {
        // methode to get the maximal value of a parameter
        public static double GetMax(this CarDealer carDealer, Func<Car, double> show_element)
        {
            double my_max = Double.MinValue;
            foreach (var car in carDealer.Cars)
            {
                if (show_element(car) > my_max)
                {
                    my_max = show_element(car);
                }
            }
            return my_max;
        }
    }
}
