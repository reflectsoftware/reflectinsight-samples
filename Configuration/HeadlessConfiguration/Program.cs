using System;
using System.Collections.Generic;
using System.Linq;

using ReflectSoftware.Insight;

namespace HeadlessConfiguration_Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            RunSample();
        }

        static void RunSample()
        {
            Int32 index = 0;

            while (true)
            {
                Console.WriteLine("Press any key to run test or press 'q' to quit...");

                ConsoleKeyInfo k = Console.ReadKey();
                if (k.KeyChar == 'q')
                {
                    break;
                }

                index++;

                // Load the configuration file in the root of the application
                ReflectInsightConfig.Control.SetExternalConfigurationMode(@"$(workingdir)\ReflectInsight.config");

                // Log some messages
                RILogManager.Default.SendMessage("Testing developer configuration mode...");
                RILogManager.Default.SendMessage("Configuration full path: {0}", ReflectInsightConfig.Control.LastConfigFullPath);
                RILogManager.Default.SendError("A Some Error: {0}", index);

                // Load in the configuration file located in the sub-folder "Other Config". Before loading in the configuration, you want to clear the developer configuration mode
                ReflectInsightConfig.Control.ClearExternalConfigurationMode();
                ReflectInsightConfig.Control.SetExternalConfigurationMode(@"$(workingdir)\Other Config\ReflectInsight2.config");

                // Log some messages
                RILogManager.Default.SendMessage("Testing developer configuration mode...");
                RILogManager.Default.SendMessage("Configuration full path: {0}", ReflectInsightConfig.Control.LastConfigFullPath);
                RILogManager.Default.SendError("B Some Error: {0}", index);
            }
        }
    }
}
