# Embedded Configuration Sample

This sample demonstrates how to add the ReflectInsight configuration to your application.

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
RILogManager.Default.SendMessage("This is a logged message using embedded configuration.");
```

### Configuration

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

That's it your done!

## Resources

Please refer to the ReflectInsight [Documentation](https://reflectsoftware.atlassian.net/wiki/display/RI5/ReflectInsight+5+documentation) for details on configuring ReflectInsight.
       
Feedback is always welcome on our [UserVoice](http://reflectsoftware.uservoice.com/forums/158277-reflectinsight-feedback).

Contact [support](support@reflectsoftware.com) for any help!


