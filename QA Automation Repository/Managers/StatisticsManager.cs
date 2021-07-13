using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Task10.Entities;

namespace Task10.Managers
{
    class StatisticsManager
    {
        public string CountTypes()
        {
            return CarDealer.GetInstance().Cars.Select(x => x.Manufacturer).Distinct().Count().ToString();
        }

        public string CountAll()
        {
            return CarDealer.GetInstance().Cars.Count.ToString();
        }

        public string CalculateAveragePrice()
        {
            double amount = CarDealer.GetInstance().Cars.Count();
            if (amount > 0)
            {
                double sumPrice = CarDealer.GetInstance().Cars.Select(x => x.Price).Sum();
                return (sumPrice / amount).ToString();
            }
            else
            {
                return "There're any cars added!";
            }
        }

        public string CalculateAveragePrice(string type)
        {
            double amount = CarDealer.GetInstance().Cars.Where(x => x.Manufacturer == type).Count();
            if (amount > 0)
            {
                double sumPrice = CarDealer.GetInstance().Cars.Where(x => x.Manufacturer == type).Select(x => x.Price).Sum();
                return (sumPrice / amount).ToString();
            }
            else
            {
                return "There're any cars of this manufacturer added!";
            }
        }
    }
}
