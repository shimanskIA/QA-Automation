using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Task10.Entities;

namespace Task10.Managers
{
    class StatisticsManager
    {
        public int CountTypes()
        {
            return CarDealer.GetInstance().Cars.Select(x => x.Manufacturer).Distinct().Count();
        }

        public int CountAll()
        {
             return CarDealer.GetInstance().Cars.Count;
        }

        public double CalculateAveragePrice()
        {
            double sumPrice = CarDealer.GetInstance().Cars.Select(x => x.Price).Sum();
            double amount = CarDealer.GetInstance().Cars.Count();
            return sumPrice / amount;
        }

        public double CalculateAveragePrice(string type)
        {
            double sumPrice = CarDealer.GetInstance().Cars.Where(x => x.Manufacturer == type).Select(x => x.Price).Sum();
            double amount = CarDealer.GetInstance().Cars.Where(x => x.Manufacturer == type).Count();
            return sumPrice / amount;
        }
    }
}
