HttpModule Extension Sample

This sample demonstrates how to use the ReflectInsight Http Module Extension. The purpose of this sample is to show you how to leverage ReflectInsight with an pre-existing logging framework.

This sample also uses satellite configuration files, which are a practice that we recommend doing. For more information about satellite configuration files, please
see the satellite configuration sample and/or our online resource.

To get started with the Http Module Extension, please do the following:

1. Start by adding an web configuration file (web.config) to your project. If you already have one, then proceed to step #2.

2. Next add/update the configSections with a section for for "insightSettings":

  <configSections>
    <section name="insightSettings" type="ReflectSoftware.Insight.ConfigurationHandler,ReflectSoftware.Insight"/>
  </configSections>

3. Then add a new section called <insightSettings></insightSettings> and add the externalConfigSource to point to your external ReflectInsight.config file:

  <insightSettings externalConfigSource="ReflectInsight.config" />

4. In your Web.config, please make sure you have it include the following sections...<httpModules> and <modules>:

  <system.web>
    <compilation targetFramework="4.0" debug="true"/>
    <httpRuntime/>
    <!-- Used for application pools that support ASP.NET classic mode -->
    <httpModules>
      <add name="RIHttpModule" type="ReflectSoftware.Insight.Extensions.HttpModule.RIHttpModule, ReflectSoftware.Insight.Extensions.HttpModule"/>
    </httpModules>
    <sessionState timeout="20"/>
    <authentication mode="Windows"/>
  </system.web>
  
  <system.webServer>
    <modules runAllManagedModulesForAllRequests="true">
      <!-- Used for application pools that support ASP.NET integrated/pipeline mode 
      <add name="RIHttpModule" type="ReflectSoftware.Insight.Extensions.HttpModule.RIHttpModule, ReflectSoftware.Insight.Extensions.HttpModule" />
      -->
    </modules>
  </system.webServer>
   
5. Now you will need to configure the "insightSettings" configuration that is in the satellite file "ReflectInsight.config" with the appropriate Email Listener details.
If you look inside the ReflectInsight.config file, you will notice 4 sections to the configuration file:
	- HttpModule
	- Extensions
	- LogManager

	<httpModule> section - In this section, you want to define the http module.

	<httpModule>
      <properties name="myDebugHttpProperties">
        <userEnterEnterMethod value="true"/>
        <ignoreUrlsParts>
          <!-- will ignore urls that have any part of its path with any key words listed below -->
          <part name="/somepagetoignore.aspx"/>
          <part name="/someotherpagetoignore"/>
          <part name=".htm"/>
          <part name=".html"/>
          <part name=".css"/>
          <part name=".js"/>
          <part name=".gif"/>
          <part name=".png"/>
          <part name=".jpg"/>
          <part name=".bmp"/>
          <part name=".ico"/>
          <part name=".swf"/>
        </ignoreUrlsParts>
        <ignoreUsername value="false"/>
        <ignoreHeader all="false">
          <!-- will ignore these header values -->
          <parameter name="Connection"/>
          <parameter name="Host"/>
        </ignoreHeader>
        <ignoreQueryString all="false">
          <!-- will ignore these query string parameters -->
          <parameter name="name"/>
          <parameter name="location"/>
        </ignoreQueryString>
        <ignoreFormElements all="false">
          <!-- will ignore these form elements -->
          <element name="__VIEWSTATE"/>
          <element name="__EVENTVALIDATION"/>
          <element name="Password"/>
        </ignoreFormElements>
        <ignoreCookies all="false">
          <!-- will ignore these cookie names -->
          <cookie name="ASP.NET_SessionIdX"/>
        </ignoreCookies>
      </properties>
    </httpModule>

	<extensions> section - In this section, you will configure the HttpModule extension.

	<extensions>
      <extension name="riHttpModule" instance="httpModule" properties="myDebugHttpProperties" enabled="true"/>
    </extensions>

	<logManager> section - In this section, you will configure the LogManager to use the HttpModule extension.

	<logManager>
      <instance name="httpModule" category="HttpModule"/>
    </logManager>

6. Finally, you can add some message logging to your class. 

7. That's it your done!

Additional Resources

Getting started with the Http Module configuration
https://insightextensions.codeplex.com/wikipage?title=Getting%20Started%20with%20Http%20Module%20Extension&referringTitle=Documentation

Knowledge Base
http://reflectsoftware.uservoice.com/knowledgebase

User Feedback
http://reflectsoftware.uservoice.com/forums/158277-reflectinsight-feedback

Support
support@reflectsoftware.com