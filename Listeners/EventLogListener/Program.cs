using System;
using System.Collections.Generic;
using System.Linq;

using ReflectSoftware.Insight;

namespace EventLogListener_Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Press any key to run test or press 'q' to quit...");

                ConsoleKeyInfo k = Console.ReadKey();
                if (k.KeyChar == 'q')
                    break;

                RILogManager.Default.SendMessage("This is a logged message using the EventLog listener.");
            }
        }
    }
}
