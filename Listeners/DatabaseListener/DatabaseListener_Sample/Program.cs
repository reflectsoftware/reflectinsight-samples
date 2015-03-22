using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ReflectSoftware.Insight;

namespace DatabaseListener_Sample
{
    class Program
    {
        static void DBListenerTest()
        {            
            RILogManager.Default.SendMessage("Hello");

            RIExtendedMessageProperty.AttachToSingleMessage("Caption1", "FName", "Ross");
            RIExtendedMessageProperty.AttachToSingleMessage("Caption1", "LName", "Pellegrino");
            RIExtendedMessageProperty.AttachToSingleMessage("Caption2", "FName", "Tammy");
            RIExtendedMessageProperty.AttachToSingleMessage("Caption2", "LName", "Gregoire");
            RILogManager.Default.SendException(new Exception("SomeException"));

            RIExtendedMessageProperty.AttachToRequest("Caption1", "FName", "Ross2");
            RIExtendedMessageProperty.AttachToRequest("Caption1", "LName", "Pellegrino2");

            RILogManager.Default.SendDebug("This is a debug");
            RILogManager.Default.SendTrace("This is a trace");
            RILogManager.Default.SendWarning("This is a warning");
            RILogManager.Default.SendError("This is a error");
            RILogManager.Default.SendFatal("This is a fatal");
            
            // send a 1000 messages 
            for (Int32 i = 0; i < 1000; i++)
            {
                RILogManager.Default.SendMessage("Message: {0}", i + 1);
            }
        }
                
        static void Main(string[] args)
        {
            DBListenerTest();
        }
    }
}
