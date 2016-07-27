using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;

using ReflectSoftware.Insight;

namespace HttpModule_Sample
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RILogManager.Default.SendMessage("Hello1");
            RILogManager.Default.SendMessage("Hello2");

            using (RILogManager.Default.TraceMethod(MethodBase.GetCurrentMethod(), true))
            {
                RILogManager.Default.SendInformation("Information1");
                RILogManager.Default.SendInformation("Information2");
                RILogManager.Default.SendInformation("Information3");
            }
        }

        protected void Button_NoException(object sender, EventArgs e)
        {
            using (RILogManager.Default.TraceMethod(MethodBase.GetCurrentMethod(), true))
            {
                RILogManager.Default.SendInformation("Information1");
                RILogManager.Default.SendInformation("Information2");
                RILogManager.Default.SendInformation("Information3");
            }

            RILogManager.Default.AddSeparator();
        }

        protected void Button_Exception1(object sender, EventArgs e)
        {
            using (RILogManager.Default.TraceMethod(MethodBase.GetCurrentMethod(), true))
            {
                try
                {
                    RILogManager.Default.SendInformation("Information1");
                    RILogManager.Default.SendInformation("Information2");
                    RILogManager.Default.SendInformation("Information3");

                    throw new Exception("Throw exception1");
                }
                catch (Exception ex)
                {
                    RILogManager.Default.SendException(ex);
                }
            }
        }

        protected void Button_Exception2(object sender, EventArgs e)
        {
            using (RILogManager.Default.TraceMethod(MethodBase.GetCurrentMethod(), true))
            {
                try
                {
                    RILogManager.Default.EnterMethod(MethodBase.GetCurrentMethod(), true);
                    RILogManager.Default.EnterMethod(MethodBase.GetCurrentMethod(), true);
                    RILogManager.Default.EnterMethod(MethodBase.GetCurrentMethod(), true);

                    RILogManager.Default.SendInformation("Information1");
                    RILogManager.Default.SendInformation("Information2");
                    RILogManager.Default.SendInformation("Information3");

                    RILogManager.Default.ExitMethod(MethodBase.GetCurrentMethod(), true);
                    RILogManager.Default.ExitMethod(MethodBase.GetCurrentMethod(), true);
                    RILogManager.Default.ExitMethod(MethodBase.GetCurrentMethod(), true);

                    throw new Exception("Throw exception2");
                }
                catch (Exception ex)
                {
                    RILogManager.Default.SendException(ex);
                }
            }
        }
    }
}
