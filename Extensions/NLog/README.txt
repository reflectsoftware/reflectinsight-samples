NLog Extension Sample

This sample demonstrates how to use the ReflectInsight Log4net Extension. The purpose of this sample is to show you how to leverage ReflectInsight with an pre-existing logging framework.

This sample also uses satellite configuration files, which are a practice that we recommend doing. For more information about satellite configuration files, please
see the satellite configuration sample and/or our online resource.

To get started with the Log4net Extension, please do the following:

1. Start by adding an application configuration file (app.config) to your project. If you already have one, then proceed to step #2.

2. Next add/update the configSections with a section for for "insightSettings":

  <configSections>
    <section name="insightSettings" type="ReflectSoftware.Insight.ConfigurationHandler,ReflectSoftware.Insight"/>
  </configSections>

3. Then add a new section called <insightSettings></insightSettings> and add the externalConfigSource to point to your external ReflectInsight.config file:

  <insightSettings externalConfigSource="ReflectInsight.config" />

4. Please make sure you update the ReflectInsight.config file property 'Copy to Output Directory' to 'Copy always'.
  
5. Next ensure you have configured you application with the applicable nlog configuration and then add in the following configuration sections
   <extensions>, <targets> and <rules> for the ReflectInsight NLog extension:

   <nlog xmlns="http://www.nlog-project.org/schemas/NLog.xsd" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
     <!-- In order to receive location information, you must ensure the layout has the parameter ${callsite} and all 
     its properties set accordantly. -->
     <extensions>
       <add assembly="ReflectSoftware.Insight.Extensions.NLog"/>
     </extensions>
     <targets>
       <target name="ReflectInsight" xsi:type="ReflectInsight" instanceName="nlogInstance1" displayLevel="true" displayLocation="true" layout="${callsite:className=true:fileName=true:includeSourcePath=true:methodName=true}"/>
     </targets>
     <rules>
       <logger name="*" minlevel="TRACE" writeTo="ReflectInsight"/>
     </rules>
   </nlog>

6. Finally, you will need to configure the ReflectInsight.config file to hookup to the nlog extension. The following is the ReflectInsight.config file
   configuration. The section that I would like to highlight is the <logManager> and <instance>. Notice that the instance being used
   is the same name as the nlog extension.

	<?xml version="1.0" encoding="utf-8" ?>
	<configuration>
	  <insightSettings>
		<baseSettings>
		  <configChange enabled="true"/>
		  <propagateException enabled="false"/>
		  <exceptionEventTracker time="20"/>
		  <debugMessageProcess enabled="true"/>
		</baseSettings>

		<listenerGroups active="Debug">
		  <group name="Debug" enabled="true" maskIdentities="false">
			<destinations>
			  <destination name="Viewer" enabled="true" filter="" details="Viewer"/>
			</destinations>
		  </group>
		</listenerGroups>

		<logManager>
		  <instance name="nlogInstance1" category="NLog" bkColor=""/>
		</logManager>
	  </insightSettings>
	</configuration>


7. That's it your done!

Additional Resources

Getting started with the NLog configuration
https://insightextensions.codeplex.com/wikipage?title=Getting%20Started%20with%20NLog%20Extension&referringTitle=Documentation

Knowledge Base
http://reflectsoftware.uservoice.com/knowledgebase

User Feedback
http://reflectsoftware.uservoice.com/forums/158277-reflectinsight-feedback

Support
support@reflectsoftware.com