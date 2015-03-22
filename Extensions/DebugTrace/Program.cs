using System;
using System.Collections.Generic;
using System.Diagnostics;

using ReflectSoftware.Insight;

namespace DebugTrace_Sample
{
    class Program
    {
        static void TestTrace()
        {
            while (true)
            {
                Console.WriteLine("Press any key or 'q' to quit TestTrace()...");
                ConsoleKeyInfo k = Console.ReadKey();
                if (k.KeyChar == 'q')
                    break;

                Trace.Write("Hey1");
                Trace.Indent();
                Trace.Write("Hey2");
                Trace.Indent();
                Trace.TraceWarning("Warn");
                Trace.Fail("Failed");

                Trace.Indent();
                Trace.WriteLine("hello1");
                Trace.Indent();
                Trace.TraceInformation("Info");
                Trace.TraceInformation("Info");
                Trace.Indent();
                Trace.TraceWarning("Warn");
                Trace.Unindent();
                Trace.Unindent();
                Trace.TraceError("Error");
                Trace.Unindent();

                Trace.Unindent();
                Trace.Unindent();
                Trace.WriteLine("nextline");
            }
        }

        static void SourceTraceTest()
        {
            while (true)
            {
                Console.WriteLine("Press any key or 'q' to quit SourceTraceTest()...");
                ConsoleKeyInfo k = Console.ReadKey();
                if (k.KeyChar == 'q')
                    break;

                TraceSource ts = new TraceSource("SourceTrace");
                ts.TraceInformation("Some Information: {0}", "The sky is blue");
                ts.TraceTransfer(10, "Some Transfer", Guid.NewGuid());
                ts.TraceEvent(TraceEventType.Start, 2, "Start");
                ts.TraceEvent(TraceEventType.Stop, 2, "Stop");
                ts.TraceEvent(TraceEventType.Suspend, 3, "Suspend");
                ts.TraceEvent(TraceEventType.Resume, 1, "Resume");
                ts.TraceEvent(TraceEventType.Transfer, 3, "Transfer");
                ts.TraceEvent(TraceEventType.Verbose, 4, "Verbose");
                ts.Close();
            }
        }

        static void TestDebug()
        {
            while (true)
            {
                Console.WriteLine("Press any key or 'q' to quit TestDebug()...");
                ConsoleKeyInfo k = Console.ReadKey();
                if (k.KeyChar == 'q')
                    break;

                Debug.Write("Hey1");
                Debug.Indent();
                Debug.Write("Hey2");
                Debug.Indent();
                Debug.Fail("Failed");

                Debug.Indent();
                Debug.WriteLine("hello1");
                Debug.Indent();
                Debug.Indent();
                Debug.Unindent();
                Debug.Unindent();
                Debug.Unindent();

                Debug.Unindent();
                Debug.Unindent();
                Debug.WriteLine("nextline");
            }
        }

        static void Main(string[] args)
        {
            // if you perfer to not use the config file settings then uncommen this line.
            RITraceListener.Enabled = true;
            try
            {
                // TestDebug();

                // If using Trace Source, then use this test, otherwise comment out and use the other tests. You will need to update the app.config accordingly for the other tests.
                SourceTraceTest();
                //return;

                // Other tests
                // TestTrace();                
            }
            finally
            {
                // if you perfer to not use the config file settings then uncommen this line.
                RITraceListener.Enabled = false; // release any related resources
            }
        }
    }
}
