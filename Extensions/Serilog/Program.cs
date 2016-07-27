using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Serilog;

namespace Serilog.Sinks.ReflectInsight.Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                   .MinimumLevel.Debug()
                   .WriteTo.ReflectInsight()
                   .CreateLogger();

            var logger = Log.ForContext<Program>();
            logger.Information("Hello, Serilog!");
            logger.Information("This is an Information message");
            logger.Debug("This is a Debug message");
            logger.Warning("This is a Warning message");
            logger.Error(new Exception("Test Exception"), "This is an Error message");
            logger.Fatal(new Exception("Test Exception"), "This ia a Fatal message");
            logger.Verbose("This is a Verbose message");
        }
    }
}
