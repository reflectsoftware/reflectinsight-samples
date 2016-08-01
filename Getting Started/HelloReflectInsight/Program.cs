using System;
using System.Collections.Generic;
using System.Linq;

using ReflectSoftware.Insight;

namespace HelloReflectInsight_Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            RILogManager.Default.SendMessage("Hello, ReflectInsight!");
        }
    }
}
