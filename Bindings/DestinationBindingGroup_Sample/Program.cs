using System;
using System.Collections.Generic;
using System.Linq;

using ReflectSoftware.Insight;

namespace DestinationBindingGroup_Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            // get RI instances predefined in the config settings
            RILogManager.Get("ViewerOnly").SendMessage("Only the Viewer will get this message");
            RILogManager.Get("File1Only").SendMessage("Only TextFile1 and BinaryFile1 will get this message");
            RILogManager.Get("File2Only").SendMessage("Only TextFile2 and BinaryFile2 will get this message");


            // by code - example 1a
            using(ReflectInsight ri = new ReflectInsight("Example1"))
            {
                ri.SetDestinationBindingGroup("ViewerOnlyBinding");
                ri.SendMessage("Only the Viewer will get this message");
            }

            // by code - example 1b
            using (ReflectInsight ri = new ReflectInsight("Example1"))
            {
                ri.SetDestinationBindingGroup("File1OnlyBinding");
                ri.SendMessage("Only TextFile1 and BinaryFile1 will get this message");
            }
            
            // you can create instances on the fly and used them throughout the application as needed
            RILogManager.Add("AnotherViewerOnlyInstance", "Another Category", String.Empty, "ViewerOnlyBinding");
            RILogManager.Add("AnotherFile1OnlyInstance", "Another Category", String.Empty, "File1OnlyBinding");

            RILogManager.Get("AnotherViewerOnlyInstance").SendMessage("Only the Viewer will get this message");
            RILogManager.Get("AnotherFile1OnlyInstance").SendMessage("Only TextFile1 and BinaryFile1 will get this message"); 
           
        }
    }
}
