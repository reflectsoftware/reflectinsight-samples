# ReflectInsight Live Viewer Listener Sample

This sample will show you how to log to the **ReflectInsight Live Viewer** listener.

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
RILogManager.Default.SendMessage("Message");
RILogManager.Default.SendDebug("Debug");
RILogManager.Default.SendInformation("Info");
RILogManager.Default.SendWarning("Warn");
RILogManager.Default.SendError("Error");
RILogManager.Default.SendFatal("Fatal");
RILogManager.Default.SendException("Exception", new Exception("Test"));
RILogManager.Default.SendMessage("Message");
```

### Configuration

Next we'll add the Viewer destination.

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
    </insightSettings>  
    ```

4. Next we need to define the **Viewer** listener as one of our logging destinations. Looking at the following, we can see
a new destination named "Viewer" and that its enabled. 
    
    ```xml
    <listenerGroups active="Debug">
      <group name="Debug" enabled="true" maskIdentities="false">
        <destinations>
          <destination name="Viewer" enabled="true" details="Viewer" />
        </destinations>
      </group>
    </listenerGroups>
    ```

That's it your done! Build your app and check it out.

## Resources

Please refer to the ReflectInsight [Documentation](https://reflectsoftware.atlassian.net/wiki/display/RI5/ReflectInsight+5+documentation) for details on configuring ReflectInsight.
       
Feedback is always welcome on our [UserVoice](http://reflectsoftware.uservoice.com/forums/158277-reflectinsight-feedback).

Contact [support](support@reflectsoftware.com) for any help!