using System;

namespace Task10
{
    class EntryPoint
    {
        static void Main()
        {
            Application application = Application.GetInstance();
            while(true)
            {
                bool isWorking = application.Activate(Console.ReadLine());
                if (!isWorking)
                {
                    break;
                }
            }
        }
    }
}
