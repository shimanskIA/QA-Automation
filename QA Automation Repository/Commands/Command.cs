using System;
using System.Collections.Generic;
using System.Text;

namespace Task10.Commands
{
    abstract class Command
    {
        protected Application App { get; set; }

        public Command(Application app)
        {
            App = app;
        }

        public abstract void Execute();
    }
}
