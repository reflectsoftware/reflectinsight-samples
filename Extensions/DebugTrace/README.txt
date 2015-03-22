.NET Diagnostic Debug/Trace Extension Sample

This sample demonstrates how to use the ReflectInsight .NET Diagnostic Debug/Trace Logging Extension. The purpose of this sample is to show you how to leverage ReflectInsight with an pre-existing logging framework.

This sample also uses satellite configuration files, which are a practice that we recommend doing. For more information about satellite configuration files, please
see the satellite configuration sample and/or our online resource.

To get started with the .NET Debug/Trace Logging Extension, please do the following:

1. Start by adding an application configuration file (app.config) to your project. If you already have one, then proceed to step #2.

2. Next add/update the configSections with a section for for "insightSettings":

  <configSections>
    <section name="insightSettings" type="ReflectSoftware.Insight.ConfigurationHandler,ReflectSoftware.Insight"/>
  </configSections>

3. Then add a new section called <insightSettings></insightSettings> and add the externalConfigSource to point to your external ReflectInsight.config file:

  <insightSettings externalConfigSource="ReflectInsight.config" />

4. Please make sure you update the ReflectInsight.config file property 'Copy to Output Directory' to 'Copy always'.
    
5. The last part of the configuration is to setup your <system.diagnostics> section. In this sample we include 2 different <system.diagnostics>
   sections (note that one of them is commented out). You will want to try both out to see how they work.

6. Finally, look at the sample code and the 2 different implementations, one for TestTrace and the other for SourceTraceTest. Depending on how you use the 
   Debug/Trace in your application, you can pick and choose the ReflectInsight implementation to use.

7. That's it your done!

Additional Resources

Getting started with the .NET Diagnostic Debug/Trace configuration
https://insightextensions.codeplex.com/wikipage?title=Getting%20Started%20with%20Diagnostic%20Extension&referringTitle=Documentation

Knowledge Base
http://reflectsoftware.uservoice.com/knowledgebase

User Feedback
http://reflectsoftware.uservoice.com/forums/158277-reflectinsight-feedback

Support
support@reflectsoftware.com