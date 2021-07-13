using System;
using System.Collections.Generic;
using System.Text;
using Task10.Managers;

namespace Task10.Commands
{
    abstract class StatisticsCommand : Command
    {
        public StatisticsManager StatsManager { get; set; }

        public StatisticsCommand(Application app, StatisticsManager statsManager) : base(app)
        {
            StatsManager = statsManager;
        }
    }
}
