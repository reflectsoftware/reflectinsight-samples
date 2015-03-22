using System;
using System.Xml;
using System.Diagnostics;

using Microsoft.Practices.EnterpriseLibrary.Logging;

namespace EnterpriseLibrary5_Sample
{
    class Program
    {
        static public XmlDocument GetSampleXmlDocumet()
        {
            XmlDocument xDoc = new XmlDocument() { PreserveWhitespace = true };
            xDoc.Load(String.Format(@"{0}{1}", AppDomain.CurrentDomain.BaseDirectory, "Sample.xml"));
            return xDoc;
        }

        static void EntLibTest()
        {
            while (true)
            {
                Console.WriteLine("Press any key or 'q' to quit...");
                ConsoleKeyInfo k = Console.ReadKey();
                if (k.KeyChar == 'q')
                {
                    break;
                }

                if (Logger.IsLoggingEnabled())
                {
                    Logger.Write("[Enter]Enter Method");
                    Logger.Write("Message1");
                    Logger.Write("Information", "General", 0, 0, TraceEventType.Information);
                    Logger.Write("Critical", "General", 0, 0, TraceEventType.Critical);
                    Logger.Write("Error", "General", 0, 0, TraceEventType.Error);
                    Logger.Write("Warning", "General", 0, 0, TraceEventType.Warning);

                    // Log a message with XML content
                    XmlLogEntry xmlEntry = new XmlLogEntry();
                    xmlEntry.Categories.Add("General");
                    xmlEntry.Severity = TraceEventType.Information;
                    xmlEntry.Message = "Sample XML";
                    xmlEntry.Xml = GetSampleXmlDocumet().CreateNavigator();
                    Logger.Write(xmlEntry);

                    // Log a message with extended property extensions
                    LogEntry lEntry = new LogEntry();
                    lEntry.Categories.Add("General");
                    lEntry.Severity = TraceEventType.Information;
                    lEntry.Message = "message with extended properties.";
                    lEntry.ExtendedProperties["ClientId"] = 1234;
                    lEntry.ExtendedProperties["CompanyId"] = 7895;
                    lEntry.ExtendedProperties["State"] = "CA";
                    Logger.Write(lEntry);

                    Logger.Write("[Exit]Exit Method");
                }
            }
        }

        static void Main(string[] args)
        {
            EntLibTest();
        }
    }
}
