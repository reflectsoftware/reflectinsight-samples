Embedded Configuration Sample

This sample demonstrates how to add the "insightSettings" configuration to your application.

1. Start by adding an application configuration file (app.config) to your project. If you already have one, then proceed to step #2.

2. Next add/update the configSections with a section for for "insightSettings":

  <configSections>
    <section name="insightSettings" type="ReflectSoftware.Insight.ConfigurationHandler,ReflectSoftware.Insight"/>
  </configSections>

3. Then add a new section called <insightSettings></insightSettings> and add the following basic settings:

  <insightSettings>
    <baseSettings>
      <configChange enabled="true"/>
      <enable state="all"/>
      <propagateException enabled="false"/>
      <exceptionEventTracker time="20" />
      <debugMessageProcess enabled="true" />
    </baseSettings>
  </insightSettings>  

4. That's it your done!

5. For more information about configuring ReflectInsight, please try out the ReflectInsight Configuration Editor which can be run from the start menu, under ReflectInsight.


Additional Resources

Knowledge Base
http://reflectsoftware.uservoice.com/knowledgebase

User Feedback
http://reflectsoftware.uservoice.com/forums/158277-reflectinsight-feedback

Support
support@reflectsoftware.com


