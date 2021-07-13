using System;
using System.Collections.Generic;
using System.Text;
using Task10.Managers;

namespace Task10.Commands
{
    class InputCommand : Command
    {
        public InputManager InManager { get; set; }

        public string Manufacturer { get; set; }
        
        public string Model { get; set; }

        public uint Amount { get; set; }

        public double Price { get; set; }

        public InputCommand(string manufacturer, string model, uint amount, double price, Application app, InputManager inManager) : base(app)
        {
            InManager = inManager;
            Manufacturer = manufacturer;
            Model = model;
            Amount = amount;
            Price = price;
        }

        public override void Execute()
        {
            InManager.Input(Manufacturer, Model, Amount, Price);
            App.Output = "Cars successfully added!";
        }
    }
}
