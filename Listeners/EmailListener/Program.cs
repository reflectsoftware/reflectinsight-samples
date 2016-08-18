using System;
using System.Collections.Generic;
using System.Linq;

using ReflectSoftware.Insight;

namespace EmailListener_Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            RunSample();
        }

        static void RunSample()
        {
            while (true)
            {
                Console.WriteLine("Press any key to run test or press 'q' to quit...");

                ConsoleKeyInfo k = Console.ReadKey();
                if (k.KeyChar == 'q')
                    break;

                RILogManager.Default.SendException(new Exception("This is a sample exception from the Email listener."));
            }
        }
    }
}
