using System;
using System.Collections.Generic;

namespace CommonLogging_Sample
{
    class Program
    {
        static void TestCommonLogging()
        {
            Common.Logging.ILog log = Common.Logging.LogManager.GetCurrentClassLogger();

            while (true)
            {
                Console.WriteLine("Press any key or 'q' to quit...");
                ConsoleKeyInfo k = Console.ReadKey();
                if (k.KeyChar == 'q')
                {
                    break;
                }

                Exception ex = new Exception("This is my test exception!");

                log.Info("[Enter]EnterMessage");
                log.Info("My Info");
                log.Info("My Info", ex);

                log.Debug("My Debug");
                log.Debug("My Debug", ex);
               
                log.Trace("My Trace");
                log.Trace("My Trace", ex);

                log.Warn("My Warn");
                log.Warn("My Warn", ex);

                log.Error("My Error");
                log.Error("My Error", ex);

                log.Fatal("My Fatal");
                log.Fatal("My Fatal", ex);
                log.Info("[Exit]ExitMessage");
            }
        }
                
        static void Main(string[] args)
        {
            TestCommonLogging();
        }
    }
}
