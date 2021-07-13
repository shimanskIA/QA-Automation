using System;
using System.Collections.Generic;
using System.Text;
using Task10.Managers;

namespace Task10.Commands
{
    class CalculateAverageTypePriceCommand : StatisticsCommand
    {
        public string Type { get; set; }
        public CalculateAverageTypePriceCommand(string type, Application app, StatisticsManager statsManager) : base(app, statsManager)
        {
            Type = type;
        }

        public override void Execute()
        {
            App.Output = StatsManager.CalculateAveragePrice(Type).ToString();
        }
    }
}
