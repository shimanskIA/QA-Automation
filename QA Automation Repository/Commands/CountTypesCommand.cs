using Task10.Managers;

namespace Task10.Commands
{
    class CountTypesCommand : StatisticsCommand
    {
        public CountTypesCommand(Application app, StatisticsManager statsManager) : base(app, statsManager)
        {

        }
        
        public override void Execute()
        {
            App.Output = StatsManager.CountTypes();
        }
    }
}
