using System;
using System.Collections.Generic;

using ReflectSoftware.Insight;
using ReflectSoftware.Insight.Extensions.PostSharp;

namespace PostSharp_Common_Sample
{
    static public class TraceServiceInterface
    {
        //---------------------------------------------------------------------     
        [RITrace("tracer.service")]
        static public Int32 Interface1(String name, Int32 age, Byte[] data1, List<String> data2)
        {
            ReflectInsight ri = RITraceManager.ActiveLogger;

            ri.AddCheckpoint();
            ri.SendMessage("This is message one in: {0}", RITraceManager.GetActiveTracer().Name);
            ri.SendNote("This is message two in: {0}", RITraceManager.GetActiveTracer().Name);

            TraceBusiness.Business1(name, data1, age, data2);

            ri.SendDebug("This is message three in: {0}", RITraceManager.GetActiveTracer().Name);
            ri.SendWarning("This is message four in: {0}", RITraceManager.GetActiveTracer().Name);

            return 25;
        }
    }

    /// <summary>
    /// All methods under this class will get the tracer.business enter/exit methods
    /// </summary>
    [RITrace("tracer.business")]
    static public class TraceBusiness
    {
        //---------------------------------------------------------------------
        [RITraceAttribute(AttributeExclude = true)]
        static TraceBusiness()
        {
        }
        //---------------------------------------------------------------------
        static public String Business1(String name, Byte[] data1, Int32 age, List<String> data2)
        {
            ReflectInsight ri = RITraceManager.ActiveLogger;

            ri.AddCheckpoint();
            ri.SendMessage("This is message one in: {0}", RITraceManager.GetActiveTracer().Name);
            ri.SendNote("This is message two in: {0}", RITraceManager.GetActiveTracer().Name);

            TraceDataAccess.DataAccess(name);

            ri.SendDebug("This is message three in: {0}", RITraceManager.GetActiveTracer().Name);
            ri.SendWarning("This is message four in: {0}", RITraceManager.GetActiveTracer().Name);

            return "Some String value";
        }
    }

    /// <summary>
    /// This example will follow the tracer.dataAccess for the DataAccess method level only
    /// </summary>
    static public class TraceDataAccess
    {
        [RITrace("tracer.dataAccess")]
        //---------------------------------------------------------------------        
        static public void DataAccess(String name)
        {
            ReflectInsight ri = RITraceManager.ActiveLogger;

            ri.AddCheckpoint();
            ri.SendMessage("This is message one in: {0}", RITraceManager.GetActiveTracer().Name);
            ri.SendNote("This is message two in: {0}", RITraceManager.GetActiveTracer().Name);

            if (name == "error")
                throw new Exception("A test exception was thrown!");

            ri.SendDebug("This is message three in: {0}", RITraceManager.GetActiveTracer().Name);
            ri.SendWarning("This is message four in: {0}", RITraceManager.GetActiveTracer().Name);
        }
    }
}
