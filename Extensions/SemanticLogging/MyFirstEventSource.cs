using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics.Tracing;

namespace SemanticLogging_Sample
{
    internal class MyFirstEventSource: EventSource
    {
        private static readonly Lazy<MyFirstEventSource> Instance = new Lazy<MyFirstEventSource>(() => new MyFirstEventSource());

        public static MyFirstEventSource Log
        {
            get { return Instance.Value; }
        }

        [Event(1, Message="Some Event1")]        
        public void SomeEvent1(String fmt, Int32 arg1)
        {
            if (this.IsEnabled())
            {
                WriteEvent(1, fmt, arg1);
            }
        }

        [Event(2, Message = "Some Error1", Level = EventLevel.Error, Keywords = Keywords.Other)]
        public void SomeError(String fmt, Int32 arg1)
        {
            if (this.IsEnabled())
            {
                WriteEvent(2, fmt, arg1);
            }
        }

        [Event(3, Message = "XSome Error2", Level = EventLevel.Error, Keywords = Keywords.Keyword1)]
        public void SomeError2(String fmtX, Int32 arg1)
        {
            if (this.IsEnabled())
            {
                WriteEvent(3, fmtX, arg1);
            }
        }

        [Event(4, Message = "Some Critical", Level = EventLevel.Critical, Keywords = Keywords.Other)]
        public void SomeCritical(String fmt2, Int32 arg1)
        {
            if (this.IsEnabled())
            {
                WriteEvent(4, fmt2, arg1);
            }
        }

        [Event(5, Message = "Some Warning", Level = EventLevel.Warning, Keywords = Keywords.Other)]
        public void SomeWarning(String fmt, Int32 arg1)
        {
            if (this.IsEnabled())
            {
                WriteEvent(5, fmt, arg1);
            }
        }

        [Event(6, Message = "Some Verbose", Level = EventLevel.Verbose)]
        public void SomeVerbose(String fmt, Int32 arg1)
        {
            if (this.IsEnabled())
            {
                WriteEvent(6, fmt, arg1);
            }
        }

        [Event(10, Message = "SomeSimple Event1")]
        public void SomeSimple(String arg1, String arg2)
        {
            if (this.IsEnabled())
            {
                WriteEvent(10, arg1, arg2);
            }
        }

        public class Keywords
        {
            public const EventKeywords Keyword1 = (EventKeywords)0x0001;
            public const EventKeywords Keyword2 = (EventKeywords)0x0002;
            public const EventKeywords Other = (EventKeywords)0x0004;
        }
    }
}
