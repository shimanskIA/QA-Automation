using Task10.Managers;

namespace Task10.Commands
{
    class CalculateAveragePriceCommand : StatisticsCommand
    {
        public CalculateAveragePriceCommand(Application app, StatisticsManager statsManager) : base(app, statsManager)
        {

        }

        public override void Execute()
        {
            App.Output = StatsManager.CalculateAveragePrice();
        }
    }
}
