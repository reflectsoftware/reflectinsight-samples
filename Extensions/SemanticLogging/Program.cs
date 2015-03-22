using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics.Tracing;

using Microsoft.Practices.EnterpriseLibrary.SemanticLogging;
using ReflectSoftware.Insight.Extensions.SemanticLogging;

namespace SemanticLogging_Sample
{
    class Program
    {
        static void DoSomeLogging()
        {
            // log your events
            MyFirstEventSource.Log.SomeSimple("Hello, world", "Hey");
            MyFirstEventSource.Log.SomeEvent1("Hello, world", 10);
            MyFirstEventSource.Log.SomeError("This is a test from {0}", 20);
            MyFirstEventSource.Log.SomeError2("This is a test from {0}", 30);
            MyFirstEventSource.Log.SomeCritical("This is a test from {0}", 40);
            MyFirstEventSource.Log.SomeWarning("This is a test from {0}", 50);
            MyFirstEventSource.Log.SomeVerbose("This is a test from {0}", 60);
        }

        static void InProcessMethod1()
        {
            const String messagePattern = null; // "%message% - %eventid%, %opcode%, %eventname%, %providerid%";

            // application start: create and initalize listeners
            ObservableEventListener logListener = new ObservableEventListener();

            logListener.EnableEvents(MyFirstEventSource.Log, EventLevel.Verbose, MyFirstEventSource.Keywords.Other | MyFirstEventSource.Keywords.Keyword1);
            logListener.LogToReflectInsight(messagePattern: messagePattern);
            logListener.LogToConsole();

            DoSomeLogging();

            // application end: create and initalize listeners
            logListener.DisableEvents(MyFirstEventSource.Log);
            logListener.Dispose();
        }

        static void InProcessMethod2()
        {
            // application start: create and initalize listeners
            EventListener logListener1 = RIEventLog.CreateListener();
            EventListener logListener2 = ConsoleLog.CreateListener();

            logListener1.EnableEvents(MyFirstEventSource.Log, EventLevel.Verbose, MyFirstEventSource.Keywords.Other | MyFirstEventSource.Keywords.Keyword1);
            logListener2.EnableEvents(MyFirstEventSource.Log, EventLevel.Verbose, MyFirstEventSource.Keywords.Other | MyFirstEventSource.Keywords.Keyword1);

            DoSomeLogging();

            // application end: create and initalize listeners
            logListener1.DisableEvents(MyFirstEventSource.Log);
            logListener2.DisableEvents(MyFirstEventSource.Log);

            logListener1.Dispose();
            logListener2.Dispose();
        }

        static void OutProcessMethod()
        {
            /* For the OutProcess Method you must install and setup the 
             * SemanticLogging Service to listen for your EventSources.
             * Please refer to the Enterprise Library documentation on how to 
             * setup and configure. 
             * A sample *.svc.xml has been attached to this sample on how 
             * to configure The ReflectSoftware.Insight.Extensions.SemanticLogging
             */
            DoSomeLogging();
        }

        static void Main(string[] args)
        {
            InProcessMethod1();
            //InProcessMethod2();
            //OutProcessMethod();
        }
    }
}
