using System;
using System.Collections.Generic;
using System.Text;
using Task10.Commands;
using Task10.Managers;

namespace Task10
{
    class Application
    {
        private static Application _instance;
        
        private StatisticsManager StatsManager { get; set; }

        private InputManager InManager { get; set; }

        public string Output { get; set; }

        private Application(StatisticsManager statsManager, InputManager inManager)
        {
            StatsManager = statsManager;
            InManager = inManager;
            Output = default;
        }

        public static Application GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Application(new StatisticsManager(), new InputManager());
            }
            return _instance;
        }

        public bool Activate(string incomingCommandText)
        {
            if (incomingCommandText == "count types")
            {
                ExecuteCommand(new CountTypesCommand(this, StatsManager));
                Console.WriteLine(Output);
                return true;
            }
            else if (incomingCommandText == "count all")
            {
                ExecuteCommand(new CountAllCommand(this, StatsManager));
                Console.WriteLine(Output);
                return true;
            }
            else if (incomingCommandText == "average price")
            {
                ExecuteCommand(new CalculateAveragePriceCommand(this, StatsManager));
                Console.WriteLine(Output);
                return true;
            }
            else if (incomingCommandText.Contains("average price "))
            {
                string type = incomingCommandText.Split(' ', 3)[2];
                if (type.Length > 0)
                {
                    ExecuteCommand(new CalculateAverageTypePriceCommand(type, this, StatsManager));
                }
                Console.WriteLine(Output);
                return true;
            }
            else if (incomingCommandText.Contains("add auto "))
            {
                try
                {
                    string[] parameters = incomingCommandText.Split(' ', 6);
                    ExecuteCommand(new InputCommand(parameters[2].ToLower(), parameters[3].ToLower(), UInt32.Parse(parameters[4]), Double.Parse(parameters[5]), this, InManager));
                    Console.WriteLine(Output);
                }
                catch
                {
                    Console.WriteLine("The command with these parameters does not exist");
                }
                return true;
            }
            else if (incomingCommandText == "exit")
            {
                return false;
            }
            else
            {
                Console.WriteLine("There's no such a command");
                return true;
            }
        }

        private void ExecuteCommand(Command command)
        {
            command.Execute();
        }
    }
}
