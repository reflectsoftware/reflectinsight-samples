using System;
using System.Collections.Generic;
using System.Linq;

using ReflectSoftware.Insight.Extensions.PostSharp;

namespace PostSharp_Common_Sample
{
    public class TracerFieldPostSharp
    {
        [RITraceField("tracer.fields", "Name")]
        public String Name { get; set; }

        [RITraceField("tracer.fields", "Address")]
        public String Address { get; set; }

        [RITraceField("tracer.fields", "Age", RITraceFieldDispatchType.Both)]
        public String Age { get; set; }
    }
}
