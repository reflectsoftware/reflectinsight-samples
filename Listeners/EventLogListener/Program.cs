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
            RunSample();
        }

        static void RunSample()
        {
            ReflectInsight ri = RILogManager.Get("myDefault");


            while (true)
            {
                Console.WriteLine("Press any key to run test or press 'q' to quit...");

                ConsoleKeyInfo k = Console.ReadKey();
                if (k.KeyChar == 'q')
                    break;

                ri.SendWarning("This is a test for the EventLog listener.");
            }
        }
    }
}
