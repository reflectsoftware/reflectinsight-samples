using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ReflectSoftware.Insight;

namespace ConsoleListener_Sample
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
                
                RILogManager.Default.SendMessage("Message");
                RILogManager.Default.SendDebug("Debug");
                RILogManager.Default.SendInformation("Info");
                RILogManager.Default.SendWarning("Warn");
                RILogManager.Default.SendError("Error");
                RILogManager.Default.SendFatal("Fatal");
                RILogManager.Default.SendException("Exception", new Exception("Test"));
                RILogManager.Default.SendMessage("Message");
            }
        }
    }
}
