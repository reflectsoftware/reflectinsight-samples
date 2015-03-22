Satellite Configuration Sample

This sample demonstrates how to use ReflectInsight with satellite configuration files in your application. Satellite configuration files are configuration files that exist on their own in seperate configuration file.

To get started with satellite configuration files do the following:

1. Start by adding an application configuration file (app.config) to your project. If you already have one, then proceed to step #2.

2. Next add/update the configSections with a section for for "insightSettings":

  <configSections>
    <section name="insightSettings" type="ReflectSoftware.Insight.ConfigurationHandler,ReflectSoftware.Insight"/>
  </configSections>

3. Then add a new section called <insightSettings></insightSettings> and add the externalConfigSource to point to your external ReflectInsight.config file:

  <insightSettings externalConfigSource="ReflectInsight.config" />

4. Please make sure you update the ReflectInsight.config file property 'Copy to Output Directory' to 'Copy always'.
       
5. Finally you do not need to call the satellite configuration file "ReflectInsight.config". You can name it how you want and in fact can locate it where you want. You just need to add a path to the location of the file.

6. That's it your done!

Additional Resources

Knowledge Base
http://reflectsoftware.uservoice.com/knowledgebase

User Feedback
http://reflectsoftware.uservoice.com/forums/158277-reflectinsight-feedback

Support
support@reflectsoftware.com