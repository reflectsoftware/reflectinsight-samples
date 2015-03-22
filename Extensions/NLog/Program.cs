using System;
using System.Collections.Generic;

using NLog;

namespace NLog_Sample
{
    class Program
    {
        static void TestNLog()
        {
            Logger log = LogManager.GetLogger("ReflectInsight");

            while (true)
            {
                Console.WriteLine("Press any key or 'q' to quit...");
                ConsoleKeyInfo k = Console.ReadKey();
                if (k.KeyChar == 'q')
                    break;

                Exception ex = new Exception("This is my test exception!");

                log.Info("[Enter] My Info1");

                log.Trace("My Trace");
                log.Trace("Trace Exception", ex);

                log.Info("My Info");
                log.Info("Info Exception", ex);

                log.Debug("My Debug");
                log.Debug("Debug Exception", ex);

                log.Warn("My Warn");
                log.Warn("Warn Exception", ex);

                log.Error("My Error");
                log.Error("Error Exception", ex);

                log.Fatal("My Fatal");
                log.Fatal("Fatal Exception", ex);

                log.Info("[Exit] My Info1");
            }
        }

        static void Main(string[] args)
        {
            TestNLog();
        }
    }
}
