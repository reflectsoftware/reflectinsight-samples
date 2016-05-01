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
                log.Trace(ex, "Trace Exception");

                log.Info("My Info");
                log.Info(ex, "Info Exception");

                log.Debug("My Debug");
                log.Debug(ex, "Debug Exception");

                log.Warn("My Warn");
                log.Warn(ex, "Warn Exception");

                log.Error("My Error");
                log.Error(ex, "Error Exception");

                log.Fatal("My Fatal");
                log.Fatal(ex, "Fatal Exception");

                log.Info("[Exit] My Info1");
            }
        }

        static void Main(string[] args)
        {
            TestNLog();
        }
    }
}
