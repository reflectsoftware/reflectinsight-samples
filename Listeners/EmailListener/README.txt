Email Listener Sample

This sample demonstrates how to use the ReflectInsight Email Listener. 

This sample also uses satellite configuration files, which are a practice that we recommend doing. For more information about satellite configuration files, please
see the satellite configuration sample and/or our online resource.

To get started with the Email Listener, please do the following:

1. Start by adding an application configuration file (app.config) to your project. If you already have one, then proceed to step #2.

2. Next add/update the configSections with a section for for "insightSettings":

  <configSections>
    <section name="insightSettings" type="ReflectSoftware.Insight.ConfigurationHandler,ReflectSoftware.Insight"/>
  </configSections>

3. Then add a new section called <insightSettings></insightSettings> and add the externalConfigSource to point to your external ReflectInsight.config file:

  <insightSettings externalConfigSource="ReflectInsight.config" />

4. Please make sure you update the ReflectInsight.config file property 'Copy to Output Directory' to 'Copy always'.
       
5. Next add in the <system.net> configuration for <mailSettings> and configure it appropriately for your environment:

  <system.net>
    <mailSettings>
      <smtp from="ReflectInsight@demo.com">
        <network host="smtpserver1" port="25" userName="username" password="secret" defaultCredentials="true"/>
      </smtp>
    </mailSettings>
  </system.net>

6. Now you will need to configure the "insightSettings" configuration that is in the satellite file "ReflectInsight.config" with the appropriate Email Listener details.
If you look inside the ReflectInsight.config file, you will notice 4 sections to the configuration file:
	- Listeners
	- EmailDetails
	- ListenerGroups
	- Filters.

	<listeners> section - In this section, you want to define the email listener.

	<emailDetails> section - In this section, you want to configure the email content details. Parameters surounded with %, like %message% are parameters to the ReflectInsight 
	message that was logged and that will be emailed. In the example configuration file, we show you all the message properties that you can use. You simply have to define
	the content of your email message and what message properties to include in it.

	<listenerGroups> section - ListenerGroups define the destinations that messages are to be logged. In this example we're only sending messages to the Email destination that match the 
	filter criteria. We can easily add in additional destinations like the Viewer, Console, Text File, Binary File, etc. Further details about listener groups is beyond the scope of
	this example and you should refer to the Listener Groups example for more details and/or go to our online resources.

	<filters> section - In this section, you want to define a filter for messages to include or exclude and then assign this filter to a destination listener. If a filter is specified
	on a destination listener, then only messages that match the filter are allowed. In this example we only want to include Errors, Exceptions and Fatal messages. All others are
	excluded from this destination. This means only these 3 message types are going to be sent to the email destination.

7. Now that everything is configured properly, you need to ensure you log an appropriate message that matches your filter.

8. The Email listener is great for sending out emails for specific message types. In this example, for errors, exceptions and fatals. However you can easily flood your inbox
with more emails if you're not careful to which messages are included in the destination and you should take care to not send the same message for an error for every occurance
and instead only send the message at appropriate intervals.

Here is an example of what I mean. Say your trying to connect to a database. Your code constantly tries to connect and with each exception you log it. That's not the best approach
as you flood your logs and in this case your inbox with too much noise. Instead you should only log the error after so many retry attempts or after a certain period of time has
ellapsed.

9. That's it to the email listener example. 


Additional Resources

Getting Started with Email Listener Configuration
https://insightextensions.codeplex.com/wikipage?title=Getting%20Started%20with%20Email%20Listener%20Extension&referringTitle=Documentation

Knowledge Base
http://reflectsoftware.uservoice.com/knowledgebase

User Feedback
http://reflectsoftware.uservoice.com/forums/158277-reflectinsight-feedback

Support
support@reflectsoftware.com