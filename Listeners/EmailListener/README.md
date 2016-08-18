# Email Listener Sample

This sample will show you how use the **Email** listener to trigger emails when certain log messages are captured.

The Email listener is great for sending out emails for specific message types. In this example we will send an email whenever an **Error**, **Exception** and/or **Fatals** messages are logged. 

NOTE: You can easily flood your inbox with more emails if you're not careful to which messages are included in the destination. You should take care to not send the same message for an error for every occurance
and instead only send the message at appropriate time intervals.

## Getting Started

### Installation

To install ReflectInsight, run the following command in the Package Manager Console:

```powershell
Install-Package ReflectSoftware.Insight
```

### Usage 

Add a using reference to the ReflectSoftware.Insight namespace.

```csharp
using ReflectSoftware.Insight;
```

Then for this sample we're going to use the default log manager for sending our log messages.

```csharp
RILogManager.Default.SendException(new Exception("This is a sample exception from the Email listener."));
```

### Configuration

Next we'll add the Email destination.

1. Start by adding an application configuration file (app.config) to your project. If you already have one, then proceed to step #2.

2. Next add/update the **configSections** with a section for for **"insightSettings"**:

    ```xml
    <configSections>
        <section name="insightSettings" type="ReflectSoftware.Insight.ConfigurationHandler,ReflectSoftware.Insight"/>
    </configSections>
    ```

3. Then add a new section called **"insightSettings"** as shown below and add the following basic settings:

    ```xml
    <insightSettings>
        <baseSettings>
            <configChange enabled="true"/>
            <enable state="all"/>
            <propagateException enabled="false"/>
            <exceptionEventTracker time="20" />
            <debugMessageProcess enabled="true" />
        </baseSettings>

        <!-- Add other ReflectInsight configuration here -->

    </insightSettings>  
    ```

4. The **Email** listener is an extension to ReflectInsight, so we need to define it's listner as shown here:

    ```xml
    <listeners>
      <listener name="Email" type="ReflectSoftware.Insight.Listeners.ListenerEmail, ReflectSoftware.Insight.Listeners.Email"/>
    </listeners>
    ```

5. Now that the Email listener is defined, we need to define the email template. 

    In this section, you want to configure the email content details. Parameters surounded with %, like %message% are parameters to the ReflectInsight 
	message that was logged and that will be emailed. In the example configuration file, we show you all the message properties that you can use. You simply have to define
	the content of your email message and what message properties to include in it.

    In the body of the message I'm adding all the properties of the logged message. As you can see, you can craft the perfect email message for any situation.

    ```xml
    <emailDetails>
      <details name="emailDetails1">
        <IsHtml>True</IsHtml>
        <toAddresses>someone@domain.com</toAddresses>
        <ccAddresses></ccAddresses>
        <bccAddresses></bccAddresses>
        <subject>Application Alert: %message%</subject>
        <priority>High</priority>
        <body>
          <![CDATA[
          The following error was detected in application: '%application%'<br/><br/>          
          Message Type: %messagetype% 
			    Category:     %category% 
			    Computer:     %machine% 
			    Sender Id:    %senderid% 
			    Request Id:   %requestid% 
			    Process Id:   %processid% 
			    Thread Id:    %threadid% 
			    Domain Id:    %domainid% 
			    Application:  %application% 
			    User Domain:  %userdomain% 
			    Username:     %username% 
			    Timestamp:    %time% or %time{dd-MM-yyyy hh:mm:ss.fff}%
          <b>%message%</b><br/><br/>  
          <b>%details%</b><br/><br/>
          Please call technical support: 1-888-555-5555
          ]]>
        </body>
      </details>
    </emailDetails>
    ```

6. Next we need to define the **Email** listener as one of our logging destinations. Looking at the following, we can see
a new destination named "Email" and that its enabled. 
    
    ```xml
    <listenerGroups active="Debug">
      <group name="Debug" enabled="true" maskIdentities="false">
        <destinations>
          <destination name="Email" enabled="true" filter="ErrorWarningFilter" details="Email[details=emailDetails1]"/>
        </destinations>
      </group>
    </listenerGroups>
    ```

7. We now want to setup a filter for our Email destination. Below I have defined a message filter to only **include** Erros, Exceptions and Fatal message types. Whenever any of these messages is received by ReflectInsight, an email will be generated with the appropriate details.

    ```xml
    <filters>
      <filter name="ErrorWarningFilter" mode="Include">
        <method type="SendError"/>
        <method type="SendException"/>
        <method type="SendFatal"/>
      </filter>
    </filters>
    ```

8. Next add in the <system.net> configuration for <mailSettings> and configure it appropriately for your environment:

  <system.net>
    <mailSettings>
      <smtp from="ReflectInsight@demo.com">
        <network host="smtpserver1" port="25" userName="username" password="secret" defaultCredentials="true"/>
      </smtp>
    </mailSettings>
  </system.net>


That's it your done! Build your app and check it out.

## Resources

Please refer to the ReflectInsight [Documentation](https://reflectsoftware.atlassian.net/wiki/display/RI5/ReflectInsight+5+documentation) for details on configuring ReflectInsight.
       
Feedback is always welcome on our [UserVoice](http://reflectsoftware.uservoice.com/forums/158277-reflectinsight-feedback).

Contact [support](support@reflectsoftware.com) for any help!

