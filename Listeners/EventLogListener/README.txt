Event Log Listener Sample

This sample demonstrates how to use the ReflectInsight Event Log Listener.

This sample also uses satellite configuration files, which are a practice that we recommend doing. For more information about satellite configuration files, please
see the satellite configuration sample and/or our online resource.

To get started with the Event Log Listener, please do the following:

1. Start by adding an application configuration file (app.config) to your project. If you already have one, then proceed to step #2.

2. Next add/update the configSections with a section for for "insightSettings":

  <configSections>
    <section name="insightSettings" type="ReflectSoftware.Insight.ConfigurationHandler,ReflectSoftware.Insight"/>
  </configSections>

3. Then add a new section called <insightSettings></insightSettings> and add the externalConfigSource to point to your external ReflectInsight.config file:

  <insightSettings externalConfigSource="ReflectInsight.config" />

4. Please make sure you update the ReflectInsight.config file property 'Copy to Output Directory' to 'Copy always'.
    
5. Finally, if you plan to use a different event other than the APPLICATION or a different EVENTSOURCE then you must exec the following cmd and change the 
   items in bold to your preference.

   eventcreate /ID 1 /L APPLICATION /T ERROR  /SO MYEVENTSOURCE /D "My first log"

6. That's it your done!


Additional Resources

Knowledge Base
http://reflectsoftware.uservoice.com/knowledgebase

User Feedback
http://reflectsoftware.uservoice.com/forums/158277-reflectinsight-feedback

Support
support@reflectsoftware.com